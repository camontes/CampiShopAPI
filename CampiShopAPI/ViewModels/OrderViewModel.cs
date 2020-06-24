using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public double Total { get; set; }
        public int Rating { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Username { get; set; }
        public int StateOrderId { get; set; }
        public string StateOrderName { get; set; }
    }
}
