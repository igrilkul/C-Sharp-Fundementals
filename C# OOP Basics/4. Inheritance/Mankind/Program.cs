using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentTokens = Console.ReadLine().Split();

                string studentFirstName = studentTokens[0];
                string studentLastName = studentTokens[1];
                string facultyNumber = studentTokens[2];

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                string[] workerTokens = Console.ReadLine().Split();

                string workerkFirstName = workerTokens[0];
                string workerLastName = workerTokens[1];
                decimal weekSalary = decimal.Parse(workerTokens[2]);
                double hoursPerDay = double.Parse(workerTokens[3]);

                Worker worker = new Worker(workerkFirstName, workerLastName, weekSalary, hoursPerDay);

                Console.WriteLine(student);
                //Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
