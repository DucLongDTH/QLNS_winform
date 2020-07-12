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
    public partial class PhongBan : Form
    {
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
        private void getdata()
        {
            
            SqlCommand cmd = new SqlCommand("Select * From PhongBan ;", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "CV");
            dgvPB.DataSource = ds.Tables["CV"];
            
        }
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            getdata();
            btnsua.Enabled = false;
            btnxoa.Enabled = false;

        }
        private void xoatext()
        {
           txtmp.Text = "";
           txttp.Text = "";
        }
        private int checkMa()
        {
            if (txtmp.Text != "" && txtmp.Text != "")
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("Select Count(*) From PhongBan Where MaPhong = @maph;", ketnoi);
                cmd.Parameters.Add(new SqlParameter("@maph", txtmp.Text));
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
            if (checkMa() != 1)
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("PB_THEM", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maphong", txtmp.Text));
                cmd.Parameters.Add(new SqlParameter("@tenphong", txttp.Text));
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


        private void btnsua_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            txtmp.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("PB_SUA", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maphong", txtmp.Text));
            cmd.Parameters.Add(new SqlParameter("@tenphong", txttp.Text));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
        }

        private void dgvPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtmp.Text = dgvPB.Rows[index].Cells["MaPhong"].Value.ToString();
                txttp.Text = dgvPB.Rows[index].Cells["TenPhong"].Value.ToString();
                txtmp.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnthem.Enabled = false;
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            txtmp.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("PB_XOA", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maphong", txtmp.Text));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select * from PhongBan Where TenPhong like '%" + txtTK.Text + "%' ", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "ten");
            dgvPB.DataSource = null;
            dgvPB.DataSource = ds.Tables["ten"];
            
        }
    }
}
