using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string[] doughInput = Console.ReadLine().Split();

            string flourType = doughInput[1];
            string technique = doughInput[2];

            
            double weight = double.Parse(doughInput[3]);

            try
            {
                Pizza pizza = new Pizza(pizzaInput[1], flourType, technique, weight);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = input.Split();
                    string type = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);
                    pizza.AddTopping(new Topping(type, toppingWeight));
                }

                Console.WriteLine(pizza.ToString());
                Console.ReadLine();
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.ReadLine();
            }
            
        }

       
            

    }
}
