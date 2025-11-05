using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VendingMachine;

namespace VendingMachine___Badr_Almashrea___30139708
{
    public partial class Form1 : Form
    {
        // Variables to track vending machine state
        private decimal totalCost = 0;
        private decimal amountPaid = 0;
        private bool inCheckoutMode = false;
        private string studentNumber = "12345678"; // Change to your student number

        // List to store selected products
        private List<Product> selectedProducts = new List<Product>();

        // List of all available products
        private List<Product> allProducts = new List<Product>();

        // File paths for data persistence
        private string stockFile = "product_stock.txt";
        private string transactionsFolder = "Transactions";

        public Form1()
        {
            InitializeComponent();
            SetupVendingMachine();
        }

        private void SetupVendingMachine()
        {
            // Set form title with student number
            this.Text = "Advanced Vending Machine - " + studentNumber;
            this.Size = new Size(1000, 750);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Load product stock from file
            LoadProductStock();

            // Setup the UI
            SetupProductButtons();
            SetupCoinButtons();
            SetupDragDrop();

            // Initial UI state
            DisableCoinButtons();
            UpdateDisplay();

            // Ensure transactions folder exists
            if (!Directory.Exists(transactionsFolder))
            {
                Directory.CreateDirectory(transactionsFolder);
            }
        }

        private void LoadProductStock()
        {
            // Check if stock file exists
            if (File.Exists(stockFile))
            {
                // Load stock from file
                LoadStockFromFile();
            }
            else
            {
                // Create default products with initial stock
                CreateDefaultProducts();
                SaveStockToFile();
            }
        }

        private void CreateDefaultProducts()
        {
            allProducts.Clear();

            // Load images from files
            string imagePath = "Images/";

            allProducts.Add(new Product("Coca Cola", 1.50m, 10, LoadImage(imagePath + "coke.jpg"), "COKE001"));
            allProducts.Add(new Product("Zero Coca Cola", 1.50m, 8, LoadImage(imagePath + "coke_zero.jpg"), "COKE002"));
            allProducts.Add(new Product("Pepsi", 1.40m, 12, LoadImage(imagePath + "pepsi.jpg"), "PEPSI003"));
            allProducts.Add(new Product("Fanta Orange", 1.40m, 10, LoadImage(imagePath + "fanta.jpg"), "FANTA004"));
            allProducts.Add(new Product("Red Bull", 2.20m, 6, LoadImage(imagePath + "redbull.jpg"), "REDBULL005"));
            allProducts.Add(new Product("Sprite", 1.30m, 15, LoadImage(imagePath + "sprite.jpg"), "SPRITE006"));
            allProducts.Add(new Product("Water", 1.00m, 20, LoadImage(imagePath + "water.jpg"), "WATER007"));
        }

