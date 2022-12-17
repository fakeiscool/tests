using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using valutebank.DAL;
using valutebank.DOMAIN;
using valutebank.View;
public static class MainController
{
    private static List<User> UserList = new List<User>();
    private static List<Valute> Valutes = new List<Valute>();
    private static Dictionary<String, User> UserDict = new Dictionary<String, User>();
    public static void LoadData()
    {
        var dataValutes = XMLProvider.LoadValutes();
        var dataUsers = XMLProvider.LoadUsers();
        if (dataValutes != null)
            Valutes = dataValutes;
        if (dataUsers != null) {
            UserList = dataUsers;
            foreach (User u in UserList)
                UserDict.Add(u.Name, u);
        }
    }

    public static void SaveData()
    {
        XMLProvider.SaveValutes(Valutes);
        XMLProvider.SaveUsers(UserList);
    }

    public static void AddNote(User user, string data)
    {
        user.History.Add(data);
    }


    public static List<Valute> GetValutes()
    {
        return Valutes == null ? null : Valutes;
    }

    public static List<User> GetUsers()
    {
        return UserList == null ? null : UserList;
    }


    public static void AddValute(Valute val)
    {
        Valutes.Add(val);
    }

    public static bool AddUser(User user)
    {
        Regex regex = new Regex(@"^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*$");
        if (regex.IsMatch(user.Name) == false)
            return false;
        if (UserDict.ContainsKey(user.Name))
                return false;
            UserDict.Add(user.Name, user);
            UserList.Add(user);
            return true;

    }

    public static void DeleteUser(User user)
    {
            UserDict.Remove(user.Name);
            UserList.Remove(user);
    }

    public static void CreateNewBalance(User user, Valute k)
    {
            user.BalanceList.Add(new Balance(0, k));
    }

    public static void AddToBalance(Balance balance, double amount)
    {
        if (amount < 0)
            amount = 0;
        balance.amount += amount;
    }

    public static bool BalanceWithdrawal(Balance balance, double amount)
    {
        try
        {         
            if (balance.amount < amount)
            {
                MessageBox.Show("Недостаточно средств");
                return false;
            }
            balance.amount -= amount;
            return true;
        }
        catch
        {
            MessageBox.Show("Введено некорректное значение");
            return false;
        }
    }

    public static double Transfer(Balance from, Balance to, String textAmount)
    {
        try
        {
            double amount = double.Parse(textAmount);
            if (amount < 0)
            {
                return -1;
            }
            if (from.amount < amount)
            {
                MessageBox.Show("Недостаточно средств");
                return -1;
            }
            double received = Calculate(from.valute, to.valute, textAmount);
            to.amount += received;
            from.amount -= amount;
            return amount;
        }
        catch
        {
            MessageBox.Show("Введено некорректное значение");
            return -1;
        }
    }

    public static double Calculate(Valute from, Valute to, string amountStr, TextBox tbox = null)
    {
        if (tbox != null)
            tbox.Text = to.Rate.ToString();
        double amount;
        if (double.TryParse(amountStr, out amount))
            return (from.Rate * amount) / to.Rate;
        else
            return double.NaN;
    }

    public static bool Confirm()
    {
        DialogResult result = MessageBox.Show("Подтвердить операцию?","", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}