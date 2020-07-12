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
    public partial class BatDau : Form
    {
        public BatDau()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DangNhap form = new DangNhap();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bai1 form = new bai1();
            this.Hide();
            form.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult hoi;
            hoi = MessageBox.Show("Bạn Có Muốn Thoát Chương Trình Không ?", "Cảnh báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
