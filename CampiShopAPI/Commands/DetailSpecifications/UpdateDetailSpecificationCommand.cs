﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.DetailSpecifications
{
    public class UpdateDetailSpecificationCommand
    {
        public string Name { get; set; }
        public int SpecificationId { get; set; }
    }
}
