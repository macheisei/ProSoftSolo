namespace ProSoft.Forms
{
    partial class ProductDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboCategory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            this.lblName.Text = "Tên sản phẩm:";
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Size = new System.Drawing.Size(100, 23);
            // 
            // txtName
            this.txtName.Location = new System.Drawing.Point(140, 30);
            this.txtName.Size = new System.Drawing.Size(250, 23);
            // 
            // lblBarcode
            this.lblBarcode.Text = "Mã vạch:";
            this.lblBarcode.Location = new System.Drawing.Point(30, 65);
            this.lblBarcode.Size = new System.Drawing.Size(100, 23);
            // 
            // txtBarcode
            this.txtBarcode.Location = new System.Drawing.Point(140, 65);
            this.txtBarcode.Size = new System.Drawing.Size(250, 23);
            // 
            // lblCost
            this.lblCost.Text = "Giá vốn:";
            this.lblCost.Location = new System.Drawing.Point(30, 100);
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            // 
            // txtCost
            this.txtCost.Location = new System.Drawing.Point(140, 100);
            this.txtCost.Size = new System.Drawing.Size(250, 23);
            // 
            // lblPrice
            this.lblPrice.Text = "Giá bán:";
            this.lblPrice.Location = new System.Drawing.Point(30, 135);
            this.lblPrice.Size = new System.Drawing.Size(100, 23);
            // 
            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(140, 135);
            this.txtPrice.Size = new System.Drawing.Size(250, 23);
            // 
            // lblStock
            this.lblStock.Text = "Tồn kho:";
            this.lblStock.Location = new System.Drawing.Point(30, 170);
            this.lblStock.Size = new System.Drawing.Size(100, 23);
            // 
            // txtStock
            this.txtStock.Location = new System.Drawing.Point(140, 170);
            this.txtStock.Size = new System.Drawing.Size(250, 23);
            // 
            // lblDescription
            this.lblDescription.Text = "Mô tả:";
            this.lblDescription.Location = new System.Drawing.Point(30, 205);
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            // 
            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(140, 205);
            this.txtDescription.Size = new System.Drawing.Size(250, 60);
            this.txtDescription.Multiline = true;
            // 
            // lblCategory
            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.Location = new System.Drawing.Point(30, 275);
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            // 
            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(140, 275);
            this.cmbCategory.Size = new System.Drawing.Size(250, 23);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.Controls.Add(this.cboCategory);

            // Cấu hình thuộc tính cơ bản (có thể tùy chỉnh thêm)
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(130, 220); // chỉnh lại vị trí cho phù hợp
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 24);
            // 
            // chkActive
            this.chkActive.Text = "Đang hoạt động";
            this.chkActive.Location = new System.Drawing.Point(140, 310);
            this.chkActive.Size = new System.Drawing.Size(150, 24);
            // 
            // btnSave
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(140, 350);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new System.Drawing.Point(290, 350);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // ProductDetailForm
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 420);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "ProductDetailForm";
            this.Text = "Chi tiết sản phẩm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
