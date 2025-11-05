namespace VendingMachine___Badr_Almashrea___30139708
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Main containers
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Panel panelCoins;
        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picCoinSlot;
        private System.Windows.Forms.PictureBox picTrash;

        // Labels
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblCartTitle;
        private System.Windows.Forms.Label lblPaymentTitle;

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
            panelProducts = new Panel();
            lblProductsTitle = new Label();
            listBoxProducts = new ListBox();
            lblCartTitle = new Label();
            lblTotal = new Label();
            btnCheckout = new Button();
            btnCancel = new Button();
            panelCoins = new Panel();
            lblPaymentTitle = new Label();
            picCoinSlot = new PictureBox();
            lblCoinSlot = new Label();
            picTrash = new PictureBox();
            lblTrash = new Label();
            ((System.ComponentModel.ISupportInitialize)picCoinSlot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTrash).BeginInit();
            SuspendLayout();
            // 
            // panelProducts
            // 
            panelProducts.AutoScroll = true;
            panelProducts.BorderStyle = BorderStyle.FixedSingle;
            panelProducts.Location = new Point(20, 50);
            panelProducts.Name = "panelProducts";
            panelProducts.Size = new Size(600, 300);
            panelProducts.TabIndex = 0;
            // 
            // lblProductsTitle
            // 
            lblProductsTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblProductsTitle.Location = new Point(20, 20);
            lblProductsTitle.Name = "lblProductsTitle";
            lblProductsTitle.Size = new Size(200, 20);
            lblProductsTitle.TabIndex = 1;
            lblProductsTitle.Text = "AVAILABLE PRODUCTS";
            // 
            // listBoxProducts
            // 
            listBoxProducts.Location = new Point(650, 50);
            listBoxProducts.Name = "listBoxProducts";
            listBoxProducts.Size = new Size(300, 184);
            listBoxProducts.TabIndex = 2;
            // 
            // lblCartTitle
            // 
            lblCartTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblCartTitle.Location = new Point(650, 20);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Size = new Size(150, 20);
            lblCartTitle.TabIndex = 3;
            lblCartTitle.Text = "SHOPPING CART";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkBlue;
            lblTotal.Location = new Point(650, 260);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(200, 25);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: £0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.LightGreen;
            btnCheckout.Location = new Point(650, 300);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(120, 40);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "CHECKOUT";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightCoral;
            btnCancel.Location = new Point(780, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "CANCEL ORDER";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelCoins
            // 
            panelCoins.BorderStyle = BorderStyle.FixedSingle;
            panelCoins.Location = new Point(20, 400);
            panelCoins.Name = "panelCoins";
            panelCoins.Size = new Size(150, 300);
            panelCoins.TabIndex = 7;
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblPaymentTitle.Location = new Point(20, 380);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(100, 20);
            lblPaymentTitle.TabIndex = 8;
            lblPaymentTitle.Text = "PAYMENT";
            // 
            // picCoinSlot
            // 
            picCoinSlot.BackColor = Color.Gray;
            picCoinSlot.BorderStyle = BorderStyle.Fixed3D;
            picCoinSlot.Location = new Point(200, 450);
            picCoinSlot.Name = "picCoinSlot";
            picCoinSlot.Size = new Size(100, 50);
            picCoinSlot.TabIndex = 9;
            picCoinSlot.TabStop = false;
            // 
            // lblCoinSlot
            // 
            lblCoinSlot.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblCoinSlot.Location = new Point(190, 430);
            lblCoinSlot.Name = "lblCoinSlot";
            lblCoinSlot.Size = new Size(120, 20);
            lblCoinSlot.TabIndex = 10;
            lblCoinSlot.Text = "DRAG COINS/NOTES HERE";
            // 
            // picTrash
            // 
            picTrash.BackColor = Color.Red;
            picTrash.BorderStyle = BorderStyle.FixedSingle;
            picTrash.Location = new Point(850, 400);
            picTrash.Name = "picTrash";
            picTrash.Size = new Size(100, 80);
            picTrash.TabIndex = 11;
            picTrash.TabStop = false;
            // 
            // lblTrash
            // 
            lblTrash.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblTrash.Location = new Point(820, 380);
            lblTrash.Name = "lblTrash";
            lblTrash.Size = new Size(150, 20);
            lblTrash.TabIndex = 12;
            lblTrash.Text = "DRAG ITEMS HERE TO REMOVE";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 853);
            Controls.Add(panelProducts);
            Controls.Add(lblProductsTitle);
            Controls.Add(listBoxProducts);
            Controls.Add(lblCartTitle);
            Controls.Add(lblTotal);
            Controls.Add(btnCheckout);
            Controls.Add(btnCancel);
            Controls.Add(panelCoins);
            Controls.Add(lblPaymentTitle);
            Controls.Add(picCoinSlot);
            Controls.Add(lblCoinSlot);
            Controls.Add(picTrash);
            Controls.Add(lblTrash);
            Name = "Form1";
            Text = "Vending Machine";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)picCoinSlot).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTrash).EndInit();
            ResumeLayout(false);
        }
        private Label lblCoinSlot;
        private Label lblTrash;
    }
}