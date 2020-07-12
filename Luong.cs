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
    public partial class Luong : Form
    {
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
        public Luong()
        {
            InitializeComponent();
        }
        private void getdata()
        {

            SqlCommand cmd = new SqlCommand("Select * From Luong ;", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "Luong");
            dgvLuong.DataSource = ds.Tables["Luong"];

        }

        private void getNV()
        {
            SqlCommand cmd = new SqlCommand("Select * From NhanVien", ketnoi);
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds, "NV");
            cbboxMANV.DataSource = ds.Tables["NV"];
            cbboxMANV.DisplayMember = "TenNhanVien";
            cbboxMANV.ValueMember = "MaNhanVien";
        }
        private void Luong_Load(object sender, EventArgs e)
        {
            getdata();
            getNV();
            btnsua.Enabled = false;
        }

        private int checkMa()
        {
            if (txtLuong.Text != "" && txtNam.Text != "" && txtThang.Text != "")
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Luong Where MaBangLuong = @maluong;", ketnoi);
                cmd.Parameters.Add(new SqlParameter("@maluong", txtLuong.Text));
                int sl = int.Parse(cmd.ExecuteScalar().ToString());
                ketnoi.Close();
                return sl;
            }
            else
            {

                return 0;
            }

        }
        private void xoatext()
        {
            txtmaluong.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtLuong.Text = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkMa() != 1)
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("Luong_them", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maluong",txtmaluong.Text));
                cmd.Parameters.Add(new SqlParameter("@manv", cbboxMANV.SelectedValue.ToString()));
                cmd.Parameters.Add(new SqlParameter("@thang", txtThang.Text));
                cmd.Parameters.Add(new SqlParameter("@nam", txtNam.Text));
                cmd.Parameters.Add(new SqlParameter("@luong", txtLuong.Text));
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

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtmaluong.Text = dgvLuong.Rows[index].Cells["MaBangLuong"].Value.ToString();
                txtmaluong.Enabled = false;
                cbboxMANV.SelectedValue = dgvLuong.Rows[index].Cells["MaNhanVien"].Value.ToString();
                txtLuong.Text = dgvLuong.Rows[index].Cells["Luong"].Value.ToString();
                txtNam.Text = dgvLuong.Rows[index].Cells["Nam"].Value.ToString();
                txtThang.Text = dgvLuong.Rows[index].Cells["Thang"].Value.ToString();
                btnsua.Enabled = true;
                btnthem.Enabled = false;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("Luong_SUA", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maluong", txtmaluong.Text));
            cmd.Parameters.Add(new SqlParameter("@luong", txtLuong.Text));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
            txtmaluong.Enabled = true;
            btnsua.Enabled = false;
            btnthem.Enabled = true;
        }
    }
}
