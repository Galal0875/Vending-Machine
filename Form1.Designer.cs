namespace VendingMachine___Badr_Almashrea___30139708
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Panel panelCart;
        private System.Windows.Forms.Panel panelPayment;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelCoins;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTitles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTop;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.PictureBox picLogo;

        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutProducts;

        private System.Windows.Forms.Label lblCartTitle;
        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblItemsCount;

        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.PictureBox picCoinSlot;
        private System.Windows.Forms.Label lblCoinSlot;
        private System.Windows.Forms.PictureBox picTrash;
        private System.Windows.Forms.Label lblTrash;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ProgressBar progressPayment;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            // Main Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1280, 820);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Premium Vending Machine";

            // Header Panel
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tableLayoutTitles = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Size = new System.Drawing.Size(1280, 80);
            this.panelHeader.TabIndex = 0;

            // Titles Layout
            this.tableLayoutTitles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutTitles.ColumnCount = 2;
            this.tableLayoutTitles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTitles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTitles.Location = new System.Drawing.Point(20, 90);
            this.tableLayoutTitles.RowCount = 1;
            this.tableLayoutTitles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTitles.Size = new System.Drawing.Size(1240, 35);
            this.tableLayoutTitles.TabIndex = 5;

            // Top Layout
            this.tableLayoutTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutTop.ColumnCount = 2;
            this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTop.Location = new System.Drawing.Point(20, 130);
            this.tableLayoutTop.RowCount = 1;
            this.tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTop.Size = new System.Drawing.Size(1240, 360);
            this.tableLayoutTop.TabIndex = 6;

            // Logo
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(20, 10);
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;

            // Title
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(90, 15);
            this.lblTitle.Size = new System.Drawing.Size(350, 32);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "PREMIUM VENDING MACHINE";

            // Student ID
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentId.ForeColor = System.Drawing.Color.White;
            this.lblStudentId.Location = new System.Drawing.Point(92, 50);
            this.lblStudentId.Size = new System.Drawing.Size(250, 20);
            this.lblStudentId.TabIndex = 3;
            this.lblStudentId.Text = "Student: 30139708 - Badr Almashrea";

            // Products Panel
            this.panelProducts = new System.Windows.Forms.Panel();
            this.panelProducts.BackColor = System.Drawing.Color.White;
            this.panelProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProducts.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelProducts.Padding = new System.Windows.Forms.Padding(10);
            this.panelProducts.TabIndex = 4;

            // Products Title
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblProductsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblProductsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblProductsTitle.Size = new System.Drawing.Size(620, 35);
            this.lblProductsTitle.TabIndex = 5;
            this.lblProductsTitle.Text = "🛍️ AVAILABLE PRODUCTS";
            this.lblProductsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Flow Layout for Products
            this.flowLayoutProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.BackColor = System.Drawing.Color.White;
            this.flowLayoutProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutProducts.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutProducts.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutProducts.TabIndex = 6;
            this.flowLayoutProducts.WrapContents = true;

            // Cart Panel
            this.panelCart = new System.Windows.Forms.Panel();
            this.panelCart.BackColor = System.Drawing.Color.White;
            this.panelCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCart.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelCart.Padding = new System.Windows.Forms.Padding(10);
            this.panelCart.TabIndex = 7;

            // Cart Title
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.lblCartTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblCartTitle.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblCartTitle.Size = new System.Drawing.Size(600, 35);
            this.lblCartTitle.TabIndex = 8;
            this.lblCartTitle.Text = "🛒 SHOPPING CART";
            this.lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ListBox for Products
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.listBoxProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.listBoxProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxProducts.Location = new System.Drawing.Point(10, 60);
            this.listBoxProducts.Size = new System.Drawing.Size(560, 196);
            this.listBoxProducts.TabIndex = 9;

            // Total Label
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(10, 270);
            this.lblTotal.Size = new System.Drawing.Size(120, 30);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total: £0.00";

            // Items Count
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsCount.ForeColor = System.Drawing.Color.Gray;
            this.lblItemsCount.Location = new System.Drawing.Point(10, 18);
            this.lblItemsCount.Size = new System.Drawing.Size(70, 19);
            this.lblItemsCount.TabIndex = 11;
            this.lblItemsCount.Text = "Items: 0";

            // Checkout Button
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(10, 310);
            this.btnCheckout.Size = new System.Drawing.Size(240, 40);
            this.btnCheckout.TabIndex = 12;
            this.btnCheckout.Text = "💰 CHECKOUT";
            this.btnCheckout.UseVisualStyleBackColor = false;

            // Cancel Button
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(360, 310);
            this.btnCancel.Size = new System.Drawing.Size(240, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "❌ CANCEL ORDER";
            this.btnCancel.UseVisualStyleBackColor = false;

            // Payment Panel
            this.panelPayment = new System.Windows.Forms.Panel();
            this.panelPayment.BackColor = System.Drawing.Color.White;
            this.panelPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPayment.Location = new System.Drawing.Point(20, 535);
            this.panelPayment.Size = new System.Drawing.Size(1240, 215);
            this.panelPayment.TabIndex = 14;

            // Payment Title
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblPaymentTitle.Location = new System.Drawing.Point(20, 500);
            this.lblPaymentTitle.Size = new System.Drawing.Size(210, 25);
            this.lblPaymentTitle.TabIndex = 15;
            this.lblPaymentTitle.Text = "💳 PAYMENT METHOD";

            // Coins Panel
            this.panelCoins = new System.Windows.Forms.Panel();
            this.panelCoins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelCoins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCoins.Location = new System.Drawing.Point(20, 20);
            this.panelCoins.Size = new System.Drawing.Size(320, 180);
            this.panelCoins.TabIndex = 16;

            // Coin Slot
            this.picCoinSlot = new System.Windows.Forms.PictureBox();
            this.picCoinSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.picCoinSlot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCoinSlot.Location = new System.Drawing.Point(360, 85);
            this.picCoinSlot.Size = new System.Drawing.Size(90, 120);
            this.picCoinSlot.TabIndex = 17;
            this.picCoinSlot.TabStop = false;

            // Coin Slot Label
            this.lblCoinSlot = new System.Windows.Forms.Label();
            this.lblCoinSlot.AutoSize = true;
            this.lblCoinSlot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblCoinSlot.Location = new System.Drawing.Point(350, 55);
            this.lblCoinSlot.Size = new System.Drawing.Size(200, 19);
            this.lblCoinSlot.TabIndex = 18;
            this.lblCoinSlot.Text = "⬇️ DRAG COINS/NOTES HERE";

            // Payment Status
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentStatus.AutoSize = false;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblPaymentStatus.Location = new System.Drawing.Point(470, 90);
            this.lblPaymentStatus.Size = new System.Drawing.Size(620, 24);
            this.lblPaymentStatus.TabIndex = 19;
            this.lblPaymentStatus.Text = "Please add items and click checkout to pay";
            this.lblPaymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Progress Bar
            this.progressPayment = new System.Windows.Forms.ProgressBar();
            this.progressPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPayment.Location = new System.Drawing.Point(470, 125);
            this.progressPayment.Size = new System.Drawing.Size(620, 22);
            this.progressPayment.TabIndex = 20;
            this.progressPayment.Visible = false;

            // Trash
            this.picTrash = new System.Windows.Forms.PictureBox();
            this.picTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picTrash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.picTrash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTrash.Location = new System.Drawing.Point(1130, 100);
            this.picTrash.Size = new System.Drawing.Size(90, 90);
            this.picTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrash.TabIndex = 21;
            this.picTrash.TabStop = false;

            // Trash Label
            this.lblTrash = new System.Windows.Forms.Label();
            this.lblTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrash.AutoSize = true;
            this.lblTrash.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTrash.Location = new System.Drawing.Point(980, 60);
            this.lblTrash.Size = new System.Drawing.Size(250, 19);
            this.lblTrash.TabIndex = 22;
            this.lblTrash.Text = "🗑️ DRAG ITEMS HERE TO REMOVE";

            // Footer Panel
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 760);
            this.panelFooter.Size = new System.Drawing.Size(1280, 60);
            this.panelFooter.TabIndex = 23;

            // Status Label
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(20, 20);
            this.lblStatus.Size = new System.Drawing.Size(150, 19);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Ready to serve you! 👋";

            // Date Time Label
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1090, 20);
            this.lblDateTime.Size = new System.Drawing.Size(70, 15);
            this.lblDateTime.TabIndex = 25;
            this.lblDateTime.Text = "Loading...";

            // Timer for DateTime
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.timerDateTime.Interval = 1000;

            // Add controls to panels
            this.panelProducts.Controls.Add(this.flowLayoutProducts);
            this.panelCart.Controls.Add(this.lblItemsCount);
            this.panelCart.Controls.Add(this.listBoxProducts);
            this.panelCart.Controls.Add(this.lblTotal);
            this.panelCart.Controls.Add(this.btnCheckout);
            this.panelCart.Controls.Add(this.btnCancel);
            this.panelPayment.Controls.Add(this.panelCoins);
            this.panelPayment.Controls.Add(this.picCoinSlot);
            this.panelPayment.Controls.Add(this.lblCoinSlot);
            this.panelPayment.Controls.Add(this.lblPaymentStatus);
            this.panelPayment.Controls.Add(this.progressPayment);
            this.panelPayment.Controls.Add(this.picTrash);
            this.panelPayment.Controls.Add(this.lblTrash);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblStudentId);
            this.panelFooter.Controls.Add(this.lblStatus);
            this.panelFooter.Controls.Add(this.lblDateTime);
            this.tableLayoutTitles.Controls.Add(this.lblProductsTitle, 0, 0);
            this.tableLayoutTitles.Controls.Add(this.lblCartTitle, 1, 0);
            this.tableLayoutTop.Controls.Add(this.panelProducts, 0, 0);
            this.tableLayoutTop.Controls.Add(this.panelCart, 1, 0);

            // Add panels to form
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.tableLayoutTitles);
            this.Controls.Add(this.tableLayoutTop);
            this.Controls.Add(this.lblPaymentTitle);
            this.Controls.Add(this.panelPayment);
            this.Controls.Add(this.panelFooter);

            // Event handlers
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCoinSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrash)).EndInit();
        }
    }
}