using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace ProSoft.Models
{
    public class ProductInfo
    {
        public string ProductCode { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string MeasureUnit { get; set; } = "";
        public double Quantity { get; set; }
        public string Category { get; set; } = "";
        public double Price { get; set; }
        public string ImagePath { get; set; } = "";// Đường dẫn đến file ảnh
        public Image GetProductImage()
        {
            if (string.IsNullOrEmpty(this.ImagePath))
                return Properties.Resources.default_product;

            try
            {
                return File.Exists(this.ImagePath)
                    ? Image.FromFile(this.ImagePath)
                    : Properties.Resources.default_product;
            }
            catch
            {
                return Properties.Resources.default_product;
            }
        }
        public double TotalPrice => Math.Round(Quantity * Price, 0);
    }

}