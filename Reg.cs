using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Poezd
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login reg = new Login();
            this.Hide();
            reg.Show();
        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            Baza dataBases = new Baza();
            var login = Reg_Log.Text;
            var password = Reg_Pass.Text;

            string querystring = $"insert into Users(user_login, user_pass) values ('{login}','{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            dataBases.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан!");
                Login frmlgn = new Login();
                this.Hide();
                frmlgn.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
            dataBases.closeConnection();
        }
    }
}
