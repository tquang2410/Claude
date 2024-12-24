using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", "Quản lý Nhân viên");
            this.labelProductName.Text = "Quản lý Nhân viên";
            this.labelVersion.Text = String.Format("Version {0}", "1.0.0");
            this.labelCopyright.Text = "Copyright © 2024";
            this.labelCompanyName.Text = "WangTheKet";
            this.textBoxDescription.Text = "Phần mềm quản lý nhân viên được phát triển bởi [WangTheKet].\r\n\r\nLiên hệ: [taquang2345@gmail.com/0776221433]";
        }
    }
}
