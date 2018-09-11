using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheAndDecoratorDesignPattern
{
    public interface IHotel
    {
        List<HotelProduct> GetProducts();
    }
}
