using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheAndDecoratorDesignPattern
{
    public abstract class HotelDecorator : IHotel
    {
        private IHotel _hotel;
        public HotelDecorator(IHotel hotel)
        {
            _hotel = hotel;
        }
        public List<HotelProduct> GetProducts()
        {
            return _hotel.GetProducts();
        }
        public abstract List<HotelProduct> ProductFromCache();
    }
}
