﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class DetailOrderViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Total { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
