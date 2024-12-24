using QuanLyNhanVien.Forms;
using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanVien.DataAccess;


namespace QuanLyNhanVien
{
    public partial class frmMain : Form
    {
        private List<NhanVien> listNV;
        private FileAccess fileAccess = new FileAccess();
        public frmMain()
        {
            InitializeComponent();

            // Load dữ liệu khi form khởi tạo
            listNV = fileAccess.LoadData();

            // Vô hiệu hóa các menu khi khởi động
            DisableMenus();
  
        }

        private void DisableMenus()
        {
            mnuQuanLy.Enabled = false;
            
            mnuBaoCaoNhanVien.Enabled = false;
            mnuDangXuat.Enabled = false;
        }

        private void EnableMenus()
        {
            mnuQuanLy.Enabled = true;
          
            mnuBaoCaoNhanVien.Enabled = true;
            mnuDangXuat.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap frmLogin = new frmDangNhap();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                EnableMenus();  // Thay vì kích hoạt từng menu một, gọi phương thức này
            }
            else
            {
                this.Close();
            }
        }

        private void mnuBaoCaoNhanVien_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao(listNV);
            frm.ShowDialog();
        }


        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Kích hoạt các menu sau khi đăng nhập
                mnuQuanLy.Enabled = true;
                mnuDangNhap.Enabled = false;
                mnuDangXuat.Enabled = true;
                mnuBaoCaoNhanVien.Enabled = true;
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // Vô hiệu hóa các menu sau khi đăng xuất
            mnuQuanLy.Enabled = false;
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            frmHuongDan frm = new frmHuongDan();
            frm.ShowDialog();
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void mnuPhongBan_Click(object sender, EventArgs e)
        {
            frmPhongBan frm = new frmPhongBan();
            frm.ShowDialog();
        }

      
    }
}