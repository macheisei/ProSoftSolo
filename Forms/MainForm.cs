using ProSoft.Controls;
using ProSoft.Models;




namespace ProSoft.Forms
{
    public partial class MainForm : Form
    {
        private Label lblWelcome; // Khai báo ở cấp class
        private Label lblContact;
        
        




        public MainForm()
        {
            InitializeComponent();
            SetupUI();
            this.WindowState = FormWindowState.Maximized;
            LoadMenu();
           
            // Trong InitializeComponent()
            this.Controls.Add(this.treeViewMenu);

            this.treeViewMenu.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);         // Nền tối sang trọng
            this.treeViewMenu.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);      // Chữ trắng
            this.treeViewMenu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.treeViewMenu.BorderStyle = BorderStyle.FixedSingle;
            this.treeViewMenu.HideSelection = false;
            this.treeViewMenu.FullRowSelect = true;
            this.treeViewMenu.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeViewMenu.DrawNode += new DrawTreeNodeEventHandler(treeViewMenu_DrawNode);
            this.panelMain.Dock = DockStyle.Fill;



            Panel panelMainContent = new Panel();
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.BackColor = System.Drawing.Color.White;
            this.Controls.Add(panelMainContent);

            treeViewMenu.AfterSelect += treeViewMenu_AfterSelect;
            Load += MainForm_Load;
            panelMainContent.Resize += panelMainContent_Resize;
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupWelcomeScreen();
            panelMainContent_Resize(null, EventArgs.Empty);
        }

        private void SetupWelcomeScreen()
        {
            // Tạo Label chào mừng
            lblWelcome = new Label
            {
                Text = "Chào mừng bạn đến với ProSoft",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = System.Drawing.Color.MidnightBlue,
                BackColor = System.Drawing.Color.Transparent,
                AutoSize = true
            };

            // Tạo Label liên hệ
            lblContact = new Label
            {
                Text = "Liên hệ nhà phát triển ProSoft - Tel: 0987789989 --- Email: mac84.heisei@gmail.com",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = System.Drawing.Color.DarkRed,
                BackColor = System.Drawing.Color.Transparent,
                AutoSize = true
            };

            // Thêm các control vào panelMainContent

            panelMainContent.Controls.Add(lblWelcome);
            panelMainContent.Controls.Add(lblContact);

            // Đảm bảo các label hiển thị trên hình nền
            lblWelcome.BringToFront();
            lblContact.BringToFront();
        }
        private void panelMainContent_Resize(object sender, EventArgs e)
        {
            if (lblWelcome != null && lblContact != null)
            {
                lblWelcome.Location = new Point(
                    (panelMainContent.Width - lblWelcome.Width) / 2,
                    panelMainContent.Height / 4
                );
                lblContact.Location = new Point(
                    panelMainContent.Width - lblContact.Width - 20,
                    panelMainContent.Height - lblContact.Height - 20
                );
            }
        }
        private void treeViewMenu_DrawNode(object? sender, DrawTreeNodeEventArgs e)
        {
            TreeView tree = sender as TreeView;
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                // Màu khi chọn
                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(0, 122, 204)), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node?.Text, tree.Font,
                    e.Bounds, System.Drawing.Color.White, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                // Màu khi không chọn
                e.Graphics.FillRectangle(new SolidBrush(tree.BackColor), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node?.Text, tree.Font,
                    e.Bounds, System.Drawing.Color.White, TextFormatFlags.GlyphOverhangPadding);
            }
        }

        private void treeViewMenu_AfterSelect(object? sender, TreeViewEventArgs e)
        {

            string selectedNode = e.Node?.Text.Trim();
            panelMainContent?.Controls.Clear();

            UserControl controlToLoad = null;

            switch (selectedNode)
            {
                // HỆ THỐNG
                case "Trang chủ":
                    controlToLoad = new TrangChuControl();
                    break;
                case "Đăng xuất":
                    // Thực hiện đăng xuất
                    Application.Restart(); // hoặc load lại form Login
                    return;
                case "Tắt phần mềm":
                    Application.Exit();
                    return;

                // TÍNH TIỀN
                case "Tính tiền đơn hàng":
                    controlToLoad = new TinhTienDonHangControl();
                    break;
                case "Nhập hàng":
                    controlToLoad = new NhapHangControl();
                    break;
                case "Xuất hàng":
                    controlToLoad = new XuatHangControl();
                    break;
                case "Khách hàng":
                    controlToLoad = new KhachHangControl();
                    break;
                case "Thẻ khách hàng":
                    controlToLoad = new TheKhachHangControl();
                    break;

                // CHĂM SÓC KHÁCH HÀNG
                case "Gửi tin nhắn":
                    controlToLoad = new GuiTinNhanControl();
                    break;
                case "Danh sách tin nhắn":
                    controlToLoad = new DanhSachTinNhanControl();
                    break;

                // HỒ SƠ CÁ NHÂN
                case "Thời khoá biểu":
                    controlToLoad = new ThoiKhoaBieuControl();
                    break;
                case "Đổi mật khẩu":
                    controlToLoad = new DoiMatKhauControl();
                    break;
                case "Giờ làm việc":
                    controlToLoad = new GioLamViecControl();
                    break;

                // NHÂN VIÊN
                case "Lịch làm việc":
                    controlToLoad = new LichLamViecControl();
                    break;
                case "Kiểm tra nhân viên":
                    controlToLoad = new KiemTraNhanVienControl();
                    break;
                case "Thống kê nhân viên":
                    controlToLoad = new ThongKeNhanVienControl();
                    break;

                // QUẢN LÝ > BÁN HÀNG
                case "Tìm hoá đơn":
                    controlToLoad = new TimHoaDonControl();
                    break;
                case "Danh sách hoá đơn":
                    controlToLoad = new DanhSachHoaDonControl();
                    break;
                case "Kiểm tra két tiền":
                    controlToLoad = new KiemTraKetTienControl();
                    break;
                case "Liệt kê tổng thu":
                    controlToLoad = new LietKeTongThuControl();
                    break;
                case "Hàng bán chạy":
                    controlToLoad = new HangBanChayControl();
                    break;

                // QUẢN LÝ > KHO HÀNG
                case "Lịch sử nhập":
                    controlToLoad = new LichSuNhapControl();
                    break;
                case "Lịch sử xuất":
                    controlToLoad = new LichSuXuatControl();
                    break;
                case "Kiểm kê kho":
                    controlToLoad = new KiemKeKhoControl();
                    break;
                case "Sao lưu dữ liệu":
                    controlToLoad = new SaoLuuControl();
                    break;
                case "Xuất dữ liệu":
                    controlToLoad = new XuatDuLieuControl();
                    break;

                // QUẢN LÝ > KHÁCH HÀNG / USERS
                case "Quản lý/Khách hàng":
                    controlToLoad = new QuanLyKhachHangControl();
                    break;
                case "Users (người dùng)":
                    controlToLoad = new QuanLyUsersControl();
                    break;

                // SẢN PHẨM
                case "Phiếu giảm giá":
                    controlToLoad = new PhieuGiamGiaControl();
                    break;
                case "Hàng hoá":
                    controlToLoad = new HangHoaControl();
                    break;
                case "Hạ giá":
                    controlToLoad = new HaGiaControl();
                    break;
                case "Thuế khoá":
                    controlToLoad = new ThueKhoaControl();
                    break;

                // CÀI ĐẶT
                case "Thông tin Công ty":
                    controlToLoad = new ThongTinCongTyControl();
                    break;
                case "Thiết bị ngoại vi":
                    controlToLoad = new ThietBiControl();
                    break;
                case "Đổi tiền tệ":
                    controlToLoad = new DoiTienTeControl();
                    break;
                case "Admin":
                    controlToLoad = new AdminControl();
                    break;

                // CHỈ DẪN (HELP)
                case "Kết nối với cân":
                    controlToLoad = new KetNoiCanControl();
                    break;
                case "Trợ giúp từ xa":
                    controlToLoad = new TroGiupTuXaControl();
                    break;
                case "Version":
                    controlToLoad = new VersionControl();
                    break;
            }

            if (controlToLoad != null)
            {
                controlToLoad.Dock = DockStyle.Fill;
                panelMainContent?.Controls.Add(controlToLoad);
            }
        }



        private void SetupUI()
        {
            // Ẩn các panel nếu có
            HideAllPanels();

            // Hiển thị thông tin người dùng
            lblUsername.Text = "Tài khoản: " + UserSession.Id;
            lblRole.Text = "Vai trò: " + UserSession.Role;

            // Phân quyền menu
            SetupMenuPermissions();
        }

        private void SetupMenuPermissions()
        {
            // Nếu không phải Admin thì ẩn các mục chỉ dành cho Admin
            if (UserSession.Role != "Admin")
            {
                btnManagement.Visible = false;
                btnSettings.Visible = false;
                btnStaff.Visible = false;
            }
        }
        private void LoadMenu()
        {
            TreeNode rootLogin = new TreeNode("Login");

            TreeNode heThong = new TreeNode("Hệ thống");
            heThong.Nodes.Add("Trang chủ");
            heThong.Nodes.Add("Đăng xuất");
            heThong.Nodes.Add("Tắt phần mềm");

            TreeNode tinhTien = new TreeNode("Tính tiền");
            tinhTien.Nodes.Add("Tính tiền đơn hàng");
            tinhTien.Nodes.Add("Nhập hàng");
            tinhTien.Nodes.Add("Xuất hàng");
            tinhTien.Nodes.Add("Khách hàng");
            tinhTien.Nodes.Add("Thẻ khách hàng");

            TreeNode chamSoc = new TreeNode("Chăm sóc khách hàng");
            chamSoc.Nodes.Add("Gửi tin nhắn");
            chamSoc.Nodes.Add("Danh sách tin nhắn");

            TreeNode hoSo = new TreeNode("Hồ sơ cá nhân");
            hoSo.Nodes.Add("Thời khoá biểu");
            hoSo.Nodes.Add("Đổi mật khẩu");
            hoSo.Nodes.Add("Giờ làm việc");

            TreeNode nhanVien = new TreeNode("Nhân viên");
            nhanVien.Nodes.Add("Lịch làm việc");
            nhanVien.Nodes.Add("Kiểm tra nhân viên");
            nhanVien.Nodes.Add("Thống kê nhân viên");

            TreeNode quanLy = new TreeNode("Quản lý");

            TreeNode banHang = new TreeNode("Bán hàng");
            banHang.Nodes.Add("Tìm hoá đơn");
            banHang.Nodes.Add("Danh sách hoá đơn");
            banHang.Nodes.Add("Kiểm tra két tiền");
            banHang.Nodes.Add("Liệt kê tổng thu");
            banHang.Nodes.Add("Hàng bán chạy");

            TreeNode khoHang = new TreeNode("Kho hàng");
            khoHang.Nodes.Add("Lịch sử nhập");
            khoHang.Nodes.Add("Lịch sử xuất");
            khoHang.Nodes.Add("Kiểm kê kho");
            khoHang.Nodes.Add("Sao lưu dữ liệu");
            khoHang.Nodes.Add("Xuất dữ liệu");

            quanLy.Nodes.Add(banHang);
            quanLy.Nodes.Add(khoHang);
            quanLy.Nodes.Add("Khách hàng");
            quanLy.Nodes.Add("Users");

            TreeNode sanPham = new TreeNode("Sản phẩm");
            sanPham.Nodes.Add("Phiếu giảm giá");
            sanPham.Nodes.Add("Hàng hoá");
            sanPham.Nodes.Add("Hạ giá");
            sanPham.Nodes.Add("Thuế khoá");

            TreeNode caiDat = new TreeNode("Cài đặt");
            caiDat.Nodes.Add("Thông tin Công ty");
            caiDat.Nodes.Add("Thiết bị ngoại vi");
            caiDat.Nodes.Add("Đổi tiền tệ");
            caiDat.Nodes.Add("Admin");

            TreeNode chiDan = new TreeNode("Chỉ dẫn (Help)");
            chiDan.Nodes.Add("Kết nối với cân");
            chiDan.Nodes.Add("Trợ giúp từ xa");
            chiDan.Nodes.Add("Version");

            rootLogin.Nodes.AddRange(new TreeNode[] {
        heThong, tinhTien, chamSoc, hoSo,
        nhanVien, quanLy, sanPham, caiDat, chiDan
    });

            treeViewMenu.Nodes.Add(rootLogin);
            rootLogin.Expand();
            heThong.Collapse();
            tinhTien.Collapse();
            chamSoc.Collapse();
            hoSo.Collapse();
            nhanVien.Collapse();
            quanLy.Collapse();
            sanPham.Collapse();
            caiDat.Collapse();
            chiDan.Collapse();

        }

        private void HideAllPanels()
        {
            panelMain.Controls.Clear();
        }

        private void LoadControl(UserControl control)
        {
            HideAllPanels();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(new HomeControl()); // cần tạo HomeControl
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadControl(new SalesControl());
        }
        private void btnTinhTienDonHang_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TinhTienDonHangControl tinhTienControl = new TinhTienDonHangControl();  // <-- kiểm tra đúng tên và class chưa
            tinhTienControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(tinhTienControl);
        }

        private void btnCustomerCare_Click(object sender, EventArgs e)
        {
            LoadControl(new CustomerCareControl()); // cần tạo
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadControl(new ProfileControl()); // cần tạo
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            LoadControl(new StaffControl()); // cần tạo
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            LoadControl(new ManagementControl()); // cần tạo
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadControl(new ProductsControl()); // cần tạo
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl()); // cần tạo
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            LoadControl(new HelpControl()); // cần tạo
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        // ... tiếp tục cho các nút khác

    }
}
