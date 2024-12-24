using QuanLyNhanVien.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien
{
    static class Program
    {
        public static User CurrentUser { get; set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy form Main trước
            frmMain mainForm = new frmMain();
            Application.Run(mainForm);
        }
    }
}
