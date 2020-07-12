using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS__18810310048_
{
    public partial class ChucVu : Form
    {
        public ChucVu()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
        private void getdata()
        {
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("Select * From ChucVu;", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "CV");
            dgvCV.DataSource = ds.Tables["CV"];
            ketnoi.Close();
        }
        private void ChucVu_Load(object sender, EventArgs e)
        {
            getdata();
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            
        }
        private void xoatext()
        {
            txttencv.Text = "";
            txtmacv.Text = "";
        }
        private int checkMa()
        {
            if(txtmacv.Text != "" && txttencv.Text != "")
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("Select Count(*) From ChucVu Where MaChucVu = @macv;", ketnoi);
                cmd.Parameters.Add(new SqlParameter("@macv", txtmacv.Text));
                int sl = int.Parse(cmd.ExecuteScalar().ToString());
                ketnoi.Close();
                return sl;
            }
            else
            {
                
                return 0;
            }

        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if(checkMa() != 1)
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("CV_THEM", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@macv", txtmacv.Text));
                cmd.Parameters.Add(new SqlParameter("@tencv", txttencv.Text));
                cmd.ExecuteNonQuery();
                ketnoi.Close();
                getdata();
                xoatext();
                
            }
            else if (checkMa() == 0)
            {
                MessageBox.Show(" Khong duoc de Trong !");
            }
            else
            {
                MessageBox.Show("Mã bị trùng !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtmacv.Text = dgvCV.Rows[index].Cells["MaChucVu"].Value.ToString();
                txttencv.Text = dgvCV.Rows[index].Cells["TenChucVu"].Value.ToString();
                txtmacv.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnthem.Enabled = false;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            txtmacv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("CV_SUA", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@macv", txtmacv.Text));
            cmd.Parameters.Add(new SqlParameter("@tencv", txttencv.Text));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            txtmacv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("CV_XOA", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@macv", txtmacv.Text));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("Select * from ChucVu Where TenChucVu like '%"+ txttk.Text+"%' ", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "ten");
            dgvCV.DataSource = null;
            dgvCV.DataSource = ds.Tables["ten"];
            ketnoi.Close();
        }
    }
}
