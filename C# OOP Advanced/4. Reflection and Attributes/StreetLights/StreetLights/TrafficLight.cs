using System;
using System.Collections.Generic;
using System.Text;

namespace StreetLights
{
   public class TrafficLight
    {
        private Color currentColor;

        public TrafficLight(string color)
        {
            this.CurrentColor = (Color)Enum.Parse(typeof(Color),color);
        }

        public Color CurrentColor { get => currentColor; set => currentColor = value; }

        public void Update()
        {
            int lastColor = (int)this.CurrentColor;
            this.CurrentColor = (Color)(++lastColor % Enum.GetNames
                (typeof(Color)).Length);
        }
    }
}
