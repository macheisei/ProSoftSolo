namespace ProSoft.Forms
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
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
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();

            // 
            // dgvInvoices
            // 
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(20, 20); // Vị trí tùy chỉnh
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.Size = new System.Drawing.Size(760, 400); // Kích thước tùy chỉnh
            this.dgvInvoices.TabIndex = 0;

            // 
            // InvoiceForm
            // 
            this.Controls.Add(this.dgvInvoices);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();


            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTo.Location = new System.Drawing.Point(300, 20); // chỉnh lại vị trí nếu cần
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 23);
            this.Controls.Add(this.dtpTo);

            this.dtpFrom = new System.Windows.Forms.DateTimePicker();

            this.dtpFrom.Location = new System.Drawing.Point(100, 30);
            this.dtpFrom.Size = new System.Drawing.Size(200, 23);
            this.dtpFrom.Name = "dtpFrom";

            this.Controls.Add(this.dtpFrom);
        }

        #endregion
    }
}