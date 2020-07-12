using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS__18810310048_
{
    public partial class bai1 : Form
    {
        public bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kq = "";
            int n;
            if (!int.TryParse(txtn.Text, out n))
            {
                MessageBox.Show("Vui lòng chỉ nhập các số nguyên dương", "Cảnh báo", MessageBoxButtons.OKCancel);
            }
            else
            {
                for (int i = n; i > 1; i--)
                {
                    for (int j = 2 * i - 1; j >= 1; j--)
                        kq += "*    ";
                        kq += "\n";
                }
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= 2 * i - 1; j++)
                        kq += "*    ";
                        kq += "\n";
                }
                ve.Text = kq;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BatDau form = new BatDau();
            this.Hide();
            form.Show();
        }
    }
}
