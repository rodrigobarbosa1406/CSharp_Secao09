using System;
using Secao09.Entities;
using Secao09.Entities.Enums;

namespace Secao09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine();
            Console.WriteLine("Enter order data:");

            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(client, orderStatus);

            Console.WriteLine();
            Console.Write("How many items to this order? ");
            int items = int.Parse(Console.ReadLine());

            Console.WriteLine();

            for (int i = 1; i <= items; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");

                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(quantity, product);

                order.AddItem(orderItem);

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine(order.ToString());

            Console.WriteLine();
            Console.Write("What name of product that you want to remove? ");
            string nameProductRemove = Console.ReadLine();
            OrderItem itemRemove = new OrderItem(0, new Product(nameProductRemove, 0));

            order.RemoveItem(itemRemove);

            Console.WriteLine();

            Console.WriteLine(order.ToString());
        }
    }
}
