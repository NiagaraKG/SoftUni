﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get; }
        public string Color { get; }
        public string Start();
        public string Stop();
    }
}
