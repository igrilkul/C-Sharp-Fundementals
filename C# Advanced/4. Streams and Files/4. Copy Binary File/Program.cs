using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream opener = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream copier = new FileStream("copied.png", FileMode.Create))
                {
                    while(true)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = opener.Read(buffer, 0, buffer.Length);
                        if(readBytes==0)
                        {
                            break;
                        }
                        copier.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
