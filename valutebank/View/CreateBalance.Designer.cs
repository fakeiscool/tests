﻿
namespace valutebank.View
{
    partial class CreateBalance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxOfCryptoValutes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxOfCryptoValutes
            // 
            this.listBoxOfCryptoValutes.FormattingEnabled = true;
            this.listBoxOfCryptoValutes.Location = new System.Drawing.Point(12, 41);
            this.listBoxOfCryptoValutes.Name = "listBoxOfCryptoValutes";
            this.listBoxOfCryptoValutes.ScrollAlwaysVisible = true;
            this.listBoxOfCryptoValutes.Size = new System.Drawing.Size(120, 277);
            this.listBoxOfCryptoValutes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тип валюты";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 334);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOfCryptoValutes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateBalance";
            this.Text = "Создать новый баланс";
            this.Load += new System.EventHandler(this.ValuteView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOfCryptoValutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}