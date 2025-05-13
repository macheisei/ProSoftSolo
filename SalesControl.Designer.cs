namespace ProSoft.Controls
{
    partial class SalesControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cboPaymentMethod;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // dgvCart
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(20, 220);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(600, 200);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.Columns.Add("ProductID", "Mã SP");
            this.dgvCart.Columns.Add("ProductName", "Tên sản phẩm");
            this.dgvCart.Columns.Add("Price", "Đơn giá");
            this.dgvCart.Columns.Add("Quantity", "Số lượng");
            this.dgvCart.Columns.Add("Total", "Thành tiền");

            // dgvProducts
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(20, 10);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(600, 150);
            this.dgvProducts.TabIndex = 1;

            // btnAddToCart
            this.btnAddToCart.Location = new System.Drawing.Point(20, 170);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(120, 30);
            this.btnAddToCart.Text = "Thêm vào giỏ";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            // btnCheckout
            this.btnCheckout.Location = new System.Drawing.Point(500, 430);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(120, 30);
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // lblSubtotal
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(20, 440);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(60, 15);
            this.lblSubtotal.Text = "Tạm tính: 0";

            // lblTax
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(20, 460);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(51, 15);
            this.lblTax.Text = "Thuế: 0";

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(73, 19);
            this.lblTotal.Text = "Tổng: 0";

            // cboPaymentMethod
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ" });
            this.cboPaymentMethod.Location = new System.Drawing.Point(400, 430);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(90, 23);

            // SalesControl1
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cboPaymentMethod);
            this.Name = "SalesControl";
            this.Size = new System.Drawing.Size(650, 510);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
