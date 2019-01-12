using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            string name = input1[0] + " " + input1[1];
     Threeuple<string,string,string> tuple1 = new Threeuple<string,string,string>
                (name, input1[2],input1[3]);


            string[] input2 = Console.ReadLine().Split();
            int litersOfBeer = int.Parse(input2[1]);
            bool drunk;

            if (input2[2] == "drunk")
                drunk = true;
            else drunk = false;

 Threeuple<string, int,bool> tuple2 = new Threeuple<string, int,bool>
                (input2[0], litersOfBeer,drunk);


            string[] input3 = Console.ReadLine().Split();
            double dbl = double.Parse(input3[1]);
            Threeuple<string, double,string> tuple3 = new Threeuple<string, double,string>
                (input3[0], dbl,input3[2]);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);

        }
    }
}
