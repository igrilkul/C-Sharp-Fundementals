using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> shoppersList = new List<Person>();
            List<Product> productsList = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var personString in peopleInput)
                {
                    string[] tokens = personString.Split('=');
                    Person person = new Person(tokens[0], decimal.Parse(tokens[1]));
                    shoppersList.Add(person);
                }

                string[] productsInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var productString in productsInput)
                {
                    string[] tokens = productString.Split('=');
                    Product product = new Product(tokens[0], decimal.Parse(tokens[1]));
                    productsList.Add(product);
                }

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split();
                    string personName = tokens[0];
                    string productName = tokens[1];

                    shoppersList.Find(x => x.Name == personName)
                        .Purchase(
                        productsList.Find(p => p.Name == productName)
                        );
                }

                foreach (var person in shoppersList)
                {
                    Console.WriteLine(person.ToString());
                }

                Console.ReadLine();
            }

            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
