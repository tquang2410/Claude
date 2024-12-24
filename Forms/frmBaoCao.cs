using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace QuanLyNhanVien.Forms
{
    public partial class frmBaoCao : Form
    {
        private List<NhanVien> listNV;

        public frmBaoCao(List<NhanVien> listNV)
        {
            InitializeComponent();
            this.listNV = listNV;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            if (dgvThongKe.Columns.Count == 0)
            {
                dgvThongKe.Columns.Add("PhongBan", "Phân loại");
                dgvThongKe.Columns.Add("SoLuong", "Số lượng");
                dgvThongKe.Columns.Add("TiLe", "Tỉ lệ %");
            }
            LoadThongKeTheoPhongBan();  // Sửa tên phương thức ở đây
        }

        private void LoadThongKeTheoPhongBan()
        {
            var thongKe = listNV
                .GroupBy(x => x.PhongBan)
                .Select(g => new
                {
                    PhongBan = g.Key,
                    SoLuong = g.Count(),
                    TiLe = (double)g.Count() / listNV.Count * 100
                })
                .ToList();

            dgvThongKe.Rows.Clear();
            foreach (var item in thongKe)
            {
                dgvThongKe.Rows.Add(item.PhongBan,
                                   item.SoLuong,
                                   $"{item.TiLe:F2}%");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "ThongKeNhanVien.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Thống kê");

                            // Thêm tiêu đề
                            worksheet.Cell("A1").Value = "THỐNG KÊ NHÂN VIÊN THEO PHÒNG BAN";
                            worksheet.Range("A1:C1").Merge();

                            // Thêm header
                            worksheet.Cell("A3").Value = "Phòng ban";
                            worksheet.Cell("B3").Value = "Số lượng";
                            worksheet.Cell("C3").Value = "Tỉ lệ";

                            // Thêm dữ liệu
                            int row = 4;
                            foreach (DataGridViewRow dgvRow in dgvThongKe.Rows)
                            {
                                if (!dgvRow.IsNewRow)
                                {
                                    worksheet.Cell($"A{row}").Value = dgvRow.Cells["PhongBan"].Value?.ToString();
                                    worksheet.Cell($"B{row}").Value = dgvRow.Cells["SoLuong"].Value?.ToString();
                                    worksheet.Cell($"C{row}").Value = dgvRow.Cells["TiLe"].Value?.ToString();
                                    row++;
                                }
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo",
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

        private void btnSapXepBC_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ DataGridView
            var danhSachThongKe = new List<(string PhongBan, int SoLuong, double TiLe)>();

            foreach (DataGridViewRow row in dgvThongKe.Rows)
            {
                if (!row.IsNewRow)
                {
                    string phongBan = row.Cells["PhongBan"].Value?.ToString() ?? "";
                    int soLuong = int.Parse(row.Cells["SoLuong"].Value?.ToString() ?? "0");
                    double tiLe = double.Parse(row.Cells["TiLe"].Value?.ToString().TrimEnd('%') ?? "0");

                    danhSachThongKe.Add((phongBan, soLuong, tiLe));
                }
            }

            // Sắp xếp theo số lượng giảm dần
            danhSachThongKe = danhSachThongKe.OrderByDescending(x => x.SoLuong).ToList();

            // Hiển thị lại dữ liệu
            dgvThongKe.Rows.Clear();
            foreach (var item in danhSachThongKe)
            {
                dgvThongKe.Rows.Add(item.PhongBan, item.SoLuong, $"{item.TiLe:F2}%");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (radPhongBan.Checked)
            {
                LoadThongKeTheoPhongBan();
            }
            else if (radGioiTinh.Checked)
            {
                LoadThongKeTheoGioiTinh();
            }
        }

        private void LoadThongKeTheoGioiTinh()
        {
            var thongKe = listNV
                .GroupBy(x => x.GioiTinh)
                .Select(g => new
                {
                    Nhom = g.Key ? "Nam" : "Nữ",
                    SoLuong = g.Count(),
                    TiLe = (double)g.Count() / listNV.Count * 100
                })
                .ToList();

            dgvThongKe.Rows.Clear();
            foreach (var item in thongKe)
            {
                dgvThongKe.Rows.Add(item.Nhom,
                                   item.SoLuong,
                                   $"{item.TiLe:F2}%");
            }
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Word Document|*.docx";
                sfd.FileName = "ThongKeNhanVien.docx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Tạo đối tượng Word và document mới
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        var doc = wordApp.Documents.Add();

                        // Thêm tiêu đề
                        var titlePara = doc.Content.Paragraphs.Add();
                        titlePara.Range.Text = "THỐNG KÊ NHÂN VIÊN";
                        titlePara.Range.Font.Size = 16;
                        titlePara.Range.Font.Bold = 1;
                        titlePara.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        titlePara.Range.InsertParagraphAfter();

                        // Tạo bảng
                        var table = doc.Tables.Add(doc.Paragraphs.Last.Range,
                            dgvThongKe.Rows.Count + 1, dgvThongKe.Columns.Count);
                        table.Borders.Enable = 1;

                        // Thêm header
                        for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                        {
                            table.Cell(1, i + 1).Range.Text = dgvThongKe.Columns[i].HeaderText;
                            table.Cell(1, i + 1).Range.Font.Bold = 1;
                        }

                        // Thêm dữ liệu
                        for (int row = 0; row < dgvThongKe.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvThongKe.Columns.Count; col++)
                            {
                                table.Cell(row + 2, col + 1).Range.Text =
                                    dgvThongKe.Rows[row].Cells[col].Value?.ToString() ?? "";
                            }
                        }

                        // Lưu và đóng
                        doc.SaveAs2(sfd.FileName);
                        doc.Close();
                        wordApp.Quit();

                        MessageBox.Show("Xuất Word thành công!", "Thông báo",
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