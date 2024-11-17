﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RaytingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }

    }
}
