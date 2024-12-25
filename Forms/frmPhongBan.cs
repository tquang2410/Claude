using QuanLyNhanVien.DataAccess;
using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanVien.Forms
{
    public partial class frmPhongBan : Form
    {
        private List<PhongBan> listPB;
        private bool isThemMoi = false;
        private FileAccessPhongBan fileAccess;

        public frmPhongBan()
        {
            InitializeComponent();

            // Khởi tạo các đối tượng cần thiết
            fileAccess = new FileAccessPhongBan();
            listPB = new List<PhongBan>();

            // Cấu hình và hiển thị dữ liệu
            InitializeDataGridView();
            LoadDataFromFile();
        }

        private void InitializeDataGridView()
        {
            try
            {
                dgvPhongBan.AutoGenerateColumns = false;
                dgvPhongBan.AllowUserToAddRows = false;
                dgvPhongBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPhongBan.MultiSelect = false;

                dgvPhongBan.Columns.Clear();
                dgvPhongBan.Columns.AddRange(new DataGridViewColumn[]
                {
                   new DataGridViewTextBoxColumn
                   {
                       Name = "MaPhong",
                       HeaderText = "Mã phòng",
                       DataPropertyName = "MaPhong"
                   },
                   new DataGridViewTextBoxColumn
                   {
                       Name = "TenPhong",
                       HeaderText = "Tên phòng",
                       DataPropertyName = "TenPhong"
                   },
                   new DataGridViewTextBoxColumn
                   {
                       Name = "MoTa",
                       HeaderText = "Mô tả",
                       DataPropertyName = "MoTa"
                   },
                   new DataGridViewTextBoxColumn
                   {
                       Name = "SoNhanVien",
                       HeaderText = "Số nhân viên",
                       DataPropertyName = "SoNhanVien"
                   }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo DataGridView: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromFile()
        {
            try
            {
                // Load dữ liệu từ file
                listPB = fileAccess.LoadData();
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                listPB = new List<PhongBan>();
            }
        }

        private void LoadDataGridView()
        {
            try
            {
                dgvPhongBan.Rows.Clear();

                // Tính số nhân viên của từng phòng
                var fileAccessNV = new FileAccess();
                var listNV = fileAccessNV.LoadData();

                foreach (var pb in listPB)
                {
                    int soNV = listNV.Count(x => x.PhongBan == pb.TenPhong);
                    pb.SoNhanVien = soNV; // Cập nhật số nhân viên

                    dgvPhongBan.Rows.Add(
                        pb.MaPhong,
                        pb.TenPhong,
                        pb.MoTa,
                        soNV
                    );
                }

                // Lưu lại số liệu đã cập nhật
                fileAccess.SaveData(listPB);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlStatus(bool edit)
        {
            txtMaPhong.Enabled = edit;
            txtTenPhong.Enabled = edit;
            txtMoTa.Enabled = edit;

            btnThem.Enabled = !edit;
            btnSua.Enabled = !edit;
            btnXoa.Enabled = !edit;
            btnLuu.Enabled = edit;
            btnHuy.Enabled = edit;
        }

        private void ClearInputs()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtMoTa.Clear();
            txtSoNhanVien.Clear();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhong.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThemMoi = true;
            SetControlStatus(true);
            ClearInputs();
            txtMaPhong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhongBan.SelectedRows.Count > 0)
            {
                isThemMoi = false;
                SetControlStatus(true);
                txtMaPhong.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhongBan.SelectedRows.Count > 0)
                {
                    string maPhong = dgvPhongBan.SelectedRows[0].Cells["MaPhong"].Value?.ToString();
                    if (!string.IsNullOrEmpty(maPhong))
                    {
                        if (MessageBox.Show("Bạn có chắc muốn xóa phòng ban này?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            listPB.RemoveAll(x => x.MaPhong == maPhong);
                            fileAccess.SaveData(listPB);
                            LoadDataGridView();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var pb = new PhongBan
                {
                    MaPhong = txtMaPhong.Text.Trim(),
                    TenPhong = txtTenPhong.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    SoNhanVien = 0
                };

                if (isThemMoi)
                {
                    if (listPB.Any(x => x.MaPhong == pb.MaPhong))
                    {
                        MessageBox.Show("Mã phòng đã tồn tại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    listPB.Add(pb);
                }
                else
                {
                    var index = listPB.FindIndex(x => x.MaPhong == pb.MaPhong);
                    if (index >= 0)
                    {
                        pb.SoNhanVien = listPB[index].SoNhanVien;
                        listPB[index] = pb;
                    }
                }

                fileAccess.SaveData(listPB);
                LoadDataGridView();
                SetControlStatus(false);
                ClearInputs();

                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlStatus(false);
            ClearInputs();
        }

        private void dgvPhongBan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhongBan.SelectedRows.Count > 0)
                {
                    var row = dgvPhongBan.SelectedRows[0];
                    txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString() ?? "";
                    txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";
                    txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
                    txtSoNhanVien.Text = row.Cells["SoNhanVien"].Value?.ToString() ?? "0";
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            SetControlStatus(false);
        }

     

    }
}