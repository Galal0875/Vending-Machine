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

        public Product(string name, decimal price, int stock, Image image, string code)
        {
            Name = name;
            Price = price;
            Stock = stock;
            ProductImage = image;
            ProductCode = code;
        }
    }

    public class Transaction
    {
        public DateTime TransactionTime { get; set; }
        public System.Collections.Generic.List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public string StudentNumber { get; set; }
    }
}