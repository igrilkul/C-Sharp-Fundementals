using System;
using System.Collections.Generic;

namespace _7._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isMirrorred = true;
            string input = Console.ReadLine();
            if(input.Length%2!=0)
            {
                isMirrorred = false;
                
            }


            var leftSide = new Queue<char>();
            var rightSide = new Stack<char>();

            var leftHalf = input.Substring(0, (input.Length / 2));
            var rightHalf = input.Substring((input.Length / 2));

            for(int i=0;i<input.Length/2;i++)
            {
                //  { { (  ) } }
                //  1 2 3  4 5 6

                leftSide.Enqueue(leftHalf[i]);
                rightSide.Push(rightHalf[i]);
            }

            for(int i=0;i<input.Length/2;i++)
            {
                var leftSymbol = leftSide.Dequeue();
                var rightSymbol = rightSide.Pop();

                switch(leftSymbol)
                {
                    case '{':
                        {
                            if(rightSymbol!='}')
                            {
                                isMirrorred = false;
                            }
                            break;
                        }

                    case '[':
                        {
                            if(rightSymbol!=']')
                            {
                                isMirrorred = false;
                            }
                            break;
                        }

                    case '(':
                        {
                            if(rightSymbol!=')')
                            {
                                isMirrorred = false;
                            }
                            break;
                        }

                    default:
                        {
                            isMirrorred = false;
                            break;
                        }
                }
            }

            if(isMirrorred)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            Console.ReadKey();

        }
    }
}
