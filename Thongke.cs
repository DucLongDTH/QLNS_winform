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
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
        private void getNV()
        {
            SqlCommand cmd = new SqlCommand("Select * From NhanVien", ketnoi);
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds, "NV");
            comboBox1.DataSource = ds.Tables["NV"];
            comboBox1.DisplayMember = "TenNhanVien";
            comboBox1.ValueMember = "MaNhanVien";
        }
        private void getNam()
        {
            SqlCommand cmd = new SqlCommand("Select Top(1) Nam  From Luong Order By Nam ASC ", ketnoi);
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds, "NV");
            comboBox2.DataSource = ds.Tables["NV"];
            comboBox2.DisplayMember = "Nam";
            comboBox2.ValueMember = "Nam";
        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            getNV();
            getNam();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select Luong, Thang From Luong Where MaNhanVien = @manv and Nam = @nam ORDER By Thang ASC", ketnoi);
            cmd.Parameters.Add(new SqlParameter("@manv", comboBox1.SelectedValue.ToString()));
            cmd.Parameters.Add(new SqlParameter("@nam", comboBox2.SelectedValue.ToString()));
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds, "Luong");
            dataGridView1.DataSource = ds.Tables["Luong"];
        }
    }
}
