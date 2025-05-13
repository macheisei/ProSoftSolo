namespace ProSoft.Forms
{
    partial class InvoiceDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotal;

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
            SuspendLayout();
            // 
            // InvoiceDetailForm
            // 
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();

            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(30, 30);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(120, 20);
            this.lblInvoiceNumber.Text = "Số hóa đơn: HD001";

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(30, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(110, 20);
            this.lblDate.Text = "Ngày: 22/04/2025";

            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(30, 90);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(130, 20);
            this.lblCustomer.Text = "Khách hàng: Nguyễn Văn A";

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(30, 120);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(130, 20);
            this.lblPhone.Text = "SĐT: 0909 999 999";

            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(30, 150);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(120, 20);
            this.lblPoints.Text = "Điểm tích lũy: 120";

            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(30, 180);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(170, 20);
            this.lblPaymentMethod.Text = "Thanh toán: Tiền mặt";

            // Add controls to the form
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblPaymentMethod);

            this.dgvDetails = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();

            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(20, 150); // điều chỉnh vị trí cho phù hợp
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(600, 250);
            this.dgvDetails.TabIndex = 0;

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.Controls.Add(this.dgvDetails);
            // lblAddress
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddress.Location = new System.Drawing.Point(20, 80);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(400, 23);
            this.lblAddress.Text = "Địa chỉ khách hàng";
            this.Controls.Add(this.lblAddress);

            // lblCashier
            this.lblCashier = new System.Windows.Forms.Label();
            this.lblCashier.Location = new System.Drawing.Point(20, 100);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(200, 23);
            this.lblCashier.Text = "Thu ngân: ";
            this.Controls.Add(this.lblCashier);

            // lblSubTotal
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblSubTotal.Location = new System.Drawing.Point(20, 360);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(200, 23);
            this.lblSubTotal.Text = "Tạm tính: ";
            this.Controls.Add(this.lblSubTotal);

            // lblTax
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTax.Location = new System.Drawing.Point(20, 380);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(200, 23);
            this.lblTax.Text = "Thuế: ";
            this.Controls.Add(this.lblTax);

            // lblTotal
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal.Location = new System.Drawing.Point(20, 400);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 23);
            this.lblTotal.Text = "Tổng cộng: ";
            this.Controls.Add(this.lblTotal);

        }

        #endregion
    }
}