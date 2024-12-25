using System;
using System.Collections.Generic;
using QuanLyNhanVien.Models;


namespace QuanLyNhanVien.Models
{
    public class DataManager
    {
        private static DataManager instance;
        private List<NhanVien> listNV;

        public event EventHandler DataChanged;

        private DataManager()
        {
            listNV = new List<NhanVien>();
        }

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataManager();
                return instance;
            }
        }

        public List<NhanVien> DanhSachNhanVien
        {
            get { return listNV; }
            set
            {
                listNV = value;
                OnDataChanged();
            }
        }

        protected virtual void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}