        private Image LoadImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                return Image.FromFile(filePath);
            }
            else
            {
                // Return placeholder if image not found
                return CreatePlaceholderImage();
            }
        }

        private Image CreatePlaceholderImage()
        {
            // Create a simple placeholder image
            Bitmap bmp = new Bitmap(80, 80);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightBlue);
                g.DrawRectangle(Pens.Black, 0, 0, 79, 79);
                g.DrawString("Product", new Font("Arial", 8), Brushes.Black, 10, 35);
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
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        string name = parts[0];
                        decimal price = decimal.Parse(parts[1]);
                        int stock = int.Parse(parts[2]);
                        string code = parts[3];

                        allProducts.Add(new Product(name, price, stock, CreatePlaceholderImage(), code));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock: {ex.Message}. Using default products.");
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
                        writer.WriteLine($"{product.Name},{product.Price},{product.Stock},{product.ProductCode},0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving stock: {ex.Message}");
            }
        }

        private void SetupProductButtons()
        {
            // Clear existing buttons
            panelProducts.Controls.Clear();

            int buttonWidth = 140;
            int buttonHeight = 120;
            int spacing = 15;
            int x = spacing;
            int y = spacing;

            // Create products with proper display
            allProducts.Clear();

            // Create products - using placeholder images for now
            Image placeholder = CreatePlaceholderImage();

            allProducts.Add(new Product("Coca Cola", 1.50m, 10, placeholder, "COKE001"));
            allProducts.Add(new Product("Zero Coca Cola", 1.50m, 8, placeholder, "COKE002"));
            allProducts.Add(new Product("Pepsi", 1.40m, 12, placeholder, "PEPSI003"));
            allProducts.Add(new Product("Fanta Orange", 1.40m, 10, placeholder, "FANTA004"));
            allProducts.Add(new Product("Red Bull", 2.20m, 6, placeholder, "REDBULL005"));
            allProducts.Add(new Product("Sprite", 1.30m, 15, placeholder, "SPRITE006"));
            allProducts.Add(new Product("Water", 1.00m, 20, placeholder, "WATER007"));

            foreach (Product product in allProducts)
            {
                // Create main product container panel
                Panel productPanel = new Panel();
                productPanel.Size = new Size(buttonWidth, buttonHeight);
                productPanel.Location = new Point(x, y);
                productPanel.BorderStyle = BorderStyle.FixedSingle;
                productPanel.BackColor = Color.White;
                productPanel.Tag = product.ProductCode;

                // Create product image
                PictureBox picProduct = new PictureBox();
                picProduct.Size = new Size(80, 60);
                picProduct.Location = new Point(30, 10);
                picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                picProduct.Image = product.ProductImage;
                picProduct.BackColor = Color.Transparent;

                // Create product name label
                Label lblName = new Label();
                lblName.Text = product.Name;
                lblName.Location = new Point(5, 75);
                lblName.Size = new Size(buttonWidth - 10, 20);
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                lblName.Font = new Font("Arial", 9, FontStyle.Bold);
                lblName.BackColor = Color.Transparent;

                // Create product price label
                Label lblPrice = new Label();
                lblPrice.Text = $"£{product.Price:F2}";
                lblPrice.Location = new Point(5, 95);
                lblPrice.Size = new Size(buttonWidth - 10, 20);
                lblPrice.TextAlign = ContentAlignment.MiddleCenter;
                lblPrice.Font = new Font("Arial", 9, FontStyle.Regular);
                lblPrice.ForeColor = Color.DarkGreen;
                lblPrice.BackColor = Color.Transparent;

                // Create select button (invisible overlay)
                Button btnSelect = new Button();
                btnSelect.Size = new Size(buttonWidth, buttonHeight);
                btnSelect.Location = new Point(0, 0);
                btnSelect.FlatStyle = FlatStyle.Flat;
                btnSelect.BackColor = Color.Transparent;
                btnSelect.FlatAppearance.BorderSize = 0;
                btnSelect.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 255);
                btnSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 0, 0, 255);
                btnSelect.Tag = product.ProductCode;
                btnSelect.Click += ProductButton_Click;

                // Add controls to product panel
                productPanel.Controls.Add(picProduct);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(btnSelect);

                // Add product panel to main panel
                panelProducts.Controls.Add(productPanel);

                // Update position for next product
                x += buttonWidth + spacing;
                if (x + buttonWidth > panelProducts.Width - spacing)
                {
                    x = spacing;
                    y += buttonHeight + spacing;
                }
            }
        }

        private void SetupCoinButtons()
        {
            // Define coins and notes with images
            var payments = new[]
            {
        new { Value = 0.10m, Text = "10p", ImageName = "coin10p" },
        new { Value = 0.20m, Text = "20p", ImageName = "coin20p" },
        new { Value = 0.50m, Text = "50p", ImageName = "coin50p" },
        new { Value = 1.00m, Text = "£1", ImageName = "coin1" },
        new { Value = 2.00m, Text = "£2", ImageName = "coin2" },
        new { Value = 5.00m, Text = "£5", ImageName = "note5" },
        new { Value = 10.00m, Text = "£10", ImageName = "note10" }
    };

            int buttonWidth = 80;
            int buttonHeight = 80;
            int spacing = 10;
            int x = spacing;
            int y = spacing;

            foreach (var payment in payments)
            {
                // Create coin/note panel
                Panel paymentPanel = new Panel();
                paymentPanel.Size = new Size(buttonWidth, buttonHeight);
                paymentPanel.Location = new Point(x, y);
                paymentPanel.BorderStyle = BorderStyle.FixedSingle;
                paymentPanel.BackColor = Color.LightYellow;
                paymentPanel.Tag = payment.Value;

                // Create payment image
                PictureBox picPayment = new PictureBox();
                picPayment.Size = new Size(50, 50);
                picPayment.Location = new Point(15, 5);
                picPayment.SizeMode = PictureBoxSizeMode.StretchImage;
                picPayment.Image = LoadPaymentImage(payment.ImageName);
                picPayment.BackColor = Color.Transparent;

                // Create payment value label
                Label lblValue = new Label();
                lblValue.Text = payment.Text;
                lblValue.Location = new Point(5, 60);
                lblValue.Size = new Size(buttonWidth - 10, 15);
                lblValue.TextAlign = ContentAlignment.MiddleCenter;
                lblValue.Font = new Font("Arial", 8, FontStyle.Bold);
                lblValue.BackColor = Color.Transparent;

                // Create invisible drag button
                Button btnDrag = new Button();
                btnDrag.Size = new Size(buttonWidth, buttonHeight);
                btnDrag.Location = new Point(0, 0);
                btnDrag.FlatStyle = FlatStyle.Flat;
                btnDrag.BackColor = Color.Transparent;
                btnDrag.FlatAppearance.BorderSize = 0;
                btnDrag.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 0);
                btnDrag.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 255, 255, 0);
                btnDrag.Tag = payment.Value;
                btnDrag.MouseDown += CoinButton_MouseDown;

                paymentPanel.Controls.Add(picPayment);
                paymentPanel.Controls.Add(lblValue);
                paymentPanel.Controls.Add(btnDrag);

                panelCoins.Controls.Add(paymentPanel);

                y += buttonHeight + spacing;
            }
        }

        private Image LoadPaymentImage(string imageName)
        {
            // Try to load from resources first
            try
            {
                var resourceManager = new System.Resources.ResourceManager("VendingMachine.Properties.Resources", typeof(Form1).Assembly);
                return (Image)resourceManager.GetObject(imageName);
            }
            catch
            {
                // Try to load from file
                string filePath = $"Images/{imageName}.jpg";
                if (File.Exists(filePath))
                {
                    return Image.FromFile(filePath);
                }
                else
                {
                    // Create placeholder for payment
                    return CreatePaymentPlaceholder(imageName);
                }
            }
        }

        private Image CreatePaymentPlaceholder(string paymentType)
        {
            Bitmap bmp = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (paymentType.Contains("note"))
                {
                    g.Clear(Color.LightGreen);
                }
                else
                {
                    g.Clear(Color.Silver);
                }

                g.DrawRectangle(Pens.Black, 0, 0, 49, 49);

                string text = paymentType.Replace("coin", "").Replace("note", "");
                if (paymentType.Contains("note"))
                {
                    text = "£" + text;
                }
                else
                {
                    text = text + "p";
                }

                g.DrawString(text, new Font("Arial", 7), Brushes.Black, 5, 15);
            }
            return bmp;
        }



        private void SetupDragDrop()
        {
            // Setup coin slot
            picCoinSlot.AllowDrop = true;
            picCoinSlot.DragEnter += CoinSlot_DragEnter;
            picCoinSlot.DragDrop += CoinSlot_DragDrop;
            picCoinSlot.BackColor = Color.Gray;
            picCoinSlot.BorderStyle = BorderStyle.Fixed3D;

            // Setup trash for removing items
            picTrash.AllowDrop = true;
            picTrash.DragEnter += Trash_DragEnter;
            picTrash.DragDrop += Trash_DragDrop;
            picTrash.BackColor = Color.Red;
            picTrash.BorderStyle = BorderStyle.FixedSingle;

            // Setup listbox for dragging items out
            listBoxProducts.MouseDown += ListBoxProducts_MouseDown;
        }

        private void DisableCoinButtons()
        {
            foreach (Control control in panelCoins.Controls)
            {
                if (control is Button)
                    control.Enabled = false;
            }
        }

        private void EnableCoinButtons()
        {
            foreach (Control control in panelCoins.Controls)
            {
                if (control is Button)
                    control.Enabled = true;
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (inCheckoutMode)
            {
                MessageBox.Show("Please complete or cancel the current payment before selecting more products.", "Checkout in Progress");
                return;
            }

            Button clickedButton = (Button)sender;
            string productCode = (string)clickedButton.Tag;

            Product selectedProduct = allProducts.FirstOrDefault(p => p.ProductCode == productCode);

            if (selectedProduct != null)
            {
                if (selectedProduct.Stock > 0)
                {
                    selectedProducts.Add(selectedProduct);
                    UpdateDisplay();
                }
                else
                {
                    MessageBox.Show($"Sorry, {selectedProduct.Name} is out of stock!", "Out of Stock");
                }
            }
        }

        private void UpdateDisplay()
        {
            // Update listbox with grouped products
            listBoxProducts.Items.Clear();

            var groupedProducts = selectedProducts
                .GroupBy(p => p.ProductCode)
                .Select(g => new
                {
                    Product = g.First(),
                    Quantity = g.Count(),
                    Subtotal = g.First().Price * g.Count()
                });

            foreach (var group in groupedProducts)
            {
                string displayText;
                if (group.Quantity > 1)
                {
                    displayText = $"{group.Product.Name} x{group.Quantity} - £{group.Subtotal:F2}";
                }
                else
                {
                    displayText = $"{group.Product.Name} - £{group.Product.Price:F2}";
                }
                listBoxProducts.Items.Add(displayText);
            }

            // Update total
            totalCost = selectedProducts.Sum(p => p.Price);
            lblTotal.Text = $"Total: £{totalCost:F2}";

            // Update stock displays
            UpdateStockDisplays();
        }

        private void UpdateStockDisplays()
        {
            foreach (Product product in allProducts)
            {
                // Find the stock label for this product
                foreach (Control control in panelProducts.Controls)
                {
                    if (control is Label label && label.Name == "lblStock_" + product.ProductCode)
                    {
                        label.Text = $"Stock: {product.Stock}";
                        label.ForeColor = product.Stock > 0 ? Color.DarkGreen : Color.Red;
                        break;
                    }
                }

                // Enable/disable product button based on stock
                foreach (Control control in panelProducts.Controls)
                {
                    if (control is Button button && button.Tag?.ToString() == product.ProductCode)
                    {
                        button.Enabled = product.Stock > 0 && !inCheckoutMode;
                        break;
                    }
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Please select at least one product before checking out.", "No Products Selected");
                return;
            }

            // Check if all products are still in stock
            var outOfStockProducts = selectedProducts
                .GroupBy(p => p.ProductCode)
                .Where(g => g.First().Stock < g.Count())
                .Select(g => g.First().Name)
                .ToList();

            if (outOfStockProducts.Any())
            {
                MessageBox.Show($"The following products are no longer available in the requested quantity: {string.Join(", ", outOfStockProducts)}", "Stock Issue");
                return;
            }

            EnterCheckoutMode();
        }

        private void EnterCheckoutMode()
        {
            inCheckoutMode = true;
            amountPaid = 0;

            // Disable all product buttons
            foreach (Control control in panelProducts.Controls)
            {
                if (control is Button)
                    control.Enabled = false;
            }

            // Enable coin buttons
            EnableCoinButtons();

            btnCheckout.Enabled = false;

            MessageBox.Show("Please drag coins/notes to the coin slot to make payment.", "Checkout Started");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0 && !inCheckoutMode)
            {
                MessageBox.Show("There is no active order to cancel.", "No Order");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this order? All selected items will be removed.",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetOrder();
            }
        }

        private void ResetOrder()
        {
            // Return products to stock (if they were deducted)
            foreach (var product in selectedProducts)
            {
                // Stock wasn't actually deducted until payment, so no need to return
            }

            // Reset all variables
            selectedProducts.Clear();
            totalCost = 0;
            amountPaid = 0;
            inCheckoutMode = false;

            // Update UI
            UpdateDisplay();

            // Re-enable product buttons (for in-stock items)
            UpdateStockDisplays();

            // Disable coin buttons
            DisableCoinButtons();

            btnCheckout.Enabled = true;

            MessageBox.Show("Order has been cancelled.", "Order Cancelled");
        }

        // Drag and Drop Events for Coins
        private void CoinButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!inCheckoutMode) return;

            Button coinButton = (Button)sender;
            coinButton.DoDragDrop(coinButton.Tag, DragDropEffects.Copy);
        }

        private void CoinSlot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(decimal)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CoinSlot_DragDrop(object sender, DragEventArgs e)
        {
            if (!inCheckoutMode) return;

            decimal coinValue = (decimal)e.Data.GetData(typeof(decimal));
            amountPaid += coinValue;

            lblTotal.Text = $"Total: £{totalCost:F2} | Paid: £{amountPaid:F2} | Due: £{Math.Max(0, totalCost - amountPaid):F2}";

            if (amountPaid >= totalCost)
            {
                CompletePayment();
            }
        }

        private void CompletePayment()
        {
            decimal change = amountPaid - totalCost;

            // Deduct stock for sold products
            foreach (var productGroup in selectedProducts.GroupBy(p => p.ProductCode))
            {
                Product product = allProducts.First(p => p.ProductCode == productGroup.Key);
                product.Stock -= productGroup.Count();
            }

            // Save updated stock to file
            SaveStockToFile();

            // Save transaction to file
            SaveTransactionToFile(change);

            // Show success message
            string message = $"Payment successful! Thank you for your purchase.\n";
            if (change > 0)
            {
                message += $"Change due: £{change:F2}";
            }

            MessageBox.Show(message, "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset for next customer
            ResetAfterPayment();
        }

        private void ResetAfterPayment()
        {
            selectedProducts.Clear();
            totalCost = 0;
            amountPaid = 0;
            inCheckoutMode = false;

            listBoxProducts.Items.Clear();
            lblTotal.Text = "Total: £0.00";

            UpdateStockDisplays();
            DisableCoinButtons();

            btnCheckout.Enabled = true;
        }

        // Drag and Drop for Product Removal
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
                picTrash.BackColor = Color.DarkRed;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Trash_DragDrop(object sender, DragEventArgs e)
        {
            picTrash.BackColor = Color.Red;

            if (inCheckoutMode) return;

            Product productToRemove = (Product)e.Data.GetData(typeof(Product));

            if (productToRemove != null)
            {
                // Remove the first occurrence of this product
                var itemToRemove = selectedProducts.FirstOrDefault(p => p.ProductCode == productToRemove.ProductCode);
                if (itemToRemove != null)
                {
                    selectedProducts.Remove(itemToRemove);
                    UpdateDisplay();
                    MessageBox.Show($"Removed {itemToRemove.Name} from your order.", "Item Removed");
                }
            }
        }

        private Product FindProductFromDisplayText(string displayText)
        {
            // Extract product name from display text
            string productName = displayText.Split(new[] { " x", " - " }, StringSplitOptions.None)[0];
            return allProducts.FirstOrDefault(p => displayText.Contains(p.Name));
        }

        private void SaveTransactionToFile(decimal change)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = Path.Combine(transactionsFolder, $"Transaction_{timestamp}.txt");

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("=== VENDING MACHINE RECEIPT ===");
                    writer.WriteLine($"Student ID: {studentNumber}");
                    writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine("--------------------------------");

                    // Write items with quantities
                    var groupedItems = selectedProducts
                        .GroupBy(p => p.Name)
                        .Select(g => $"{g.Key} x{g.Count()} @ £{g.First().Price:F2} = £{g.Count() * g.First().Price:F2}");

                    foreach (string item in groupedItems)
                    {
                        writer.WriteLine(item);
                    }

                    writer.WriteLine("--------------------------------");
                    writer.WriteLine($"TOTAL: £{totalCost:F2}");
                    writer.WriteLine($"AMOUNT PAID: £{amountPaid:F2}");
                    writer.WriteLine($"CHANGE: £{change:F2}");
                    writer.WriteLine("================================");
                }

                // Also append to main log file
                string logFile = Path.Combine(transactionsFolder, "AllTransactions.log");
                using (StreamWriter logWriter = new StreamWriter(logFile, true))
                {
                    logWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - £{totalCost:F2} - {studentNumber}");
                }
            }
            catch (Exception ex)
            {
                // Don't crash if file saving fails
                Console.WriteLine("Could not save transaction: " + ex.Message);
            }
        }

        // Form closing event to save stock
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveStockToFile();
        }
    }
}