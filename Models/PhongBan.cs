using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Models
{
    public class PhongBan
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string MoTa { get; set; }
        public int SoNhanVien { get; set; }
    
         public PhongBan()
        {
            MaPhong = "";
            TenPhong = "";
            MoTa = "";
            SoNhanVien = 0;
        }
    }
}