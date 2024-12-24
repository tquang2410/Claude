namespace QuanLyNhanVien.Forms
{
    partial class frmHuongDan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.rtbHeThong = new System.Windows.Forms.RichTextBox();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.rtbNhanVien = new System.Windows.Forms.RichTextBox();
            this.tabPhongBan = new System.Windows.Forms.TabPage();
            this.rtbPhongBan = new System.Windows.Forms.RichTextBox();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.rtbBaoCao = new System.Windows.Forms.RichTextBox();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.rtbBackup = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabHeThong.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            this.tabPhongBan.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHeThong);
            this.tabControl1.Controls.Add(this.tabNhanVien);
            this.tabControl1.Controls.Add(this.tabPhongBan);
            this.tabControl1.Controls.Add(this.tabBaoCao);
            this.tabControl1.Controls.Add(this.tabBackup);
            this.tabControl1.Location = new System.Drawing.Point(13, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHeThong
            // 
            this.tabHeThong.Controls.Add(this.rtbHeThong);
            this.tabHeThong.Location = new System.Drawing.Point(4, 22);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeThong.Size = new System.Drawing.Size(760, 390);
            this.tabHeThong.TabIndex = 0;
            this.tabHeThong.Text = "Hệ thống";
            this.tabHeThong.UseVisualStyleBackColor = true;
            // 
            // rtbHeThong
            // 
            this.rtbHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHeThong.Location = new System.Drawing.Point(3, 3);
            this.rtbHeThong.Name = "rtbHeThong";
            this.rtbHeThong.ReadOnly = true;
            this.rtbHeThong.Size = new System.Drawing.Size(754, 384);
            this.rtbHeThong.TabIndex = 0;
            this.rtbHeThong.Text = "";
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.rtbNhanVien);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 22);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(439, 74);
            this.tabNhanVien.TabIndex = 1;
            this.tabNhanVien.Text = "Quản lý nhân viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // rtbNhanVien
            // 
            this.rtbNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNhanVien.Location = new System.Drawing.Point(3, 3);
            this.rtbNhanVien.Name = "rtbNhanVien";
            this.rtbNhanVien.ReadOnly = true;
            this.rtbNhanVien.Size = new System.Drawing.Size(433, 68);
            this.rtbNhanVien.TabIndex = 0;
            this.rtbNhanVien.Text = "";
            // 
            // tabPhongBan
            // 
            this.tabPhongBan.Controls.Add(this.rtbPhongBan);
            this.tabPhongBan.Location = new System.Drawing.Point(4, 22);
            this.tabPhongBan.Name = "tabPhongBan";
            this.tabPhongBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhongBan.Size = new System.Drawing.Size(439, 74);
            this.tabPhongBan.TabIndex = 2;
            this.tabPhongBan.Text = "Quản lý phòng ban";
            this.tabPhongBan.UseVisualStyleBackColor = true;
            // 
            // rtbPhongBan
            // 
            this.rtbPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPhongBan.Location = new System.Drawing.Point(3, 3);
            this.rtbPhongBan.Name = "rtbPhongBan";
            this.rtbPhongBan.ReadOnly = true;
            this.rtbPhongBan.Size = new System.Drawing.Size(433, 68);
            this.rtbPhongBan.TabIndex = 0;
            this.rtbPhongBan.Text = "";
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.rtbBaoCao);
            this.tabBaoCao.Location = new System.Drawing.Point(4, 22);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(439, 74);
            this.tabBaoCao.TabIndex = 3;
            this.tabBaoCao.Text = "Báo cáo thống kê";
            this.tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // rtbBaoCao
            // 
            this.rtbBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBaoCao.Location = new System.Drawing.Point(3, 3);
            this.rtbBaoCao.Name = "rtbBaoCao";
            this.rtbBaoCao.ReadOnly = true;
            this.rtbBaoCao.Size = new System.Drawing.Size(433, 68);
            this.rtbBaoCao.TabIndex = 0;
            this.rtbBaoCao.Text = "";
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.rtbBackup);
            this.tabBackup.Location = new System.Drawing.Point(4, 22);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(439, 74);
            this.tabBackup.TabIndex = 4;
            this.tabBackup.Text = "Backup/Restore";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // rtbBackup
            // 
            this.rtbBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBackup.Location = new System.Drawing.Point(3, 3);
            this.rtbBackup.Name = "rtbBackup";
            this.rtbBackup.ReadOnly = true;
            this.rtbBackup.Size = new System.Drawing.Size(433, 68);
            this.rtbBackup.TabIndex = 0;
            this.rtbBackup.Text = "";
            // 
            // frmHuongDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmHuongDan";
            this.Text = "Hướng dẫn";
            this.tabControl1.ResumeLayout(false);
            this.tabHeThong.ResumeLayout(false);
            this.tabNhanVien.ResumeLayout(false);
            this.tabPhongBan.ResumeLayout(false);
            this.tabBaoCao.ResumeLayout(false);
            this.tabBackup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHeThong;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabPhongBan;
        private System.Windows.Forms.TabPage tabBaoCao;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.RichTextBox rtbHeThong;
        private System.Windows.Forms.RichTextBox rtbNhanVien;
        private System.Windows.Forms.RichTextBox rtbPhongBan;
        private System.Windows.Forms.RichTextBox rtbBaoCao;
        private System.Windows.Forms.RichTextBox rtbBackup;
    }
}