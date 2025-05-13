using System.Windows.Forms;
using System.Drawing;

namespace ProSoft.Controls
{
    public partial class HomeControl : UserControl
    {
        public HomeControl() // Thiếu dấu ngoặc đóng ()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Thêm các control khác nếu cần
            Label lblWelcome = new Label();
            lblWelcome.Text = "Chào mừng đến với ProSoft";
            lblWelcome.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblWelcome.ForeColor = System.Drawing.Color.SteelBlue;
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Padding = new Padding(10);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lblWelcome);
        }
        private void SetupDashboard()
        {
            // Tạo panel chứa các thống kê nhanh
            Panel statsPanel = new Panel();
            statsPanel.Dock = DockStyle.Top;
            statsPanel.Height = 100;
            statsPanel.BackColor = System.Drawing.Color.White;
            statsPanel.Padding = new Padding(10);

            // Thêm các thống kê
            AddStatBox(statsPanel, "Doanh thu hôm nay", "12,450,000 VND", 0);
            AddStatBox(statsPanel, "Đơn hàng mới", "15", 1);
            AddStatBox(statsPanel, "Cảnh báo tồn kho", "3", 2);

            this.Controls.Add(statsPanel);
        }

        private void AddStatBox(Panel parent, string title, string value, int index)
        {
            Panel box = new Panel();
            box.Width = 200;
            box.Height = 80;
            box.BackColor = System.Drawing.Color.SteelBlue;
            box.ForeColor = System.Drawing.Color.White;
            box.Location = new Point(10 + (210 * index), 10);

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Location = new Point(10, 10);

            Label valueLabel = new Label();
            valueLabel.Text = value;
            valueLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            valueLabel.Location = new Point(10, 35);

            box.Controls.Add(titleLabel);
            box.Controls.Add(valueLabel);
            parent.Controls.Add(box);
        }
    }
}