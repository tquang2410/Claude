using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private List<User> userList = new List<User>
{
    new User { Username = "admin", Password = "123456", Role = "Admin" },
    new User { Username = "user", Password = "123456", Role = "User" }
};

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var user = userList.FirstOrDefault(u =>
                u.Username == txtTaiKhoan.Text && u.Password == txtMatKhau.Text);

            if (user != null)
            {
                Program.CurrentUser = user;  // Lưu thông tin user đang đăng nhập
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

       
    }
}
