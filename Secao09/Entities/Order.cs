using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Secao09.Entities.Enums;

namespace Secao09.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Client Client { get; set; }

        List<OrderItem> OrderItems = new List<OrderItem>();

        public Order()
        {
            Moment = DateTime.Now;
        }

        public Order(Client client, OrderStatus orderStatus) : this()
        {
            Client = client;
            OrderStatus = orderStatus;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }
        
        public void RemoveItem(OrderItem item)
        {
            OrderItem ItemRemove = OrderItems.Find(x => x.product.Name == item.product.Name);
            OrderItems.Remove(ItemRemove);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem obj in OrderItems)
            {
                sum += obj.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            string OrderSummary;
            int i = 1;

            OrderSummary = "ORDER SUMMARY\n";
            OrderSummary += "Order moment: " + Moment + "\n";
            OrderSummary += "Order status: " + OrderStatus.ToString() + "\n";
            OrderSummary += Client.ToString() + "\n\n";

            OrderSummary += "Order items:\n";
            
            foreach (OrderItem obj in OrderItems)
            {
                OrderSummary += $"#{i} - " + obj.ToString() + "\n";
                i++;
            }

            OrderSummary += "Total price: $";
            OrderSummary += Total().ToString("F2", CultureInfo.InvariantCulture);

            return OrderSummary;
        }
    }
}
