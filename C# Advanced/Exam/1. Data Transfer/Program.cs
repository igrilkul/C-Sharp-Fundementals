using System;
using System.Text.RegularExpressions;

namespace _1._Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex messageRegex = new Regex(@"s:([^;]+);r:([^;]+);m--""([\w ]+)""");
            Regex nameRegex = new Regex(@"[a-zA-Z ]");
            Regex digitsRegex = new Regex(@"[\d]");

            int n = int.Parse(Console.ReadLine());
            int dataSize = 0;
            for(int i=0;i<n;i++)
            {
                string message = Console.ReadLine();
                if(messageRegex.IsMatch(message))
                {
                    Match validMessage = messageRegex.Match(message);
                    string sender = validMessage.Groups[1].Value;
                    string receiver = validMessage.Groups[2].Value;
                    string messageText = validMessage.Groups[3].Value;


                    MatchCollection senderCollection = nameRegex.Matches(sender);
                    MatchCollection receiverCollection = nameRegex.Matches(receiver);

                    string senderName="";
                    foreach(Match letter in senderCollection)
                    {
                        senderName += letter.Value; 
                    }

                    string receiverName = "";
                    foreach(Match letter in receiverCollection)
                    {
                        receiverName += letter.Value;
                    }

                    MatchCollection senderDigits = digitsRegex.Matches(sender);
                    MatchCollection receiverDigits = digitsRegex.Matches(receiver);

                    foreach(Match digit in senderDigits)
                    {
                        dataSize += int.Parse(digit.Value);
                    }

                    foreach (Match digit in receiverDigits)
                    {
                        dataSize += int.Parse(digit.Value);
                    }

                    

                    Console.WriteLine($"{senderName} says \"{messageText}\" to {receiverName}");
                }
            }
            Console.WriteLine($"Total data transferred: {dataSize}MB");
            Console.ReadLine();
        }
    }
}
