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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
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
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;

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
            this.panelProducts.Location = new System.Drawing.Point(20, 120);
            this.panelProducts.Size = new System.Drawing.Size(600, 350);
            this.panelProducts.TabIndex = 4;

            // Products Title
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(20, 90);
            this.lblProductsTitle.Size = new System.Drawing.Size(220, 25);
            this.lblProductsTitle.TabIndex = 5;
            this.lblProductsTitle.Text = "🛍️ AVAILABLE PRODUCTS";

            // Flow Layout for Products
            this.flowLayoutProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.BackColor = System.Drawing.Color.White;
            this.flowLayoutProducts.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutProducts.Size = new System.Drawing.Size(580, 330);
            this.flowLayoutProducts.TabIndex = 6;
            this.flowLayoutProducts.WrapContents = true;

            // Cart Panel
            this.panelCart = new System.Windows.Forms.Panel();
            this.panelCart.BackColor = System.Drawing.Color.White;
            this.panelCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCart.Location = new System.Drawing.Point(640, 120);
            this.panelCart.Size = new System.Drawing.Size(540, 350);
            this.panelCart.TabIndex = 7;

            // Cart Title
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.lblCartTitle.AutoSize = true;
            this.lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblCartTitle.Location = new System.Drawing.Point(640, 90);
            this.lblCartTitle.Size = new System.Drawing.Size(180, 25);
            this.lblCartTitle.TabIndex = 8;
            this.lblCartTitle.Text = "🛒 SHOPPING CART";

            // ListBox for Products
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.listBoxProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.listBoxProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxProducts.Location = new System.Drawing.Point(20, 50);
            this.listBoxProducts.Size = new System.Drawing.Size(500, 200);
            this.listBoxProducts.TabIndex = 9;

            // Total Label
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 270);
            this.lblTotal.Size = new System.Drawing.Size(120, 30);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total: £0.00";

            // Items Count
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsCount.ForeColor = System.Drawing.Color.Gray;
            this.lblItemsCount.Location = new System.Drawing.Point(20, 20);
            this.lblItemsCount.Size = new System.Drawing.Size(70, 19);
            this.lblItemsCount.TabIndex = 11;
            this.lblItemsCount.Text = "Items: 0";

            // Checkout Button
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(20, 310);
            this.btnCheckout.Size = new System.Drawing.Size(240, 40);
            this.btnCheckout.TabIndex = 12;
            this.btnCheckout.Text = "💰 CHECKOUT";
            this.btnCheckout.UseVisualStyleBackColor = false;

            // Cancel Button
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(280, 310);
            this.btnCancel.Size = new System.Drawing.Size(240, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "❌ CANCEL ORDER";
            this.btnCancel.UseVisualStyleBackColor = false;

            // Payment Panel
            this.panelPayment = new System.Windows.Forms.Panel();
            this.panelPayment.BackColor = System.Drawing.Color.White;
            this.panelPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPayment.Location = new System.Drawing.Point(20, 490);
            this.panelPayment.Size = new System.Drawing.Size(1160, 250);
            this.panelPayment.TabIndex = 14;

            // Payment Title
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblPaymentTitle.Location = new System.Drawing.Point(20, 460);
            this.lblPaymentTitle.Size = new System.Drawing.Size(210, 25);
            this.lblPaymentTitle.TabIndex = 15;
            this.lblPaymentTitle.Text = "💳 PAYMENT METHOD";

            // Coins Panel
            this.panelCoins = new System.Windows.Forms.Panel();
            this.panelCoins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelCoins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCoins.Location = new System.Drawing.Point(20, 20);
            this.panelCoins.Size = new System.Drawing.Size(300, 210);
            this.panelCoins.TabIndex = 16;

            // Coin Slot
            this.picCoinSlot = new System.Windows.Forms.PictureBox();
            this.picCoinSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.picCoinSlot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCoinSlot.Location = new System.Drawing.Point(350, 80);
            this.picCoinSlot.Size = new System.Drawing.Size(80, 120);
            this.picCoinSlot.TabIndex = 17;
            this.picCoinSlot.TabStop = false;

            // Coin Slot Label
            this.lblCoinSlot = new System.Windows.Forms.Label();
            this.lblCoinSlot.AutoSize = true;
            this.lblCoinSlot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblCoinSlot.Location = new System.Drawing.Point(340, 50);
            this.lblCoinSlot.Size = new System.Drawing.Size(200, 19);
            this.lblCoinSlot.TabIndex = 18;
            this.lblCoinSlot.Text = "⬇️ DRAG COINS/NOTES HERE";

            // Payment Status
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblPaymentStatus.Location = new System.Drawing.Point(450, 80);
            this.lblPaymentStatus.Size = new System.Drawing.Size(350, 21);
            this.lblPaymentStatus.TabIndex = 19;
            this.lblPaymentStatus.Text = "Please add items and click checkout to pay";

            // Progress Bar
            this.progressPayment = new System.Windows.Forms.ProgressBar();
            this.progressPayment.Location = new System.Drawing.Point(450, 110);
            this.progressPayment.Size = new System.Drawing.Size(300, 20);
            this.progressPayment.TabIndex = 20;
            this.progressPayment.Visible = false;

            // Trash
            this.picTrash = new System.Windows.Forms.PictureBox();
            this.picTrash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.picTrash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTrash.Location = new System.Drawing.Point(800, 80);
            this.picTrash.Size = new System.Drawing.Size(80, 80);
            this.picTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrash.TabIndex = 21;
            this.picTrash.TabStop = false;

            // Trash Label
            this.lblTrash = new System.Windows.Forms.Label();
            this.lblTrash.AutoSize = true;
            this.lblTrash.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTrash.Location = new System.Drawing.Point(780, 50);
            this.lblTrash.Size = new System.Drawing.Size(250, 19);
            this.lblTrash.TabIndex = 22;
            this.lblTrash.Text = "🗑️ DRAG ITEMS HERE TO REMOVE";

            // Footer Panel
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 740);
            this.panelFooter.Size = new System.Drawing.Size(1200, 60);
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
            this.lblDateTime.Location = new System.Drawing.Point(1000, 20);
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

            // Add panels to form
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblProductsTitle);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.lblCartTitle);
            this.Controls.Add(this.panelCart);
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