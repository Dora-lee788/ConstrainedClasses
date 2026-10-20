using System;
using System.Collections.Generic;

namespace ConstrainedClasses
{
    public class Entity
    {
        public int Id { get; init; }
    }

    public class Repository<T> where T : Entity
    {
        private List<T> items = new();

        public void Add(T item) => items.Add(item);

        public T? GetById(int id) =>
            items.Find(item => item.Id == id);
    }

    public class Product : Entity
    {
        public string Name { get; init; } = "";
    }

    public class Customer : Entity
    {
        public string Email { get; init; } = "";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Product> products = new();
            products.Add(new Product { Id = 1, Name = "Ноутбук" });
            products.Add(new Product { Id = 2, Name = "Телефон" });

            Repository<Customer> customers = new();
            customers.Add(new Customer { Id = 1, Email = "user1@mail.com" });
            customers.Add(new Customer { Id = 2, Email = "user2@mail.com" });

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Найти товар");
                Console.WriteLine("2. Найти покупателя");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine() ?? "");

                    if (choice == 0)
                        break;

                    if (choice == 1)
                    {
                        Console.Write("Введите Id товара: ");
                        int id = int.Parse(Console.ReadLine() ?? "");

                        Product? product = products.GetById(id);

                        Console.WriteLine(product == null
                            ? "Товар не найден."
                            : $"{product.Id}: {product.Name}");
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Введите Id покупателя: ");
                        int id = int.Parse(Console.ReadLine() ?? "");

                        Customer? customer = customers.GetById(id);

                        Console.WriteLine(customer == null
                            ? "Покупатель не найден."
                            : $"{customer.Id}: {customer.Email}");
                    }
                    else
                    {
                        Console.WriteLine("Такого пункта нет.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введите целое число.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: число выходит за допустимые границы.");
                }
            }
        }
    }
}
