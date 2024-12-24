using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien.Forms
{
    public partial class frmHuongDan : Form
    {
        public frmHuongDan()
        {
            InitializeComponent();
            LoadHuongDan();
        }

        private void LoadHuongDan()
        {
            // Tab Hệ thống
            rtbHeThong.Text = @"HƯỚNG DẪN SỬ DỤNG HỆ THỐNG

1. Đăng nhập hệ thống:
   - Tài khoản admin: admin/123456
   - Tài khoản user: user/123456
   - User chỉ có quyền xem và tìm kiếm
   - Admin có đầy đủ quyền quản lý

2. Đổi mật khẩu:
   - Vào menu Hệ thống -> Đổi mật khẩu
   - Nhập mật khẩu cũ
   - Nhập mật khẩu mới và xác nhận
   - Nhấn Lưu để hoàn tất

3. Đăng xuất:
   - Vào menu Hệ thống -> Đăng xuất";

            // Tab Quản lý nhân viên
            rtbNhanVien.Text = @"HƯỚNG DẪN QUẢN LÝ NHÂN VIÊN

1. Thêm nhân viên mới:
   - Nhấn nút Thêm
   - Điền đầy đủ thông tin nhân viên
   - Nhấn Lưu để hoàn tất
   - Nhấn Hủy để hủy bỏ thao tác

2. Sửa thông tin nhân viên:
   - Chọn nhân viên cần sửa trong danh sách
   - Nhấn nút Sửa
   - Cập nhật thông tin
   - Nhấn Lưu để hoàn tất

3. Xóa nhân viên:
   - Chọn nhân viên cần xóa
   - Nhấn nút Xóa
   - Xác nhận xóa

4. Tìm kiếm:
   - Nhập từ khóa vào ô tìm kiếm
   - Chọn tiêu chí tìm kiếm
   - Nhấn Tìm";

            // Tab Quản lý phòng ban
            rtbPhongBan.Text = @"HƯỚNG DẪN QUẢN LÝ PHÒNG BAN

1. Thêm phòng ban:
   - Nhấn nút Thêm
   - Điền thông tin phòng ban
   - Nhấn Lưu để hoàn tất

2. Sửa thông tin phòng ban:
   - Chọn phòng ban cần sửa
   - Nhấn nút Sửa
   - Cập nhật thông tin
   - Nhấn Lưu để hoàn tất

3. Xóa phòng ban:
   - Chọn phòng ban cần xóa
   - Nhấn nút Xóa
   - Xác nhận xóa";

            // Tab Báo cáo thống kê
            rtbBaoCao.Text = @"HƯỚNG DẪN BÁO CÁO THỐNG KÊ

1. Xem thống kê:
   - Chọn loại thống kê (theo phòng ban/giới tính)
   - Nhấn nút Thống kê

2. Xuất báo cáo:
   - Nhấn nút Xuất Excel hoặc Xuất Word
   - Chọn nơi lưu file
   - Xác nhận xuất file";

            // Tab Backup/Restore
            rtbBackup.Text = @"HƯỚNG DẪN BACKUP/RESTORE DỮ LIỆU

1. Backup dữ liệu:
   - Vào menu Hệ thống -> Backup/Restore
   - Chọn thư mục lưu backup
   - Nhấn nút Backup
   - Đợi thông báo backup thành công

2. Restore dữ liệu:
   - Vào menu Hệ thống -> Backup/Restore
   - Chọn thư mục chứa file backup
   - Nhấn nút Restore
   - Xác nhận restore
   - Đợi thông báo restore thành công
   - Khởi động lại ứng dụng";
        }


    }
}
