﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }
       
    }
}
