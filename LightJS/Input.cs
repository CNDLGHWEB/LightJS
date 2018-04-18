﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Input
{

    public class InputBox : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblInfo;
        private System.ComponentModel.Container components = null;

        private InputBox()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            this.txtData = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // txtData
            // 

            this.txtData.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular,
                                                        System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.txtData.Location = new System.Drawing.Point(19, 8);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(317, 23);
            this.txtData.TabIndex = 0;
            this.txtData.Text = "";
            this.txtData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtData_KeyDown);
            this.txtData.UseSystemPasswordChar = false;
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // lblInfo
            // 

            this.lblInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInfo.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular,
                                                        System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(19, 32);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(317, 16);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "";
            this.lblInfo.BackColor = Color.SkyBlue;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // InputBox
            // 

            this.BackColor = Color.SkyBlue;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(350, 48);
            this.ControlBox = false;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputBox";
            this.Text = "InputBox";
            this.ResumeLayout(false);
        }

        //对键盘进行响应
        private void txtData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                txtData.Text = string.Empty;
                this.Close();
            }

        }

        //显示InputBox
        public static string ShowInputBox(string Title, string keyInfo)
        {
            InputBox inputbox = new InputBox();
            inputbox.Text = Title;
            if (keyInfo.Trim() != string.Empty)
                inputbox.lblInfo.Text = keyInfo;
            inputbox.ShowDialog();
            inputbox.txtData.PasswordChar = ' ';
            inputbox.txtData.UseSystemPasswordChar = false;
            return inputbox.txtData.Text;
        }
        public static string PShowInputBox(string Title, string keyInfo, char pwds)
        {
            InputBox inputbox = new InputBox();
            inputbox.Text = Title;
            inputbox.txtData.UseSystemPasswordChar = true;
            inputbox.txtData.PasswordChar = pwds;
            if (keyInfo.Trim() != string.Empty)
                inputbox.lblInfo.Text = keyInfo;
            inputbox.ShowDialog();
            inputbox.txtData.PasswordChar = ' ';
            inputbox.txtData.UseSystemPasswordChar = false;
            return inputbox.txtData.Text;
        }
    }

}