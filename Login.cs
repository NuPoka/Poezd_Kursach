using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poezd
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Baza dataBases = new Baza();
            var Login = Log.Text;
            var Password = Pass.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, user_login, user_pass from Users where user_login = '{Login}' and user_pass ='{Password}'";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Добро пожаловать в наш ЖД!");
                Main frm1 = new Main();
                frm1.ShowDialog();
                this.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Такого пользователя не существует");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reg reg = new Reg();
            this.Hide();
            reg.Show();
        }
    }
}
