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
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
            
        }
        private NguoiDung frm1 = new NguoiDung();
        private PhongBan frm3 = new PhongBan();
        private ChucVu frm4 = new ChucVu();
        private Luong frm5 = new Luong();
        private NhanVien frm2 = new NhanVien();
        private Thongke form6 = new Thongke();
        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm1.MdiParent = this;
            frm1.Show();
            frm3.Hide();
            frm4.Hide();
            frm5.Hide();
            frm2.Hide();
            form6.Hide();

        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.Hide();
            frm4.Hide();
            frm3.MdiParent = this;
            frm3.Show();
            frm5.Hide();
            frm2.Hide();
            form6.Hide();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4.MdiParent = this;
            frm4.Show();
            frm1.Hide();
            frm3.Hide();
            frm5.Hide();
            frm2.Hide();
            form6.Hide();

        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4.Hide();
            frm1.Hide();
            frm3.Hide();
            frm5.MdiParent = this;
            frm5.Show();
            frm2.Hide();
            form6.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4.Hide();
            frm1.Hide();
            frm3.Hide();
            frm5.Hide();
            frm2.MdiParent = this;
            frm2.Show();
            form6.Hide();



        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4.Hide();
            frm1.Hide();
            frm3.Hide();
            frm5.Hide();
            frm2.Hide();
            form6.MdiParent = this;
            form6.Show();
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatDau form = new BatDau();
            this.Hide();
            form.Show();
        }
    }
}
