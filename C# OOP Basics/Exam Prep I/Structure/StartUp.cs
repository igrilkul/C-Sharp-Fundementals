using System;
using System.Collections.Generic;

namespace StorageMaster
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StorageMaster sm = new StorageMaster();
            string input;
            while((input=Console.ReadLine())!="END")
            {
                try
                {
                    string[] tokens = input.Split();
                    switch(tokens[0])
                    {
                        case "AddProduct":
                            {
                                Console.WriteLine(sm.AddProduct(tokens[1], double.Parse(tokens[2])));
                                break;
                            }
                        case "RegisterStorage":
                            {
                                Console.WriteLine(sm.RegisterStorage(tokens[1], tokens[2]));
                                break;
                            }
                        case "SelectVehicle":
                            {
                                Console.WriteLine(sm.SelectVehicle(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "LoadVehicle":
                            {
                                List<string> products = new List<string>();
                                for(int i=1;i<tokens.Length;i++)
                                {
                                    products.Add(tokens[i]);
                                }
                                Console.WriteLine(sm.LoadVehicle(products));
                                break;
                            }
                        case "SendVehicleTo":
                            {
                                Console.WriteLine(sm.SendVehicleTo(tokens[1], int.Parse(tokens[2]), tokens[3]));
                                break;
                            }
                        case "UnloadVehicle":
                            {
                                Console.WriteLine(sm.UnloadVehicle(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "GetStorageStatus":
                            {
                                Console.WriteLine(sm.GetStorageStatus(tokens[1]));
                                break;
                            }
                    }
                }
                catch(InvalidOperationException ie)
                {
                    Console.WriteLine($"Error: {ie.Message}");
                }

                
            }

            Console.WriteLine(sm.GetSummary());

        }
    }
}
