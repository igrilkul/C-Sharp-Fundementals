using System;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            input = Console.ReadLine();
            string[] elements = input.Split().Skip(1).ToArray();

            ListyIterator<string> listy = new ListyIterator<string>(elements);

            try
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split();

                    switch (tokens[0])
                    {
                        case "Move":
                            {
                                Console.WriteLine(listy.Move());
                                break;
                            }
                        case "HasNext":
                            {
                                Console.WriteLine(listy.HasNext());
                                break;
                            }
                        case "Print":
                            {
                                listy.Print();
                                break;
                            }
                        case "PrintAll":
                            {
                                listy.PrintAll();
                                break;
                            }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
