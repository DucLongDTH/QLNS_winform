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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.;Initial Catalog=QLNHANSU;Integrated Security=True");
        private void getPhongBan()
        {
            
            SqlCommand cmd = new SqlCommand("Select * From PhongBan", ketnoi);
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds,"PhongBan");
            cbphong.DataSource = ds.Tables["PhongBan"];
            cbphong.DisplayMember = "TenPhong";
            cbphong.ValueMember = "MaPhong";
        }
        private void getChucVu()
        {
            
            SqlCommand cmd = new SqlCommand("Select * From ChucVu", ketnoi);
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds, "ChucVu");
            cbCV.DataSource = ds.Tables["ChucVu"];
            cbCV.DisplayMember = "TenChucVu";
            cbCV.ValueMember = "MaChucVu";
        }

        private void getdata()
        {
            
            SqlCommand cmd = new SqlCommand("Select * From NhanVien", ketnoi);
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sql.Fill(ds, "NhanVien");
            dgvNV.DataSource = ds.Tables["NhanVien"];
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            getdata();
            getChucVu();
            getPhongBan();
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
        }
        private int checkMa()
        {
            if (txtmanv.Text != "" && txttennv.Text != "")
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("Select Count(*) From NhanVien Where MaNhanVien = @manv;", ketnoi);
                cmd.Parameters.Add(new SqlParameter("@manv", txtmanv.Text));
                int sl = int.Parse(cmd.ExecuteScalar().ToString());
                ketnoi.Close();
                return sl;
            }
            else
            {

                return 0;
            }

        }

        private void xoatext() {
            txtmanv.Text = "";
            txttennv.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (checkMa() != 1)
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("NV_THEM", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@manv", txtmanv.Text));
                cmd.Parameters.Add(new SqlParameter("@tennv", txttennv.Text));
                cmd.Parameters.Add(new SqlParameter("@macv", cbCV.SelectedValue.ToString()));
                cmd.Parameters.Add(new SqlParameter("@maphong", cbphong.SelectedValue.ToString()));
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
                xoatext();
            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("NV_SUA", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@manv", txtmanv.Text));
            cmd.Parameters.Add(new SqlParameter("@tennv", txttennv.Text));
            cmd.Parameters.Add(new SqlParameter("@macv", cbCV.SelectedValue.ToString()));
            cmd.Parameters.Add(new SqlParameter("@maphong", cbphong.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
            txtmanv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnThem.Enabled = true;
        }
        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                txtmanv.Text = dgvNV.Rows[index].Cells["MaNhanVien"].Value.ToString();
                txtmanv.Enabled = false;
                txttennv.Text = dgvNV.Rows[index].Cells["TenNhanVien"].Value.ToString();
                cbCV.SelectedValue = dgvNV.Rows[index].Cells["MaChucVu"].Value.ToString();
                cbphong.SelectedValue = dgvNV.Rows[index].Cells["MaPhong"].Value.ToString();
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnThem.Enabled = false;
            }
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("NV_XOa", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@manv", txtmanv.Text));
            cmd.ExecuteNonQuery();
            ketnoi.Close();
            getdata();
            xoatext();
            txtmanv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnThem.Enabled = true;
        }
        private void btntk_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from NhanVien Where TenNhanVien like '%" + txtTK.Text + "%' ", ketnoi);
            SqlDataAdapter sqladt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqladt.Fill(ds, "tennv");
            dgvNV.DataSource = null;
            dgvNV.DataSource = ds.Tables["tennv"];
        }
    }
}
