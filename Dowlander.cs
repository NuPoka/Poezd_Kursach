using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Poezd
{
    public partial class Dowlander : Form
    {
        public Dowlander()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += timer1;
            timer.Start();
        }

        private void timer1(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Отменяем закрытие формы
            e.Cancel = true;
            // Открываем вторую форму
            Login form2 = new Login();
            form2.Show();

            // Отключаем обработчик события FormClosing
            this.FormClosing -= Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form1_FormClosing;
        }
    }
}
