﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppDatabase.Models
{
    public class WindSpeed
    {
        public Guid Id { get; set; }
        public string Value { get; set; } = "null";
    }
}
