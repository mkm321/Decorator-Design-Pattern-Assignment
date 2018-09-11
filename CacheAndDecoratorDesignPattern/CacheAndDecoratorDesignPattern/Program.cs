using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheAndDecoratorDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IHotel hotel = new Hotel();
            HotelDecorator hotelDecorator = new GetDataFromCache(hotel);
            Console.WriteLine("Getting value from database ");
            List<HotelProduct> hotels = hotelDecorator.GetProducts();
            for(int i = 0; i < hotels.Count; i++)
            {
                Console.WriteLine(hotels[i].HotelId);
                Console.WriteLine(hotels[i].HotelName);
                Console.WriteLine(hotels[i].AvailableRooms);
                Console.WriteLine(hotels[i].Fare);
                Console.WriteLine(hotels[i].IsBook);
            }
            Console.WriteLine("Getting value from Cache ");
            hotels = hotelDecorator.ProductFromCache();
            for (int i = 0; i < hotels.Count; i++)
            {
                Console.WriteLine(hotels[i].HotelId);
                Console.WriteLine(hotels[i].HotelName);
                Console.WriteLine(hotels[i].AvailableRooms);
                Console.WriteLine(hotels[i].Fare);
                Console.WriteLine(hotels[i].IsBook);
            }

            Console.ReadKey();
        }
    }
}
