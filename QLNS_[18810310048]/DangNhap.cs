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

namespace QLNS__18810310048_
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void kiemtraTK()
        {
            SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("Select Count(*) from Nguoidung where Taikhoan = @tk And Matkhau = @mk ", ketnoi);
            cmd.Parameters.Add(new SqlParameter("@tk", txtacc.Text));
            cmd.Parameters.Add(new SqlParameter("@mk", txtpass.Text));
            int sl = int.Parse(cmd.ExecuteScalar().ToString());
            if(sl == 1)
            {
                MessageBox.Show(" Login Success !", "OK",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                HeThong form = new HeThong();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show(" Login Failure !", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kiemtraTK();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(hien.Text == "Hide")
            {
                txtpass.PasswordChar = '*';
                
                hien.Text = "Show";
            }
            else
            {
                txtpass.PasswordChar = '\0';
                hien.Text = "Hide";
            }
        }
    }
}
