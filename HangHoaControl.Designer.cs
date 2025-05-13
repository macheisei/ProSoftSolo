namespace ProSoft.Controls
{
    partial class HangHoaControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            tabProductFindEdit = new TabControl();
            tabProductInfo = new TabPage();
            pictureBoxProduct = new PictureBox();
            txtProductCode = new TextBox();
            label1 = new Label();
            lblQuInventory = new Label();
            lblHSD = new Label();
            lblProductUnit = new Label();
            lblProductWV = new Label();
            lblBuypriceNotax = new Label();
            lblProductBuyPrice = new Label();
            lblSellpriceNotax = new Label();
            lblProductSellPrice = new Label();
            lblProductName = new Label();
            lblCategory = new Label();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            txtProductName = new TextBox();
            ComboBoxCategory = new ComboBox();
            ComboBoxProductUnit = new ComboBox();
            txtProductSellPrice = new TextBox();
            txtSellpriceNotax = new TextBox();
            txtProductBuyPrice = new TextBox();
            txtBuypriceNotax = new TextBox();
            txtProductWV = new TextBox();
            DateTimeControlHSD = new DateTimePicker();
            txtQuInventory = new TextBox();
            btnFresh = new Button();
            btnSaveProduct = new Button();
            btnPrintLabelPrice = new Button();
            tabPage2 = new TabPage();
            btnEditProductRow = new Button();
            btnDeleteProduct = new Button();
            lblProductFind = new Label();
            txtProductFind = new TextBox();
            dataGridViewProductFind = new DataGridView();
            btnSaveEditProduct = new Button();
            lblPrice = new Label();
            lblExpiryDate = new Label();
            tabProductFindEdit.SuspendLayout();
            tabProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductFind).BeginInit();
            SuspendLayout();
            // 
            // tabProductFindEdit
            // 
            tabProductFindEdit.Controls.Add(tabProductInfo);
            tabProductFindEdit.Controls.Add(tabPage2);
            tabProductFindEdit.Dock = DockStyle.Fill;
            tabProductFindEdit.Location = new Point(0, 0);
            tabProductFindEdit.Name = "tabProductFindEdit";
            tabProductFindEdit.SelectedIndex = 0;
            tabProductFindEdit.Size = new Size(700, 469);
            tabProductFindEdit.TabIndex = 0;
            // 
            // tabProductInfo
            // 
            tabProductInfo.Controls.Add(pictureBoxProduct);
            tabProductInfo.Controls.Add(txtProductCode);
            tabProductInfo.Controls.Add(label1);
            tabProductInfo.Controls.Add(lblQuInventory);
            tabProductInfo.Controls.Add(lblHSD);
            tabProductInfo.Controls.Add(lblProductUnit);
            tabProductInfo.Controls.Add(lblProductWV);
            tabProductInfo.Controls.Add(lblBuypriceNotax);
            tabProductInfo.Controls.Add(lblProductBuyPrice);
            tabProductInfo.Controls.Add(lblSellpriceNotax);
            tabProductInfo.Controls.Add(lblProductSellPrice);
            tabProductInfo.Controls.Add(lblProductName);
            tabProductInfo.Controls.Add(lblCategory);
            tabProductInfo.Controls.Add(lblBarcode);
            tabProductInfo.Controls.Add(txtBarcode);
            tabProductInfo.Controls.Add(txtProductName);
            tabProductInfo.Controls.Add(ComboBoxCategory);
            tabProductInfo.Controls.Add(ComboBoxProductUnit);
            tabProductInfo.Controls.Add(txtProductSellPrice);
            tabProductInfo.Controls.Add(txtSellpriceNotax);
            tabProductInfo.Controls.Add(txtProductBuyPrice);
            tabProductInfo.Controls.Add(txtBuypriceNotax);
            tabProductInfo.Controls.Add(txtProductWV);
            tabProductInfo.Controls.Add(DateTimeControlHSD);
            tabProductInfo.Controls.Add(txtQuInventory);
            tabProductInfo.Controls.Add(btnFresh);
            tabProductInfo.Controls.Add(btnSaveProduct);
            tabProductInfo.Controls.Add(btnPrintLabelPrice);
            tabProductInfo.Location = new Point(4, 24);
            tabProductInfo.Name = "tabProductInfo";
            tabProductInfo.Padding = new Padding(3);
            tabProductInfo.Size = new Size(692, 441);
            tabProductInfo.TabIndex = 0;
            tabProductInfo.Text = "THÔNG TIN SP";
            tabProductInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(471, 167);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(169, 142);
            pictureBoxProduct.TabIndex = 16;
            pictureBoxProduct.TabStop = false;
            pictureBoxProduct.Click += pictureBox1_Click;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(22, 44);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(122, 23);
            txtProductCode.TabIndex = 15;
            // 
            // label1
            // 
            label1.Location = new Point(22, 19);
            label1.Name = "label1";
            label1.Size = new Size(88, 22);
            label1.TabIndex = 14;
            label1.Text = "Mã sản phẩm";
            // 
            // lblQuInventory
            // 
            lblQuInventory.Location = new Point(22, 222);
            lblQuInventory.Name = "lblQuInventory";
            lblQuInventory.Size = new Size(112, 22);
            lblQuInventory.TabIndex = 10;
            lblQuInventory.Text = "Số lượng tồn kho";
            // 
            // lblHSD
            // 
            lblHSD.Location = new Point(136, 222);
            lblHSD.Name = "lblHSD";
            lblHSD.Size = new Size(88, 22);
            lblHSD.TabIndex = 9;
            lblHSD.Text = "Hạn sử dụng";
            // 
            // lblProductUnit
            // 
            lblProductUnit.Location = new Point(136, 149);
            lblProductUnit.Name = "lblProductUnit";
            lblProductUnit.Size = new Size(88, 22);
            lblProductUnit.TabIndex = 8;
            lblProductUnit.Text = "Đơn vị tính";
            // 
            // lblProductWV
            // 
            lblProductWV.Location = new Point(22, 149);
            lblProductWV.Name = "lblProductWV";
            lblProductWV.Size = new Size(108, 22);
            lblProductWV.TabIndex = 7;
            lblProductWV.Text = "Giá trị đo lường";
            // 
            // lblBuypriceNotax
            // 
            lblBuypriceNotax.Location = new Point(284, 303);
            lblBuypriceNotax.Name = "lblBuypriceNotax";
            lblBuypriceNotax.Size = new Size(122, 22);
            lblBuypriceNotax.TabIndex = 6;
            lblBuypriceNotax.Text = "Giá mua không thuế";
            // 
            // lblProductBuyPrice
            // 
            lblProductBuyPrice.Location = new Point(284, 222);
            lblProductBuyPrice.Name = "lblProductBuyPrice";
            lblProductBuyPrice.Size = new Size(88, 22);
            lblProductBuyPrice.TabIndex = 5;
            lblProductBuyPrice.Text = "Giá mua";
            // 
            // lblSellpriceNotax
            // 
            lblSellpriceNotax.Location = new Point(282, 149);
            lblSellpriceNotax.Name = "lblSellpriceNotax";
            lblSellpriceNotax.Size = new Size(124, 22);
            lblSellpriceNotax.TabIndex = 4;
            lblSellpriceNotax.Text = "Giá bán không thuế";
            // 
            // lblProductSellPrice
            // 
            lblProductSellPrice.Location = new Point(564, 85);
            lblProductSellPrice.Name = "lblProductSellPrice";
            lblProductSellPrice.Size = new Size(88, 22);
            lblProductSellPrice.TabIndex = 3;
            lblProductSellPrice.Text = "Giá bán";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(255, 85);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(83, 15);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên sản phẩm:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(150, 85);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(74, 15);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Nhóm hàng:";
            // 
            // lblBarcode
            // 
            lblBarcode.Location = new Point(22, 85);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(88, 22);
            lblBarcode.TabIndex = 0;
            lblBarcode.Text = "EAN sản phẩm";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(22, 110);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(122, 23);
            txtBarcode.TabIndex = 0;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(255, 110);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(303, 23);
            txtProductName.TabIndex = 3;
            // 
            // ComboBoxCategory
            // 
            ComboBoxCategory.FormattingEnabled = true;
            ComboBoxCategory.Location = new Point(150, 110);
            ComboBoxCategory.Name = "ComboBoxCategory";
            ComboBoxCategory.Size = new Size(99, 23);
            ComboBoxCategory.TabIndex = 1;
            // 
            // ComboBoxProductUnit
            // 
            ComboBoxProductUnit.FormattingEnabled = true;
            ComboBoxProductUnit.Location = new Point(136, 174);
            ComboBoxProductUnit.Name = "ComboBoxProductUnit";
            ComboBoxProductUnit.Size = new Size(88, 23);
            ComboBoxProductUnit.TabIndex = 2;
            // 
            // txtProductSellPrice
            // 
            txtProductSellPrice.Location = new Point(564, 110);
            txtProductSellPrice.Name = "txtProductSellPrice";
            txtProductSellPrice.Size = new Size(114, 23);
            txtProductSellPrice.TabIndex = 4;
            // 
            // txtSellpriceNotax
            // 
            txtSellpriceNotax.Location = new Point(284, 174);
            txtSellpriceNotax.Name = "txtSellpriceNotax";
            txtSellpriceNotax.Size = new Size(124, 23);
            txtSellpriceNotax.TabIndex = 5;
            // 
            // txtProductBuyPrice
            // 
            txtProductBuyPrice.Location = new Point(284, 247);
            txtProductBuyPrice.Name = "txtProductBuyPrice";
            txtProductBuyPrice.Size = new Size(124, 23);
            txtProductBuyPrice.TabIndex = 6;
            // 
            // txtBuypriceNotax
            // 
            txtBuypriceNotax.Location = new Point(284, 328);
            txtBuypriceNotax.Name = "txtBuypriceNotax";
            txtBuypriceNotax.Size = new Size(124, 23);
            txtBuypriceNotax.TabIndex = 7;
            // 
            // txtProductWV
            // 
            txtProductWV.Location = new Point(22, 174);
            txtProductWV.Name = "txtProductWV";
            txtProductWV.Size = new Size(84, 23);
            txtProductWV.TabIndex = 8;
            // 
            // DateTimeControlHSD
            // 
            DateTimeControlHSD.CustomFormat = "dd.MM.yyyy";
            DateTimeControlHSD.Format = DateTimePickerFormat.Custom;
            DateTimeControlHSD.Location = new Point(136, 247);
            DateTimeControlHSD.Name = "DateTimeControlHSD";
            DateTimeControlHSD.Size = new Size(119, 23);
            DateTimeControlHSD.TabIndex = 9;
            // 
            // txtQuInventory
            // 
            txtQuInventory.Location = new Point(22, 247);
            txtQuInventory.Name = "txtQuInventory";
            txtQuInventory.Size = new Size(84, 23);
            txtQuInventory.TabIndex = 10;
            // 
            // btnFresh
            // 
            btnFresh.Location = new Point(146, 372);
            btnFresh.Name = "btnFresh";
            btnFresh.Size = new Size(105, 38);
            btnFresh.TabIndex = 11;
            btnFresh.Text = "Làm mới";
            btnFresh.UseVisualStyleBackColor = true;
            btnFresh.Click += btnFresh_Click;
            // 
            // btnSaveProduct
            // 
            btnSaveProduct.Location = new Point(303, 372);
            btnSaveProduct.Name = "btnSaveProduct";
            btnSaveProduct.Size = new Size(105, 38);
            btnSaveProduct.TabIndex = 12;
            btnSaveProduct.Text = "Lưu sản phẩm";
            btnSaveProduct.UseVisualStyleBackColor = true;
            btnSaveProduct.Click += btnSaveProduct_Click;
            // 
            // btnPrintLabelPrice
            // 
            btnPrintLabelPrice.Location = new Point(455, 372);
            btnPrintLabelPrice.Name = "btnPrintLabelPrice";
            btnPrintLabelPrice.Size = new Size(105, 38);
            btnPrintLabelPrice.TabIndex = 13;
            btnPrintLabelPrice.Text = "In nhãn giá";
            btnPrintLabelPrice.UseVisualStyleBackColor = true;
            btnPrintLabelPrice.Click += btnPrintLabelPrice_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnEditProductRow);
            tabPage2.Controls.Add(btnDeleteProduct);
            tabPage2.Controls.Add(lblProductFind);
            tabPage2.Controls.Add(txtProductFind);
            tabPage2.Controls.Add(dataGridViewProductFind);
            tabPage2.Controls.Add(btnSaveEditProduct);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(692, 441);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "TÌM KIẾM/CHỈNH SỬA SP";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEditProductRow
            // 
            btnEditProductRow.Location = new Point(116, 389);
            btnEditProductRow.Name = "btnEditProductRow";
            btnEditProductRow.Size = new Size(130, 40);
            btnEditProductRow.TabIndex = 5;
            btnEditProductRow.Text = "Chỉnh sửa dữ liệu";
            btnEditProductRow.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(461, 390);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(120, 38);
            btnDeleteProduct.TabIndex = 4;
            btnDeleteProduct.Text = "Xoá sản phẩm";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // lblProductFind
            // 
            lblProductFind.Location = new Point(61, 21);
            lblProductFind.Name = "lblProductFind";
            lblProductFind.Size = new Size(88, 22);
            lblProductFind.TabIndex = 3;
            lblProductFind.Text = "Tìm sản phẩm:";
            // 
            // txtProductFind
            // 
            txtProductFind.Location = new Point(177, 18);
            txtProductFind.Name = "txtProductFind";
            txtProductFind.Size = new Size(454, 23);
            txtProductFind.TabIndex = 0;
            txtProductFind.TextChanged += txtProductFind_TextChanged;
            // 
            // dataGridViewProductFind
            // 
            dataGridViewProductFind.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductFind.Location = new Point(18, 56);
            dataGridViewProductFind.Name = "dataGridViewProductFind";
            dataGridViewProductFind.RowHeadersWidth = 51;
            dataGridViewProductFind.RowTemplate.Height = 24;
            dataGridViewProductFind.Size = new Size(656, 328);
            dataGridViewProductFind.TabIndex = 1;
            // 
            // btnSaveEditProduct
            // 
            btnSaveEditProduct.Location = new Point(291, 389);
            btnSaveEditProduct.Name = "btnSaveEditProduct";
            btnSaveEditProduct.Size = new Size(131, 38);
            btnSaveEditProduct.TabIndex = 2;
            btnSaveEditProduct.Text = "Lưu chỉnh sửa";
            btnSaveEditProduct.UseVisualStyleBackColor = true;
            btnSaveEditProduct.Click += btnEditProductRow_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(150, 20);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(45, 13);
            lblPrice.TabIndex = 0;
            lblPrice.Text = "Giá bán:";
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Location = new Point(150, 240);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(78, 13);
            lblExpiryDate.TabIndex = 0;
            lblExpiryDate.Text = "Hạn sử dụng:";
            // 
            // HangHoaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabProductFindEdit);
            Name = "HangHoaControl";
            Size = new Size(700, 469);
            tabProductFindEdit.ResumeLayout(false);
            tabProductInfo.ResumeLayout(false);
            tabProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductFind).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabProductFindEdit;
        private System.Windows.Forms.TabPage tabProductInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
        private System.Windows.Forms.ComboBox ComboBoxProductUnit;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductSellPrice;
        private System.Windows.Forms.TextBox txtSellpriceNotax;
        private System.Windows.Forms.TextBox txtProductBuyPrice;
        private System.Windows.Forms.TextBox txtBuypriceNotax;
        private System.Windows.Forms.TextBox txtProductWV;
        private System.Windows.Forms.DateTimePicker DateTimeControlHSD;
        private System.Windows.Forms.TextBox txtQuInventory;
        private System.Windows.Forms.Button btnFresh;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.Button btnPrintLabelPrice;

        private System.Windows.Forms.TextBox txtProductFind;
        private System.Windows.Forms.DataGridView dataGridViewProductFind;
        private System.Windows.Forms.Button btnSaveEditProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private Label lblBarcode;
        private Label lblProductSellPrice;
        private Label lblSellpriceNotax;
        private Label lblProductBuyPrice;
        private Label lblBuypriceNotax;
        private Label lblProductWV;
        private Label lblProductUnit;
        private Label lblHSD;
        private Label lblQuInventory;
        private Label lblProductFind;
        
        private Label label1;
        private Button btnEditProductRow;
        private PictureBox pictureBoxProduct;
    }
}
