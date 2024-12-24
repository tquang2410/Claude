using QuanLyNhanVien.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;


namespace QuanLyNhanVien.DataAccess
{
    public class FileAccess
    {
        private readonly string filePath = "nhanvien.json";

        public void SaveData(List<NhanVien> listNV)
        {
            string jsonString = JsonSerializer.Serialize(listNV);
            File.WriteAllText(filePath, jsonString);
        }

        public List<NhanVien> LoadData()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<NhanVien>>(jsonString);
            }
            return new List<NhanVien>();
        }

    

    }
}
