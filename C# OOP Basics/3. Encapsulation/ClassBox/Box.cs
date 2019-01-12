﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double GetVolume()
        {
            return (this.length * this.width * this.height);
        }

        public double GetLateralSurface()
        {
            return 2 * (this.length * this.height) 
                + 2 * (this.width * this.height);
        }

        public double GetSurface()
        {
            return 2 * (this.length*this.width) 
                + 2 * (this.length * this.height) 
                + 2 * (this.width * this.height);
        }
    }
}
