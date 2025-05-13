using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProSoft.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit1;

        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.TreeView treeViewMenu;



        private void InitializeComponent()
        {
            panelMainContent = new Panel();
            treeViewMenu = new TreeView();
            panelMain = new Panel();
            panelTop = new Panel();
            lblTitle = new Label();
            lblUsername = new Label();
            lblRole = new Label();
            panelBottom = new Panel();
            btnLogout = new Button();
            btnExit1 = new Button();
            btnManagement = new Button();
            btnSettings = new Button();
            btnStaff = new Button();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(200, 40);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(800, 520);
            panelMainContent.TabIndex = 1;
            // 
            // treeViewMenu
            // 
            treeViewMenu.Dock = DockStyle.Left;
            treeViewMenu.Location = new Point(0, 40);
            treeViewMenu.Name = "treeViewMenu";
            treeViewMenu.Size = new Size(200, 520);
            treeViewMenu.TabIndex = 0;
            treeViewMenu.AfterSelect += treeViewMenu_AfterSelect;
            // 
            // panelMain
            // 
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 40);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1000, 520);
            panelMain.TabIndex = 2;
            // 
            // panelTop
            // 
            panelTop.BackColor = System.Drawing.Color.LightGray;
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblUsername);
            panelTop.Controls.Add(lblRole);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 40);
            panelTop.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(140, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MainForm Designer";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Right;
            lblUsername.Location = new Point(1100, 10);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "100";
            // 
            // lblRole
            // 
            lblRole.Anchor = AnchorStyles.Right;
            lblRole.Location = new Point(1100, 10);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 23);
            lblRole.TabIndex = 2;
            lblRole.Text = "Admin";
            // 
            // panelBottom
            // 
            panelBottom.BackColor = System.Drawing.Color.Black;
            panelBottom.Controls.Add(btnLogout);
            panelBottom.Controls.Add(btnExit1);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 560);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1000, 40);
            panelBottom.TabIndex = 3;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.Location = new Point(12, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(96, 23);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "ĐĂNG XUẤT";
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit1
            // 
            btnExit1.FlatStyle = FlatStyle.Flat;
            btnExit1.ForeColor = System.Drawing.Color.White;
            btnExit1.Location = new Point(114, 6);
            btnExit1.Name = "btnExit1";
            btnExit1.Size = new Size(91, 23);
            btnExit1.TabIndex = 1;
            btnExit1.Text = "THOÁT";
            btnExit1.Click += btnExit1_Click;
            // 
            // btnManagement
            // 
            btnManagement.Location = new Point(0, 0);
            btnManagement.Name = "btnManagement";
            btnManagement.Size = new Size(75, 23);
            btnManagement.TabIndex = 0;
            btnManagement.Text = "Quản lý";
            btnManagement.Click += btnManagement_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(0, 0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 23);
            btnSettings.TabIndex = 0;
            // 
            // btnStaff
            // 
            btnStaff.Location = new Point(0, 0);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(75, 23);
            btnStaff.TabIndex = 0;
            // 
            // MainForm
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(panelMainContent);
            Controls.Add(treeViewMenu);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProSoft POS";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
            // ... thêm vào Controls collection

            // ...

        }
        private Button CreateSidebarButton(string text, EventHandler clickHandler)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.Height = 40;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = System.Drawing.Color.White;
            btn.BackColor = System.Drawing.Color.Black;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.Click += clickHandler;
            return btn;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
