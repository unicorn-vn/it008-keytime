﻿using IT008_KeyTime.Commons;
using IT008_KeyTime.Models;
using IT008_KeyTime.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT008_KeyTime
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
            
        //}

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            materialButton1.Enabled = false;
            var username = textBox1.Text;
            var password = textBox2.Text;
            var statement = "SELECT * FROM tbl_users WHERE username ='" + username + "'";
            var user = PostgresHelper.QueryFirst<User>(statement);
            if (user.password == password)
            {
                MessageBox.Show("Login success");
                Store._user = user;
                DashboardForm form = new DashboardForm();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
            this.Cursor = Cursors.Default;
            materialButton1.Enabled = true;
        }

        private void Loginform_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Loginform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi sự kiện click của nút đăng nhập
                materialButton1_Click(sender, e);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi sự kiện click của nút đăng nhập
                materialButton1_Click(sender, e);
            }
        }
    }
}
