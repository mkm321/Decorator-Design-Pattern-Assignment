using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheAndDecoratorDesignPattern
{
    public class HotelProduct
    {
        public string HotelName { get; set; }
        public string HotelId { get; set; }
        public string AvailableRooms { get; set; }
        public string Fare { get; set; }
        public string IsBook { get; set; }
    }
}
