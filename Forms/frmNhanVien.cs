﻿using QuanLyNhanVien.Models;
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
using ClosedXML.Excel;

namespace QuanLyNhanVien.Forms
{
    public partial class frmNhanVien : Form
    {
        private bool isThemMoi = false;
        private FileAccess fileAccess;
        private FileAccessPhongBan fileAccessPB;

        public frmNhanVien()
        {
            InitializeComponent();
            fileAccess = new FileAccess();
            fileAccessPB = new FileAccessPhongBan();

            // Load dữ liệu từ file và cập nhật vào DataManager
            var data = fileAccess.LoadData();
            DataManager.Instance.DanhSachNhanVien = data;

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Cấu hình cơ bản cho DataGridView
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;

            // Thêm các cột
            if (dgvNhanVien.Columns.Count == 0)
            {
                dgvNhanVien.Columns.Add("MaNV", "Mã NV");
                dgvNhanVien.Columns.Add("HoTen", "Họ tên");
                dgvNhanVien.Columns.Add("NgaySinh", "Ngày sinh");
                dgvNhanVien.Columns.Add("GioiTinh", "Giới tính");
                dgvNhanVien.Columns.Add("PhongBan", "Phòng ban");
                dgvNhanVien.Columns.Add("DiaChi", "Địa chỉ");
                dgvNhanVien.Columns.Add("SDT", "Số điện thoại");
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPhongBanToComboBox();

                // Khởi tạo các controls
                dtpTuNgay.Value = DateTime.Now.AddYears(-50);
                dtpDenNgay.Value = DateTime.Now;

                // Cập nhật giao diện
                LoadDataGridView();
                SetControlStatus(false);

                // Phân quyền
                if (Program.CurrentUser.Role != "Admin")
                {
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhongBanToComboBox()
        {
            try
            {
                // Đọc danh sách phòng ban từ file
                var listPB = fileAccessPB.LoadData();

                // Cập nhật ComboBox chọn phòng ban
                cboPhongBan.Items.Clear();
                foreach (var pb in listPB)
                {
                    cboPhongBan.Items.Add(pb.TenPhong);
                }

                // Cập nhật ComboBox lọc phòng ban
                cboLocPhongBan.Items.Clear();
                cboLocPhongBan.Items.Add("");  // Thêm lựa chọn trống
                foreach (var pb in listPB)
                {
                    cboLocPhongBan.Items.Add(pb.TenPhong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng ban: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlStatus(bool edit)
        {
            txtMaNV.Enabled = edit;
            txtHoTen.Enabled = edit;
            dtpNgaySinh.Enabled = edit;
            radNam.Enabled = edit;
            radNu.Enabled = edit;
            cboPhongBan.Enabled = edit;
            txtDiaChi.Enabled = edit;
            txtSDT.Enabled = edit;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnLuu.Enabled = edit;
            btnHuy.Enabled = edit;
        }

        private void LoadDataGridView()
        {
            dgvNhanVien.Rows.Clear();
            var listNV = DataManager.Instance.DanhSachNhanVien;
            foreach (var nv in listNV)
            {
                int rowIndex = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[rowIndex].Cells["MaNV"].Value = nv.MaNV;
                dgvNhanVien.Rows[rowIndex].Cells["HoTen"].Value = nv.HoTen;
                dgvNhanVien.Rows[rowIndex].Cells["NgaySinh"].Value = nv.NgaySinh.ToShortDateString();
                dgvNhanVien.Rows[rowIndex].Cells["GioiTinh"].Value = nv.GioiTinh ? "Nam" : "Nữ";
                dgvNhanVien.Rows[rowIndex].Cells["PhongBan"].Value = nv.PhongBan;
                dgvNhanVien.Rows[rowIndex].Cells["DiaChi"].Value = nv.DiaChi;
                dgvNhanVien.Rows[rowIndex].Cells["SDT"].Value = nv.SDT;
            }
        }

        private void ClearInputs()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            cboPhongBan.SelectedIndex = -1;
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThemMoi = true;
            SetControlStatus(true);
            ClearInputs();
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                isThemMoi = false;
                SetControlStatus(true);
                txtMaNV.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                    var listNV = DataManager.Instance.DanhSachNhanVien.ToList();
                    listNV.RemoveAll(x => x.MaNV == maNV);
                    DataManager.Instance.DanhSachNhanVien = listNV;
                    fileAccess.SaveData(listNV);
                    LoadDataGridView();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var listNV = DataManager.Instance.DanhSachNhanVien.ToList();
                NhanVien nv = new NhanVien
                {
                    MaNV = txtMaNV.Text,
                    HoTen = txtHoTen.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = radNam.Checked,
                    PhongBan = cboPhongBan.Text,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text
                };

                if (isThemMoi)
                {
                    if (listNV.Any(x => x.MaNV == nv.MaNV))
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    listNV.Add(nv);
                }
                else
                {
                    var index = listNV.FindIndex(x => x.MaNV == nv.MaNV);
                    if (index >= 0)
                    {
                        listNV[index] = nv;
                    }
                }

                DataManager.Instance.DanhSachNhanVien = listNV;
                fileAccess.SaveData(listNV);
                LoadDataGridView();
                SetControlStatus(false);
                ClearInputs();

                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlStatus(false);
            ClearInputs();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            if (cboPhongBan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng ban!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPhongBan.Focus();
                return false;
            }

            return true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            var listNV = DataManager.Instance.DanhSachNhanVien;
            List<NhanVien> ketQua = new List<NhanVien>();

            switch (cboTimKiem.Text)
            {
                case "Mã nhân viên":
                    ketQua = listNV.Where(x => x.MaNV.ToLower().Contains(tuKhoa)).ToList();
                    break;
                case "Họ tên":
                    ketQua = listNV.Where(x => x.HoTen.ToLower().Contains(tuKhoa)).ToList();
                    break;
                case "Phòng ban":
                    ketQua = listNV.Where(x => x.PhongBan.ToLower().Contains(tuKhoa)).ToList();
                    break;
            }

            dgvNhanVien.Rows.Clear();
            foreach (var nv in ketQua)
            {
                int rowIndex = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[rowIndex].Cells["MaNV"].Value = nv.MaNV;
                dgvNhanVien.Rows[rowIndex].Cells["HoTen"].Value = nv.HoTen;
                dgvNhanVien.Rows[rowIndex].Cells["NgaySinh"].Value = nv.NgaySinh.ToShortDateString();
                dgvNhanVien.Rows[rowIndex].Cells["GioiTinh"].Value = nv.GioiTinh ? "Nam" : "Nữ";
                dgvNhanVien.Rows[rowIndex].Cells["PhongBan"].Value = nv.PhongBan;
                dgvNhanVien.Rows[rowIndex].Cells["DiaChi"].Value = nv.DiaChi;
                dgvNhanVien.Rows[rowIndex].Cells["SDT"].Value = nv.SDT;
            }
        }

        private void btnTimKiemNC_Click(object sender, EventArgs e)
        {
            var listNV = DataManager.Instance.DanhSachNhanVien;
            var ketQua = listNV.Where(nv =>
                nv.NgaySinh.Date >= dtpTuNgay.Value.Date &&
                nv.NgaySinh.Date <= dtpDenNgay.Value.Date &&
                (cboLocPhongBan.Text == "" || nv.PhongBan == cboLocPhongBan.Text)
            ).ToList();

            dgvNhanVien.Rows.Clear();
            foreach (var nv in ketQua)
            {
                int rowIndex = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[rowIndex].Cells["MaNV"].Value = nv.MaNV;
                dgvNhanVien.Rows[rowIndex].Cells["HoTen"].Value = nv.HoTen;
                dgvNhanVien.Rows[rowIndex].Cells["NgaySinh"].Value = nv.NgaySinh.ToShortDateString();
                dgvNhanVien.Rows[rowIndex].Cells["GioiTinh"].Value = nv.GioiTinh ? "Nam" : "Nữ";
                dgvNhanVien.Rows[rowIndex].Cells["PhongBan"].Value = nv.PhongBan;
                dgvNhanVien.Rows[rowIndex].Cells["DiaChi"].Value = nv.DiaChi;
                dgvNhanVien.Rows[rowIndex].Cells["SDT"].Value = nv.SDT;
            }
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddYears(-50);
            dtpDenNgay.Value = DateTime.Now;
            cboLocPhongBan.SelectedIndex = -1;
            LoadDataGridView();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0 && dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value != null)
            {
                var row = dgvNhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                radNam.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam";
                radNu.Checked = !radNam.Checked;
                cboPhongBan.Text = row.Cells["PhongBan"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (cboSapXep.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí sắp xếp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var listNV = DataManager.Instance.DanhSachNhanVien.ToList();

            switch (cboSapXep.Text)
            {
                case "Mã nhân viên":
                    listNV = radTangDan.Checked ?
                        listNV.OrderBy(x => x.MaNV).ToList() :
                        listNV.OrderByDescending(x => x.MaNV).ToList();
                    break;

                case "Họ tên":
                    listNV = radTangDan.Checked ?
                        listNV.OrderBy(x => x.HoTen).ToList() :
                        listNV.OrderByDescending(x => x.HoTen).ToList();
                    break;

                case "Ngày sinh":
                    listNV = radTangDan.Checked ?
                        listNV.OrderBy(x => x.NgaySinh).ToList() :
                        listNV.OrderByDescending(x => x.NgaySinh).ToList();
                    break;
            }

            DataManager.Instance.DanhSachNhanVien = listNV;
            LoadDataGridView();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var listNV = DataManager.Instance.DanhSachNhanVien.ToList();
                        using (var workbook = new ClosedXML.Excel.XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var rows = worksheet.RowsUsed();

                            foreach (var row in rows.Skip(1))
                            {
                                NhanVien nv = new NhanVien
                                {
                                    MaNV = row.Cell(1).Value.ToString(),
                                    HoTen = row.Cell(2).Value.ToString(),
                                    NgaySinh = DateTime.Parse(row.Cell(3).Value.ToString()),
                                    GioiTinh = row.Cell(4).Value.ToString() == "Nam",
                                    PhongBan = row.Cell(5).Value.ToString(),
                                    DiaChi = row.Cell(6).Value.ToString(),
                                    SDT = row.Cell(7).Value.ToString()
                                };
                                listNV.Add(nv);
                            }
                        }
                        DataManager.Instance.DanhSachNhanVien = listNV;
                        fileAccess.SaveData(listNV);
                        LoadDataGridView();
                        MessageBox.Show("Import dữ liệu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "DanhSachNhanVien.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var listNV = DataManager.Instance.DanhSachNhanVien;
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Nhân viên");

                            // Thêm header
                            worksheet.Cell("A1").Value = "Mã NV";
                            worksheet.Cell("B1").Value = "Họ tên";
                            worksheet.Cell("C1").Value = "Ngày sinh";
                            worksheet.Cell("D1").Value = "Giới tính";
                            worksheet.Cell("E1").Value = "Phòng ban";
                            worksheet.Cell("F1").Value = "Địa chỉ";
                            worksheet.Cell("G1").Value = "Số điện thoại";

                            // Format header
                            var headerRange = worksheet.Range("A1:G1");
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRange.Style.Font.Bold = true;

                            // Thêm dữ liệu
                            int row = 2;
                            foreach (var nv in listNV)
                            {
                                worksheet.Cell($"A{row}").Value = nv.MaNV;
                                worksheet.Cell($"B{row}").Value = nv.HoTen;
                                worksheet.Cell($"C{row}").Value = nv.NgaySinh;
                                worksheet.Cell($"D{row}").Value = nv.GioiTinh ? "Nam" : "Nữ";
                                worksheet.Cell($"E{row}").Value = nv.PhongBan;
                                worksheet.Cell($"F{row}").Value = nv.DiaChi;
                                worksheet.Cell($"G{row}").Value = nv.SDT;
                                row++;
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Export dữ liệu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}