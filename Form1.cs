using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VendingMachine;

namespace VendingMachine___Badr_Almashrea___30139708
{
    public partial class Form1 : Form
    {
        #region Class Variables
        private decimal totalCost = 0;
        private decimal amountPaid = 0;
        private bool inCheckoutMode = false;
        private string studentNumber = "30139708";

        private List<Product> selectedProducts = new List<Product>();
        private List<Product> allProducts = new List<Product>();
        private VendingMachineSettings machineSettings = new VendingMachineSettings();

        // File paths for data persistence
        private string stockFile = "Items.txt";
        private string invoicesFile = "Invoices.txt";
        private string transactionsFolder = "Transactions";
        private string settingsFile = "MachineSettings.txt";
        private string imagesFolder = "Images";

        // Colors for UI
        private Color colorPrimary = Color.FromArgb(0, 100, 180);
        private Color colorSuccess = Color.FromArgb(0, 150, 0);
        private Color colorDanger = Color.FromArgb(220, 60, 60);
        private Color colorWarning = Color.FromArgb(255, 193, 7);
        private Color colorLight = Color.FromArgb(240, 245, 250);
        #endregion

        public Form1()
        {
            InitializeComponent();
            SetupVendingMachine();
        }

        #region Initialization Methods
        private void SetupVendingMachine()
        {
            try
            {
                this.Text = $"Premium Vending Machine - Student: {studentNumber}";
                this.DoubleBuffered = true;
                this.WindowState = FormWindowState.Maximized;

                // Create necessary files and directories
                EnsureDirectoriesExist();
                EnsureFilesExist();

                LoadMachineSettings();
                LoadProductStock();

                SetupProductDisplay();
                SetupCoinButtons();
                SetupDragDrop();
                SetupRealTimeUpdates();

                DisableCoinButtons();
                UpdateDisplay();
                UpdateStatus("System initialized. Ready to serve! 🚀", false);

                timerDateTime.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize vending machine: {ex.Message}",
                    "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureDirectoriesExist()
        {
            try
            {
                if (!Directory.Exists(transactionsFolder))
                    Directory.CreateDirectory(transactionsFolder);
                if (!Directory.Exists("Logs"))
                    Directory.CreateDirectory("Logs");
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);
            }
            catch (Exception ex)
            {
                LogError($"Directory creation failed: {ex.Message}");
            }
        }

        private void EnsureFilesExist()
        {
            try
            {
                // Create Items.txt if it doesn't exist
                if (!File.Exists(stockFile))
                {
                    CreateDefaultItemsFile();
                }

                // Create Invoices.txt if it doesn't exist
                if (!File.Exists(invoicesFile))
                {
                    File.WriteAllText(invoicesFile, "VENDING MACHINE INVOICES\n" + new string('=', 50) + "\n\n");
                }

                // Create MachineSettings.txt if it doesn't exist
                if (!File.Exists(settingsFile))
                {
                    SaveMachineSettings();
                }
            }
            catch (Exception ex)
            {
                LogError($"File creation error: {ex.Message}");
            }
        }

        private void CreateDefaultItemsFile()
        {
            try
            {
                StringBuilder defaultItems = new StringBuilder();
                defaultItems.AppendLine("Coca Cola,1.50,10,COKE001,Soft Drink,coke.jpg");
                defaultItems.AppendLine("Zero Coca Cola,1.50,8,COKE002,Soft Drink,coke_zero.jpg");
                defaultItems.AppendLine("Pepsi,1.40,12,PEPSI003,Soft Drink,pepsi.jpg");
                defaultItems.AppendLine("Fanta Orange,1.40,10,FANTA004,Soft Drink,fanta.jpg");
                defaultItems.AppendLine("Red Bull,2.20,6,REDBULL005,Energy Drink,redbull.jpg");
                defaultItems.AppendLine("Sprite,1.30,15,SPRITE006,Soft Drink,sprite.jpg");
                defaultItems.AppendLine("Water,1.00,20,WATER007,Water,water.jpg");

                File.WriteAllText(stockFile, defaultItems.ToString());
            }
            catch (Exception ex)
            {
                LogError($"Default items file creation error: {ex.Message}");
            }
        }

        private void SetupRealTimeUpdates()
        {
            UpdateDateTimeDisplay();
        }
        #endregion

        #region Data Management Methods
        private void LoadMachineSettings()
        {
            try
            {
                if (File.Exists(settingsFile))
                {
                    string[] lines = File.ReadAllLines(settingsFile);
                    if (lines.Length >= 5)
                    {
                        machineSettings.MachineId = lines[0];
                        machineSettings.Location = lines[1];
                        machineSettings.TotalRevenue = decimal.Parse(lines[2]);
                        machineSettings.TotalTransactions = int.Parse(lines[3]);
                        machineSettings.LastRestock = DateTime.Parse(lines[4]);
                    }
                }
                else
                {
                    // Create default settings
                    machineSettings.MachineId = "VM-001";
                    machineSettings.Location = "University Campus";
                    machineSettings.TotalRevenue = 0;
                    machineSettings.TotalTransactions = 0;
                    machineSettings.LastRestock = DateTime.Now;
                    SaveMachineSettings();
                }
            }
            catch (Exception ex)
            {
                LogError($"Settings load error: {ex.Message}");
            }
        }

        private void SaveMachineSettings()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(settingsFile))
                {
                    writer.WriteLine(machineSettings.MachineId);
                    writer.WriteLine(machineSettings.Location);
                    writer.WriteLine(machineSettings.TotalRevenue);
                    writer.WriteLine(machineSettings.TotalTransactions);
                    writer.WriteLine(machineSettings.LastRestock);
                }
            }
            catch (Exception ex)
            {
                LogError($"Settings save error: {ex.Message}");
            }
        }

        private void LoadProductStock()
        {
            try
            {
                if (File.Exists(stockFile))
                {
                    LoadStockFromFile();
                }
                else
                {
                    CreateDefaultItemsFile();
                    LoadStockFromFile();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Stock load error: {ex.Message}");
                CreateDefaultProducts();
            }
        }

        private void CreateDefaultProducts()
        {
            allProducts.Clear();
            allProducts.Add(new Product("Coca Cola", 1.50m, 10, LoadProductImage("coke.jpg"), "COKE001", "coke.jpg", "Soft Drink"));
            allProducts.Add(new Product("Zero Coca Cola", 1.50m, 8, LoadProductImage("coke_zero.jpg"), "COKE002", "coke_zero.jpg", "Soft Drink"));
            allProducts.Add(new Product("Pepsi", 1.40m, 12, LoadProductImage("pepsi.jpg"), "PEPSI003", "pepsi.jpg", "Soft Drink"));
            allProducts.Add(new Product("Fanta Orange", 1.40m, 10, LoadProductImage("fanta.jpg"), "FANTA004", "fanta.jpg", "Soft Drink"));
            allProducts.Add(new Product("Red Bull", 2.20m, 6, LoadProductImage("redbull.jpg"), "REDBULL005", "redbull.jpg", "Energy Drink"));
            allProducts.Add(new Product("Sprite", 1.30m, 15, LoadProductImage("sprite.jpg"), "SPRITE006", "sprite.jpg", "Soft Drink"));
            allProducts.Add(new Product("Water", 1.00m, 20, LoadProductImage("water.jpg"), "WATER007", "water.jpg", "Water"));
        }

        private Image LoadProductImage(string imageFileName)
        {
            try
            {
                string imagePath = Path.Combine(imagesFolder, imageFileName);
                if (File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }

                // Try alternative names or extensions
                string[] possibleNames = {
                    imageFileName,
                    imageFileName.ToLower(),
                    imageFileName.Replace(".jpg", ".png"),
                    imageFileName.Replace(".png", ".jpg"),
                    imageFileName.Replace(".jpeg", ".jpg")
                };

                foreach (string name in possibleNames)
                {
                    string altPath = Path.Combine(imagesFolder, name);
                    if (File.Exists(altPath))
                    {
                        return Image.FromFile(altPath);
                    }
                }

                return CreateProfessionalPlaceholder(Path.GetFileNameWithoutExtension(imageFileName));
            }
            catch (Exception ex)
            {
                LogError($"Image load error for {imageFileName}: {ex.Message}");
                return CreateProfessionalPlaceholder(Path.GetFileNameWithoutExtension(imageFileName));
            }
        }

        private Image CreateProfessionalPlaceholder(string productName)
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            using (var brush = new SolidBrush(colorLight))
            using (var textBrush = new SolidBrush(Color.Gray))
            using (var font = new Font("Segoe UI", 8, FontStyle.Bold))
            {
                g.Clear(Color.White);
                g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 2), 1, 1, bmp.Width - 3, bmp.Height - 3);

                string displayText = productName.Length > 12 ? productName.Substring(0, 12) + "..." : productName;
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                g.DrawString(displayText, font, textBrush,
                    new RectangleF(0, 0, bmp.Width, bmp.Height), format);
            }
            return bmp;
        }

        private void LoadStockFromFile()
        {
            try
            {
                allProducts.Clear();
                string[] lines = File.ReadAllLines(stockFile);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.StartsWith("//") || line.StartsWith("#")) continue;

                    string[] parts = line.Split(',');
                    if (parts.Length >= 4)
                    {
                        string name = parts[0].Trim();
                        decimal price = decimal.Parse(parts[1].Trim());
                        int stock = int.Parse(parts[2].Trim());
                        string code = parts[3].Trim();
                        string category = parts.Length > 4 ? parts[4].Trim() : "Beverage";
                        string imagePath = parts.Length > 5 ? parts[5].Trim() : "";

                        Image productImage = CreateProfessionalPlaceholder(name);
                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            productImage = LoadProductImage(imagePath);
                        }

                        allProducts.Add(new Product(name, price, stock, productImage, code, imagePath, category));
                    }
                }

                if (allProducts.Count == 0)
                {
                    CreateDefaultProducts();
                    SaveStockToFile();
                }
            }
            catch (Exception ex)
            {
                LogError($"Stock file load error: {ex.Message}");
                CreateDefaultProducts();
            }
        }

        private void SaveStockToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(stockFile))
                {
                    foreach (Product product in allProducts)
                    {
                        writer.WriteLine($"{product.Name},{product.Price},{product.Stock},{product.ProductCode},{product.Category},{product.ImagePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Stock save error: {ex.Message}");
                ShowErrorMessage("Failed to save product stock!");
            }
        }
        #endregion

        #region UI Setup Methods
        private void SetupProductDisplay()
        {
            flowLayoutProducts.Controls.Clear();
            flowLayoutProducts.AutoScroll = true;
            flowLayoutProducts.WrapContents = true;

            foreach (Product product in allProducts)
            {
                Panel productCard = CreateProductCard(product);
                flowLayoutProducts.Controls.Add(productCard);
            }
        }

        private Panel CreateProductCard(Product product)
        {
            Panel card = new Panel
            {
                Size = new Size(180, 220),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10),
                Tag = product.ProductCode,
                Cursor = Cursors.Hand
            };

            PictureBox picProduct = new PictureBox
            {
                Size = new Size(140, 100),
                Location = new Point(20, 15),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = product.ProductImage,
                BackColor = Color.Transparent,
                Tag = product.ProductCode
            };

            Label lblName = new Label
            {
                Text = product.Name,
                Location = new Point(10, 125),
                Size = new Size(160, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                Tag = product.ProductCode
            };

            Label lblPrice = new Label
            {
                Text = $"£{product.Price:F2}",
                Location = new Point(10, 145),
                Size = new Size(160, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = colorSuccess,
                Tag = product.ProductCode
            };

            Label lblStock = new Label
            {
                Text = product.Stock > 0 ? $"Stock: {product.Stock}" : "OUT OF STOCK",
                Location = new Point(10, 170),
                Size = new Size(160, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                ForeColor = product.Stock > 0 ? Color.Gray : colorDanger,
                Tag = product.ProductCode
            };

            Button btnAdd = new Button
            {
                Text = "➕ Add to Cart",
                Size = new Size(160, 30),
                Location = new Point(10, 190),
                FlatStyle = FlatStyle.Flat,
                BackColor = product.Stock > 0 ? colorPrimary : Color.LightGray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Enabled = product.Stock > 0,
                Tag = product.ProductCode
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += ProductAddButton_Click;

            card.MouseEnter += (s, e) => { if (!inCheckoutMode) card.BackColor = Color.FromArgb(245, 245, 245); };
            card.MouseLeave += (s, e) => { card.BackColor = Color.White; };

            card.Controls.AddRange(new Control[] { picProduct, lblName, lblPrice, lblStock, btnAdd });
            return card;
        }

        private void SetupCoinButtons()
        {
            panelCoins.Controls.Clear();
            panelCoins.AutoScroll = true;

            var payments = new[]
            {
                new { Value = 0.10m, Text = "10p", Type = "Coin", ImageName = "coin10p.webp" },
                new { Value = 0.20m, Text = "20p", Type = "Coin", ImageName = "coin20p.webp" },
                new { Value = 0.50m, Text = "50p", Type = "Coin", ImageName = "coin50p.webp" },
                new { Value = 1.00m, Text = "£1", Type = "Coin", ImageName = "coin1.png" },
                new { Value = 2.00m, Text = "£2", Type = "Coin", ImageName = "coin2.webp" },
                new { Value = 5.00m, Text = "£5", Type = "Note", ImageName = "note5.png" },
                new { Value = 10.00m, Text = "£10", Type = "Note", ImageName = "note10.jpg" }
            };

            int buttonSize = 70;
            int spacing = 10;
            int x = spacing;
            int y = spacing;

            foreach (var payment in payments)
            {
                Panel paymentPanel = CreatePaymentPanel(payment.Value, payment.Text, payment.Type, payment.ImageName, buttonSize);
                paymentPanel.Location = new Point(x, y);
                panelCoins.Controls.Add(paymentPanel);

                x += buttonSize + spacing;
                if (x + buttonSize > panelCoins.Width - spacing)
                {
                    x = spacing;
                    y += buttonSize + spacing;
                }
            }
        }

        private Panel CreatePaymentPanel(decimal value, string text, string type, string imageName, int size)
        {
            Panel panel = new Panel
            {
                Size = new Size(size, size),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = type == "Note" ? Color.LightGreen : Color.Silver,
                Tag = value,
                Cursor = Cursors.Hand
            };

            Image coinImage = LoadCoinImage(imageName);
            if (coinImage != null)
            {
                PictureBox picCoin = new PictureBox
                {
                    Size = new Size(size - 10, size - 10),
                    Location = new Point(5, 5),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = coinImage,
                    BackColor = Color.Transparent,
                    Tag = value
                };
                picCoin.MouseDown += CoinPicture_MouseDown;
                panel.Controls.Add(picCoin);
            }
            else
            {
                Label lblValue = new Label
                {
                    Text = text,
                    Size = new Size(size, size),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Tag = value
                };
                lblValue.MouseDown += CoinLabel_MouseDown;
                panel.Controls.Add(lblValue);
            }

            panel.MouseEnter += (s, e) => { if (inCheckoutMode) panel.BackColor = ControlPaint.Light(panel.BackColor); };
            panel.MouseLeave += (s, e) => { panel.BackColor = type == "Note" ? Color.LightGreen : Color.Silver; };

            return panel;
        }

        private Image LoadCoinImage(string imageFileName)
        {
            try
            {
                string imagePath = Path.Combine(imagesFolder, imageFileName);
                if (File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }

                // Try alternative names
                string[] possibleNames = {
                    imageFileName,
                    imageFileName.ToLower(),
                    imageFileName.Replace(".webp", ".png"),
                    imageFileName.Replace(".png", ".webp"),
                    imageFileName.Replace(".jpg", ".png")
                };

                foreach (string name in possibleNames)
                {
                    string altPath = Path.Combine(imagesFolder, name);
                    if (File.Exists(altPath))
                    {
                        return Image.FromFile(altPath);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private void SetupDragDrop()
        {
            picCoinSlot.AllowDrop = true;
            picCoinSlot.DragEnter += CoinSlot_DragEnter;
            picCoinSlot.DragDrop += CoinSlot_DragDrop;
            picCoinSlot.Paint += CoinSlot_Paint;

            picTrash.AllowDrop = true;
            picTrash.DragEnter += Trash_DragEnter;
            picTrash.DragDrop += Trash_DragDrop;
            picTrash.Paint += Trash_Paint;

            listBoxProducts.MouseDown += ListBoxProducts_MouseDown;
        }

        private void CoinSlot_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = picCoinSlot.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, Color.DimGray, Color.Black, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }

            Rectangle slotRect = new Rectangle(rect.Width / 4, 5, rect.Width / 2, rect.Height - 10);
            using (SolidBrush slotBrush = new SolidBrush(Color.FromArgb(100, 50, 50, 50)))
            {
                g.FillRectangle(slotBrush, slotRect);
            }

            g.DrawRectangle(new Pen(Color.Silver, 2), rect);

            // Draw text
            using (Font font = new Font("Segoe UI", 8, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("DROP\nCOINS\nHERE", font, textBrush, rect, format);
            }
        }

        private void Trash_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = picTrash.ClientRectangle;

            using (SolidBrush brush = new SolidBrush(colorDanger))
            {
                g.FillRectangle(brush, rect);
            }

            g.DrawRectangle(new Pen(Color.DarkRed, 2), rect);

            // Draw trash icon
            using (Font font = new Font("Segoe UI", 20, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("🗑️", font, textBrush, rect, format);
            }
        }
        #endregion

        #region Event Handlers - Core Functionality
        private void ProductAddButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productCode = (string)button.Tag;

            if (inCheckoutMode)
            {
                ShowWarningMessage("Please complete or cancel the current payment before adding more items.");
                return;
            }

            Product selectedProduct = allProducts.FirstOrDefault(p => p.ProductCode == productCode);
            if (selectedProduct == null)
            {
                ShowErrorMessage("Product not found!");
                return;
            }

            if (selectedProduct.Stock <= 0)
            {
                ShowWarningMessage($"Sorry, {selectedProduct.Name} is out of stock! ❌");
                UpdateStockDisplays();
                return;
            }

            int currentQuantity = selectedProducts.Count(p => p.ProductCode == productCode);
            if (currentQuantity >= selectedProduct.Stock)
            {
                ShowWarningMessage($"Cannot add more {selectedProduct.Name}. Only {selectedProduct.Stock} available in stock.");
                return;
            }

            selectedProducts.Add(selectedProduct);
            UpdateDisplay();
            UpdateStatus($"Added {selectedProduct.Name} to cart. 🛒", false);
            AnimateButton(button);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0)
            {
                ShowWarningMessage("Your cart is empty! Please add items before checkout. 🛒");
                return;
            }

            StringBuilder stockIssues = new StringBuilder();
            foreach (var productGroup in selectedProducts.GroupBy(p => p.ProductCode))
            {
                Product product = allProducts.First(p => p.ProductCode == productGroup.Key);
                int requestedQuantity = productGroup.Count();

                if (product.Stock < requestedQuantity)
                {
                    stockIssues.AppendLine($"• {product.Name}: Requested {requestedQuantity}, Available {product.Stock}");
                }
            }

            if (stockIssues.Length > 0)
            {
                ShowWarningMessage($"Stock issues detected:\n{stockIssues}\nPlease adjust your order.");
                return;
            }

            if (totalCost <= 0)
            {
                ShowErrorMessage("Invalid order total. Please reselect items.");
                return;
            }

            EnterCheckoutMode();
        }

        private void EnterCheckoutMode()
        {
            inCheckoutMode = true;
            amountPaid = 0;

            UpdateProductCardsState(false);
            EnableCoinButtons();
            btnCheckout.Enabled = false;
            btnCancel.Enabled = true;

            progressPayment.Visible = true;
            progressPayment.Value = 0;
            UpdatePaymentStatus();

            UpdateStatus($"Checkout started. Total: £{totalCost:F2}. Please make payment. 💳", false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0 && !inCheckoutMode)
            {
                ShowInformationMessage("No active order to cancel.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this order?\n\nAll selected items will be removed from your cart.",
                "Confirm Order Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                ResetOrder();
                UpdateStatus("Order cancelled successfully. ✅", false);
            }
        }

        private void ResetOrder()
        {
            selectedProducts.Clear();
            totalCost = 0;
            amountPaid = 0;
            inCheckoutMode = false;

            UpdateDisplay();
            UpdateProductCardsState(true);
            DisableCoinButtons();
            btnCheckout.Enabled = true;
            btnCancel.Enabled = true;
            progressPayment.Visible = false;

            UpdateStatus("Order reset. Ready for new selection. 🆕", false);
        }
        #endregion

        #region Drag and Drop Handlers
        private void CoinLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!inCheckoutMode)
            {
                ShowWarningMessage("Please click checkout first before making payment.");
                return;
            }

            Label label = (Label)sender;
            decimal coinValue = (decimal)label.Tag;
            label.DoDragDrop(coinValue, DragDropEffects.Copy);
        }

        private void CoinPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!inCheckoutMode)
            {
                ShowWarningMessage("Please click checkout first before making payment.");
                return;
            }

            PictureBox picture = (PictureBox)sender;
            decimal coinValue = (decimal)picture.Tag;
            picture.DoDragDrop(coinValue, DragDropEffects.Copy);
        }

        private void CoinSlot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(decimal)))
            {
                e.Effect = DragDropEffects.Copy;
                picCoinSlot.BackColor = Color.FromArgb(100, 100, 100);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CoinSlot_DragDrop(object sender, DragEventArgs e)
        {
            picCoinSlot.BackColor = Color.FromArgb(80, 80, 80);

            if (!inCheckoutMode) return;

            try
            {
                decimal coinValue = (decimal)e.Data.GetData(typeof(decimal));
                ProcessCoinPayment(coinValue);
            }
            catch (Exception ex)
            {
                LogError($"Payment processing error: {ex.Message}");
                ShowErrorMessage("Payment processing failed. Please try again.");
            }
        }

        private void ListBoxProducts_MouseDown(object sender, MouseEventArgs e)
        {
            if (inCheckoutMode) return;

            int index = listBoxProducts.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                string itemText = listBoxProducts.Items[index].ToString();
                Product draggedProduct = FindProductFromDisplayText(itemText);
                if (draggedProduct != null)
                {
                    listBoxProducts.DoDragDrop(draggedProduct, DragDropEffects.Move);
                }
            }
        }

        private void Trash_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Product)) && !inCheckoutMode)
            {
                e.Effect = DragDropEffects.Move;
                picTrash.BackColor = Color.FromArgb(200, 40, 40);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Trash_DragDrop(object sender, DragEventArgs e)
        {
            picTrash.BackColor = Color.FromArgb(220, 60, 60);

            if (inCheckoutMode) return;

            if (e.Data.GetDataPresent(typeof(Product)))
            {
                Product productToRemove = (Product)e.Data.GetData(typeof(Product));
                RemoveProductFromOrder(productToRemove);
            }
        }
        #endregion

        #region Business Logic Methods
        private void ProcessCoinPayment(decimal coinValue)
        {
            amountPaid += coinValue;

            decimal progressPercentage = (amountPaid / totalCost) * 100;
            progressPayment.Value = (int)Math.Min(progressPercentage, 100);

            UpdatePaymentStatus();
            UpdateStatus($"Payment received: {coinValue:C}. Total paid: {amountPaid:C} 💰", false);

            if (amountPaid >= totalCost)
            {
                CompletePayment();
            }
        }

        private void CompletePayment()
        {
            decimal change = amountPaid - totalCost;

            try
            {
                UpdateProductStock();

                string invoiceNumber = GenerateInvoiceNumber();
                SaveInvoiceToFile(invoiceNumber, change);
                SaveTransactionToFile(change);
                UpdateMachineStatistics();
                ShowPaymentSuccess(invoiceNumber, change);
                ResetAfterPayment();
                UpdateStatus($"Transaction #{invoiceNumber} completed successfully! 🎉", false);
            }
            catch (Exception ex)
            {
                LogError($"Payment completion error: {ex.Message}");
                ShowErrorMessage("Transaction failed! Please contact support.");
            }
        }

        private void UpdateProductStock()
        {
            foreach (var productGroup in selectedProducts.GroupBy(p => p.ProductCode))
            {
                Product product = allProducts.First(p => p.ProductCode == productGroup.Key);
                product.Stock -= productGroup.Count();
            }
            SaveStockToFile();
        }

        private void UpdateMachineStatistics()
        {
            machineSettings.TotalRevenue += totalCost;
            machineSettings.TotalTransactions++;
            SaveMachineSettings();
        }

        private void RemoveProductFromOrder(Product productToRemove)
        {
            var itemToRemove = selectedProducts.FirstOrDefault(p => p.ProductCode == productToRemove.ProductCode);
            if (itemToRemove != null)
            {
                selectedProducts.Remove(itemToRemove);
                UpdateDisplay();
                UpdateStatus($"Removed {itemToRemove.Name} from cart. ❌", false);
            }
        }
        #endregion

        #region Display Update Methods
        private void UpdateDisplay()
        {
            UpdateListBox();
            UpdateTotalDisplay();
            UpdateItemsCount();
            UpdateStockDisplays();
        }

        private void UpdateListBox()
        {
            listBoxProducts.Items.Clear();
            listBoxProducts.BackColor = selectedProducts.Count > 0 ? Color.FromArgb(250, 250, 252) : Color.White;

            var groupedProducts = selectedProducts
                .GroupBy(p => p.ProductCode)
                .Select(g => new
                {
                    Product = g.First(),
                    Quantity = g.Count(),
                    Subtotal = g.First().Price * g.Count()
                })
                .OrderBy(g => g.Product.Name);

            foreach (var group in groupedProducts)
            {
                string displayText = group.Quantity > 1
                    ? $"{group.Product.Name} ×{group.Quantity} @ £{group.Product.Price:F2} = £{group.Subtotal:F2}"
                    : $"{group.Product.Name} - £{group.Product.Price:F2}";

                listBoxProducts.Items.Add(displayText);
            }
        }

        private void UpdateTotalDisplay()
        {
            totalCost = selectedProducts.Sum(p => p.Price);
            lblTotal.Text = $"Total: £{totalCost:F2}";
            lblTotal.ForeColor = totalCost > 0 ? colorSuccess : Color.Gray;
        }

        private void UpdateItemsCount()
        {
            int itemCount = selectedProducts.Count;
            lblItemsCount.Text = itemCount > 0 ? $"Items: {itemCount}" : "Cart is empty";
            lblItemsCount.ForeColor = itemCount > 0 ? colorPrimary : Color.Gray;
        }

        private void UpdatePaymentStatus()
        {
            if (!inCheckoutMode)
            {
                lblPaymentStatus.Text = "Please add items and click checkout to pay";
                lblPaymentStatus.ForeColor = colorPrimary;
                return;
            }

            if (amountPaid >= totalCost)
            {
                lblPaymentStatus.Text = "Payment Complete! ✅";
                lblPaymentStatus.ForeColor = colorSuccess;
            }
            else if (amountPaid > 0)
            {
                decimal remaining = totalCost - amountPaid;
                lblPaymentStatus.Text = $"Paid: £{amountPaid:F2} | Due: £{remaining:F2}";
                lblPaymentStatus.ForeColor = colorWarning;
            }
            else
            {
                lblPaymentStatus.Text = $"Total Due: £{totalCost:F2} - Please make payment";
                lblPaymentStatus.ForeColor = colorPrimary;
            }
        }

        private void UpdateStockDisplays()
        {
            foreach (Control control in flowLayoutProducts.Controls)
            {
                if (control is Panel card && card.Tag is string productCode)
                {
                    Product product = allProducts.FirstOrDefault(p => p.ProductCode == productCode);
                    if (product != null)
                    {
                        Label stockLabel = card.Controls.OfType<Label>()
                            .FirstOrDefault(l => l.Text.StartsWith("Stock:") || l.Text == "OUT OF STOCK");

                        if (stockLabel != null)
                        {
                            stockLabel.Text = product.Stock > 0 ? $"Stock: {product.Stock}" : "OUT OF STOCK";
                            stockLabel.ForeColor = product.Stock > 0 ? Color.Gray : colorDanger;
                        }

                        Button addButton = card.Controls.OfType<Button>().FirstOrDefault();
                        if (addButton != null)
                        {
                            addButton.Enabled = product.Stock > 0 && !inCheckoutMode;
                            addButton.BackColor = product.Stock > 0 ? colorPrimary : Color.LightGray;
                        }

                        card.BackColor = product.Stock > 0 ? Color.White : Color.FromArgb(250, 250, 250);
                    }
                }
            }
        }

        private void UpdateProductCardsState(bool enabled)
        {
            foreach (Control control in flowLayoutProducts.Controls)
            {
                if (control is Panel card)
                {
                    Button addButton = card.Controls.OfType<Button>().FirstOrDefault();
                    if (addButton != null)
                    {
                        string productCode = (string)addButton.Tag;
                        Product product = allProducts.FirstOrDefault(p => p.ProductCode == productCode);
                        addButton.Enabled = enabled && (product != null && product.Stock > 0);
                    }
                }
            }
        }

        private void UpdateStatus(string message, bool isError)
        {
            lblStatus.Text = $"[{DateTime.Now:HH:mm:ss}] {message}";
            lblStatus.ForeColor = isError ? colorDanger : Color.White;
            LogActivity(message);
        }

        private void UpdateDateTimeDisplay()
        {
            lblDateTime.Text = $"{DateTime.Now:dddd, MMMM dd, yyyy} | {DateTime.Now:HH:mm:ss}";
        }
        #endregion

        #region Utility Methods
        private void DisableCoinButtons()
        {
            foreach (Control control in panelCoins.Controls)
            {
                control.Enabled = false;
                control.BackColor = Color.LightGray;
            }
        }

        private void EnableCoinButtons()
        {
            foreach (Control control in panelCoins.Controls)
            {
                control.Enabled = true;
                decimal value = (decimal)control.Tag;
                control.BackColor = value >= 5.00m ? Color.LightGreen :
                                  value >= 1.00m ? Color.Gold : Color.Silver;
            }
        }

        private Product FindProductFromDisplayText(string displayText)
        {
            string productName = displayText.Split(new[] { " ×", " - ", " @" }, StringSplitOptions.RemoveEmptyEntries)[0];
            return allProducts.FirstOrDefault(p => displayText.Contains(p.Name));
        }

        private string GenerateInvoiceNumber()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            Random random = new Random();
            return $"INV-{timestamp}-{random.Next(1000, 9999)}";
        }

        private void AnimateButton(Control button)
        {
            Color originalColor = button.BackColor;
            button.BackColor = Color.LightGreen;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += (s, e) =>
            {
                button.BackColor = originalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
        #endregion

        #region File Operations
        private void SaveInvoiceToFile(string invoiceNumber, decimal change)
        {
            try
            {
                StringBuilder invoice = new StringBuilder();
                invoice.AppendLine("╔════════════════════════════════════════╗");
                invoice.AppendLine("║           VENDING MACHINE RECEIPT      ║");
                invoice.AppendLine("╠════════════════════════════════════════╣");
                invoice.AppendLine($"║ Invoice: {invoiceNumber,-25} ║");
                invoice.AppendLine($"║ Date:    {DateTime.Now:yyyy-MM-dd HH:mm:ss,-20} ║");
                invoice.AppendLine($"║ Student: {studentNumber,-25} ║");
                invoice.AppendLine("╠════════════════════════════════════════╣");
                invoice.AppendLine("║               ITEMS SOLD               ║");
                invoice.AppendLine("╠════════════════════════════════════════╣");

                var groupedItems = selectedProducts
                    .GroupBy(p => p.ProductCode)
                    .Select(g => new
                    {
                        Name = g.First().Name,
                        Quantity = g.Count(),
                        Price = g.First().Price,
                        Subtotal = g.Count() * g.First().Price
                    });

                foreach (var item in groupedItems)
                {
                    string itemLine = $"║ {item.Quantity,-2}× {item.Name,-20} £{item.Subtotal,6:F2} ║";
                    invoice.AppendLine(itemLine);
                }

                invoice.AppendLine("╠════════════════════════════════════════╣");
                invoice.AppendLine($"║ TOTAL:                    £{totalCost,8:F2} ║");
                invoice.AppendLine($"║ AMOUNT PAID:              £{amountPaid,8:F2} ║");
                invoice.AppendLine($"║ CHANGE:                   £{change,8:F2} ║");
                invoice.AppendLine("╠════════════════════════════════════════╣");
                invoice.AppendLine($"║ Machine: {machineSettings.MachineId,-26} ║");
                invoice.AppendLine($"║ Location: {machineSettings.Location,-24} ║");
                invoice.AppendLine("╚════════════════════════════════════════╝");

                File.AppendAllText(invoicesFile, invoice.ToString() + Environment.NewLine + Environment.NewLine);

                string transactionFile = Path.Combine(transactionsFolder, $"{invoiceNumber}.txt");
                File.WriteAllText(transactionFile, invoice.ToString());

                LogActivity($"Invoice {invoiceNumber} saved successfully");
            }
            catch (Exception ex)
            {
                LogError($"Invoice save error: {ex.Message}");
            }
        }

        private void SaveTransactionToFile(decimal change)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Invoice | Total: £{totalCost:F2} | Paid: £{amountPaid:F2} | Change: £{change:F2} | Student: {studentNumber}";
                string logFile = Path.Combine("Logs", $"Transactions_{DateTime.Now:yyyyMMdd}.log");
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogError($"Transaction log error: {ex.Message}");
            }
        }

        private void LogError(string errorMessage)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ERROR | {errorMessage}";
                string logFile = Path.Combine("Logs", $"Errors_{DateTime.Now:yyyyMMdd}.log");
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch
            {
                // Silent fail for error logging
            }
        }

        private void LogActivity(string activity)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ACTIVITY | {activity}";
                string logFile = Path.Combine("Logs", $"Activity_{DateTime.Now:yyyyMMdd}.log");
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch
            {
                // Silent fail for activity logging
            }
        }
        #endregion

        #region UI Feedback Methods
        private void ShowPaymentSuccess(string invoiceNumber, decimal change)
        {
            StringBuilder successMessage = new StringBuilder();
            successMessage.AppendLine("🎉 PAYMENT SUCCESSFUL! 🎉");
            successMessage.AppendLine();
            successMessage.AppendLine($"Invoice: {invoiceNumber}");
            successMessage.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            successMessage.AppendLine();
            successMessage.AppendLine("Items Purchased:");

            var groupedItems = selectedProducts
                .GroupBy(p => p.ProductCode)
                .Select(g => $"  • {g.First().Name} ×{g.Count()} @ £{g.First().Price:F2}");

            foreach (var item in groupedItems)
            {
                successMessage.AppendLine(item);
            }

            successMessage.AppendLine();
            successMessage.AppendLine($"Total: £{totalCost:F2}");
            successMessage.AppendLine($"Paid: £{amountPaid:F2}");

            if (change > 0)
            {
                successMessage.AppendLine($"Change: £{change:F2}");
                successMessage.AppendLine();
                successMessage.AppendLine("Please collect your change! 💰");
            }

            successMessage.AppendLine();
            successMessage.AppendLine("Thank you for your purchase! 🙏");

            MessageBox.Show(successMessage.ToString(), "Payment Successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            UpdateStatus($"Error: {message}", true);
        }
        #endregion

        #region Timer and Cleanup
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeDisplay();
        }

        private void ResetAfterPayment()
        {
            selectedProducts.Clear();
            totalCost = 0;
            amountPaid = 0;
            inCheckoutMode = false;

            UpdateDisplay();
            UpdateProductCardsState(true);
            DisableCoinButtons();
            btnCheckout.Enabled = true;
            progressPayment.Visible = false;
            UpdatePaymentStatus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveStockToFile();
                SaveMachineSettings();
                timerDateTime.Stop();
                LogActivity("Application closed gracefully");
            }
            catch (Exception ex)
            {
                LogError($"Form closing error: {ex.Message}");
            }
        }
        #endregion
    }
}