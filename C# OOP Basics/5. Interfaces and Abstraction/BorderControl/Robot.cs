﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        public string Id { get; }
        public string Model { get; }

        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
