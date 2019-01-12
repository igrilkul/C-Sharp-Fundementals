using System;
using System.Collections.Generic;
using System.Text;

namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x1;
        private double y2;

        private double x2;
        private double y1;

        public Rectangle(string id, double width, double height, double x1,double y2)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x1 = x1;
            this.y2 = y2;

            this.x2 = x1 + width;
            this.y1 = y2 - height;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public double X1
        {
            get { return this.x1; }
            set { this.x1 = value; }
        }

        public double Y1
        {
            get { return this.y1; }
            set { this.y1 = value; }
        }

        public double X2
        {
            get { return this.x2; }
            set { this.x2 = value; }
        }

        public double Y2
        {
            get { return this.y2; }
            set { this.y2 = value; }
        }

        public string Intersects(Rectangle r2)
        {
            if (this.x2 < r2.x1
             || r2.x2 < this.x1
             || this.y2 < r2.y1
             || r2.y2 < this.y1)
            {
                return "false";
            }
            return "true";
        }
       
    }
}
