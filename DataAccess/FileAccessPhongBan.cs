using System;
using System.Collections.Generic;
using System.IO;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.DataAccess
{
    public class FileAccessPhongBan
    {
        private readonly string filePath = "phongban.txt";

        public List<PhongBan> LoadData()
        {
            List<PhongBan> listPB = new List<PhongBan>();
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                PhongBan pb = new PhongBan
                                {
                                    MaPhong = parts[0],
                                    TenPhong = parts[1],
                                    MoTa = parts[2],
                                    SoNhanVien = int.Parse(parts[3])
                                };
                                listPB.Add(pb);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // If any error occurs, return an empty list
                listPB = new List<PhongBan>();
            }
            return listPB;
        }

        public void SaveData(List<PhongBan> listPB)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var pb in listPB)
                {
                    string line = $"{pb.MaPhong}|{pb.TenPhong}|{pb.MoTa}|{pb.SoNhanVien}";
                    lines.Add(line);
                }
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception)
            {
                // Handle any file saving errors
            }
        }
    }
}