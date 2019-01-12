using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
   public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                else this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                string[] fullName = value
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string secondName = fullName[1];

                if (char.IsDigit(secondName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                else this.author = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                else this.price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder
                .AppendLine($"Type: { this.GetType().Name}")
                .AppendLine($"Title: { this.Title}")
                .AppendLine($"Author: { this.Author}")
                .AppendLine($"Price: { this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
