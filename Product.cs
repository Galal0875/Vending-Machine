using System;
using System.Drawing;

namespace VendingMachine
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Image ProductImage { get; set; }
        public string ProductCode { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, int stock, Image image, string code, string imagePath = "", string category = "Beverage")
        {
            Name = name;
            Price = price;
            Stock = stock;
            ProductImage = image;
            ProductCode = code;
            ImagePath = imagePath;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} - £{Price:F2} (Stock: {Stock})";
        }
    }

    public class Transaction
    {
        public string InvoiceNumber { get; set; }
        public DateTime TransactionTime { get; set; }
        public System.Collections.Generic.List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public string StudentNumber { get; set; }

        public Transaction()
        {
            Products = new System.Collections.Generic.List<Product>();
            TransactionTime = DateTime.Now;
        }
    }

    public class VendingMachineSettings
    {
        public string MachineId { get; set; }
        public string Location { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalTransactions { get; set; }
        public DateTime LastRestock { get; set; }

        public VendingMachineSettings()
        {
            MachineId = "VM-001";
            Location = "University Campus";
            LastRestock = DateTime.Now;
        }
    }
}