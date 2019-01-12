using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    class GoldenEditionBook :Book
    {
        public GoldenEditionBook(string author,string title,decimal price):base(author,title,price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public override decimal Price
        {

            get
            {
                return base.Price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                else base.Price = value*(decimal)1.3;
            }

        }
    }
}
