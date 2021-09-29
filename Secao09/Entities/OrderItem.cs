using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Secao09.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Price = product.Price;
            this.product = product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return product.Name + ", $"
                + Price.ToString("F2", CultureInfo.InvariantCulture) + ", "
                + "Quantity: " + Quantity + ", "
                + "Subtotal: $" + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
