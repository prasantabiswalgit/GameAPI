﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApi.Data.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string ? Title { get; set; }
        public string ? Genre { get; set; }
        public string ? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int StockQuantity { get; set; }
    }
}
