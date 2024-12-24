﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; } // true: Nam, false: Nữ
        public string PhongBan { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    }
}
