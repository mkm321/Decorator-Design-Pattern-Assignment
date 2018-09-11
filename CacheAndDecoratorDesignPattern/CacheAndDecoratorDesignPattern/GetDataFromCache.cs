using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheAndDecoratorDesignPattern
{
    class GetDataFromCache: HotelDecorator
    {
        public GetDataFromCache(IHotel hotel) : base(hotel) { }
        public override List<HotelProduct> ProductFromCache()
        {
            return base.GetProducts();
        }
    }
}
