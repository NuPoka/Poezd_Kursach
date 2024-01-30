using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poezd
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "poezdDataSet.reys". При необходимости она может быть перемещена или удалена.
            this.reysTableAdapter.Fill(this.poezdDataSet.reys);

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.ClearSelection();

            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
                return;

            var values = guna2TextBox1.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < guna2DataGridView1.RowCount - 1; i++)
            {
                foreach (string value in values)
                {
                    var row = guna2DataGridView1.Rows[i];

                    if (row.Cells["reysnomerDataGridViewTextBoxColumn"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }
    }
}
