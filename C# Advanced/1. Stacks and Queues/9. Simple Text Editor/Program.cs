using System;
using System.Collections.Generic;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = String.Empty;
            var undo = new Stack<string>();

            var n = int.Parse(Console.ReadLine());

            for(int i=0;i<n;i++)
            {
                string[] input = Console.ReadLine().Split();

                switch(input[0])
                {
                    case "1":
                        {
                            undo.Push(text);
                            text += input[1];
                            break;
                        }

                    case "2":
                        {
                            undo.Push(text);
                            int countToRemove = int.Parse(input[1]);
                            text = text.Substring(0, text.Length - countToRemove);
                            break;
                        }

                    case "3":
                        {
                            int index = int.Parse(input[1])-1;
                            Console.WriteLine(text[index]);
                            break;
                        }

                    case "4":
                        {
                            text = undo.Pop();
                            break;
                        }
                }
            }
        }
    }
}
