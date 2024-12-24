namespace QuanLyNhanVien.Forms
{
    partial class frmBaoCao
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
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnSapXepBC = new System.Windows.Forms.Button();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.radPhongBan = new System.Windows.Forms.RadioButton();
            this.radGioiTinh = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.PhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuatWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.grpThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PhongBan,
            this.SoLuong,
            this.TiLe});
            this.dgvThongKe.Location = new System.Drawing.Point(12, 22);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.Size = new System.Drawing.Size(240, 150);
            this.dgvThongKe.TabIndex = 0;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(12, 191);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(80, 30);
            this.btnBaoCao.TabIndex = 1;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(12, 231);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(80, 30);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "Xuất Excel";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnSapXepBC
            // 
            this.btnSapXepBC.Location = new System.Drawing.Point(126, 191);
            this.btnSapXepBC.Name = "btnSapXepBC";
            this.btnSapXepBC.Size = new System.Drawing.Size(126, 30);
            this.btnSapXepBC.TabIndex = 3;
            this.btnSapXepBC.Text = "Sắp xếp theo số lượng";
            this.btnSapXepBC.UseVisualStyleBackColor = true;
            this.btnSapXepBC.Click += new System.EventHandler(this.btnSapXepBC_Click);
            // 
            // grpThongKe
            // 
            this.grpThongKe.Controls.Add(this.btnThongKe);
            this.grpThongKe.Controls.Add(this.radGioiTinh);
            this.grpThongKe.Controls.Add(this.radPhongBan);
            this.grpThongKe.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.grpThongKe.Location = new System.Drawing.Point(320, 22);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Size = new System.Drawing.Size(200, 100);
            this.grpThongKe.TabIndex = 4;
            this.grpThongKe.TabStop = false;
            this.grpThongKe.Text = "Thống kê theo";
            // 
            // radPhongBan
            // 
            this.radPhongBan.AutoSize = true;
            this.radPhongBan.Location = new System.Drawing.Point(7, 20);
            this.radPhongBan.Name = "radPhongBan";
            this.radPhongBan.Size = new System.Drawing.Size(77, 17);
            this.radPhongBan.TabIndex = 0;
            this.radPhongBan.TabStop = true;
            this.radPhongBan.Text = "Phòng ban";
            this.radPhongBan.UseVisualStyleBackColor = true;
            // 
            // radGioiTinh
            // 
            this.radGioiTinh.AutoSize = true;
            this.radGioiTinh.Location = new System.Drawing.Point(7, 43);
            this.radGioiTinh.Name = "radGioiTinh";
            this.radGioiTinh.Size = new System.Drawing.Size(65, 17);
            this.radGioiTinh.TabIndex = 1;
            this.radGioiTinh.TabStop = true;
            this.radGioiTinh.Text = "Giới tính";
            this.radGioiTinh.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(7, 67);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // PhongBan
            // 
            this.PhongBan.HeaderText = "Phân loại";
            this.PhongBan.Name = "PhongBan";
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng nhân viên";
            this.SoLuong.Name = "SoLuong";
            // 
            // TiLe
            // 
            this.TiLe.HeaderText = "Tỉ lệ %";
            this.TiLe.Name = "TiLe";
            // 
            // btnXuatWord
            // 
            this.btnXuatWord.Location = new System.Drawing.Point(126, 231);
            this.btnXuatWord.Name = "btnXuatWord";
            this.btnXuatWord.Size = new System.Drawing.Size(80, 30);
            this.btnXuatWord.TabIndex = 5;
            this.btnXuatWord.Text = "Xuất Word";
            this.btnXuatWord.UseVisualStyleBackColor = true;
            this.btnXuatWord.Click += new System.EventHandler(this.btnXuatWord_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXuatWord);
            this.Controls.Add(this.grpThongKe);
            this.Controls.Add(this.btnSapXepBC);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.dgvThongKe);
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnSapXepBC;
        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.RadioButton radGioiTinh;
        private System.Windows.Forms.RadioButton radPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiLe;
        private System.Windows.Forms.Button btnXuatWord;
    }
}