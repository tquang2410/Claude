using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyNhanVien.Forms
{
    public partial class frmBaoCao : Form
    {
        private Chart chart;

        public frmBaoCao()
        {
            InitializeComponent();
            InitializeChart();

            // Đăng ký nhận sự kiện thay đổi dữ liệu
            DataManager.Instance.DataChanged += DataManager_DataChanged;

            // Load dữ liệu ban đầu
            LoadThongKe();
        }

        private void InitializeChart()
        {
            this.Size = new Size(850, 500);

            chart = new Chart();
            chart.Size = new Size(400, 300);
            chart.Location = new Point(400, 50);
            chart.Dock = DockStyle.Right;

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas.Add(chartArea);

            Title title = new Title("Thống kê nhân viên");
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            chart.Titles.Add(title);

            this.Controls.Add(chart);
        }

        private void LoadThongKe()
        {
            dgvThongKe.Rows.Clear();
            var listNV = DataManager.Instance.DanhSachNhanVien;

            if (radPhongBan.Checked)
            {
                var thongKe = listNV
                    .GroupBy(x => x.PhongBan)
                    .Select(g => new
                    {
                        Nhom = g.Key,
                        SoLuong = g.Count(),
                        TiLe = (double)g.Count() / listNV.Count * 100
                    })
                    .ToList();

                foreach (var item in thongKe)
                {
                    dgvThongKe.Rows.Add(item.Nhom, item.SoLuong, $"{item.TiLe:F2}%");
                }
            }
            else
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

                foreach (var item in thongKe)
                {
                    dgvThongKe.Rows.Add(item.Nhom, item.SoLuong, $"{item.TiLe:F2}%");
                }
            }

            LoadChart();
        }

        private void LoadChart()
        {
            try
            {
                chart.Series.Clear();
                Series series = new Series();
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.SkyBlue;

                foreach (DataGridViewRow row in dgvThongKe.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        series.Points.AddXY(
                            row.Cells[0].Value.ToString(),
                            Convert.ToDouble(row.Cells[1].Value)
                        );
                    }
                }

                chart.Series.Add(series);
                chart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biểu đồ: {ex.Message}");
            }
        }

        private void DataManager_DataChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LoadThongKe()));
            }
            else
            {
                LoadThongKe();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Hủy đăng ký sự kiện khi form đóng
            DataManager.Instance.DataChanged -= DataManager_DataChanged;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
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

                            worksheet.Cell("A1").Value = "THỐNG KÊ NHÂN VIÊN";
                            worksheet.Range("A1:C1").Merge();

                            worksheet.Cell("A3").Value = "Phân loại";
                            worksheet.Cell("B3").Value = "Số lượng";
                            worksheet.Cell("C3").Value = "Tỉ lệ";

                            int row = 4;
                            foreach (DataGridViewRow dgvRow in dgvThongKe.Rows)
                            {
                                if (!dgvRow.IsNewRow)
                                {
                                    worksheet.Cell($"A{row}").Value = dgvRow.Cells[0].Value?.ToString();
                                    worksheet.Cell($"B{row}").Value = dgvRow.Cells[1].Value?.ToString();
                                    worksheet.Cell($"C{row}").Value = dgvRow.Cells[2].Value?.ToString();
                                    row++;
                                }
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất báo cáo Excel thành công!", "Thông báo",
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