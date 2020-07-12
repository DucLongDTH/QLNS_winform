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
    public partial class NguoiDung : Form
    {
        public NguoiDung()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("Select * From NguoiDung Order By Taikhoan ASC ;", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "ND");
            dataGridView1.DataSource = ds.Tables["ND"];
            ketnoi.Close();
        }
        private void NguoiDung_Load(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
