using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien.Forms
{
    public partial class frmBackupRestore : Form
    {
        private string dataFolder = "Data";  // Thư mục chứa file dữ liệu

        public frmBackupRestore()
        {
            InitializeComponent();
        }

        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBackupPath.Text))
            {
                MessageBox.Show("Vui lòng chọn thư mục backup!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string backupFolder = Path.Combine(txtBackupPath.Text,
                    $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}");
                Directory.CreateDirectory(backupFolder);

                // Copy các file dữ liệu
                foreach (string file in Directory.GetFiles(dataFolder))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(backupFolder, fileName);
                    File.Copy(file, destFile, true);
                }

                MessageBox.Show("Backup dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRestorePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRestorePath.Text))
            {
                MessageBox.Show("Vui lòng chọn thư mục restore!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Dữ liệu hiện tại sẽ bị ghi đè. Bạn có chắc muốn restore?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (string file in Directory.GetFiles(txtRestorePath.Text))
                    {
                        string fileName = Path.GetFileName(file);
                        string destFile = Path.Combine(dataFolder, fileName);
                        File.Copy(file, destFile, true);
                    }

                    MessageBox.Show("Restore dữ liệu thành công!\nVui lòng khởi động lại ứng dụng.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
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
