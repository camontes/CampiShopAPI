﻿using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Repositories
{
    public interface IDetailOrderRepository
    {
        Task CreateDetailOrderAsync(DetailOrder detailOrder);
    }
}
