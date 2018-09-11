using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Data.SqlClient;

namespace CacheAndDecoratorDesignPattern
{
    class Hotel : IHotel
    {
        private const string CacheKey = "hotelData";
        public List<HotelProduct> GetProducts()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(CacheKey))
            {
                return (List<HotelProduct>)cache.Get(CacheKey);
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = "Data Source=TAVDESK083;Initial Catalog=Travel;Integrated Security=True";
                sqlConnection.Open();
                string sqlSelectQuery = "select * from HotelProduct";
                List<HotelProduct> hotelValues = new List<HotelProduct>();
                SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, sqlConnection);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                
                int i = 0;
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        HotelProduct hotel = new HotelProduct();
                        hotel.HotelId = (string)sqlReader.GetValue(0);
                        hotel.HotelName = (string)sqlReader.GetValue(1);
                        hotel.AvailableRooms = (string)sqlReader.GetValue(2);
                        hotel.Fare = (string)sqlReader.GetValue(3);
                        hotel.IsBook = (string)sqlReader.GetValue(4);
                        hotelValues.Add(hotel);
                    }
                }
                sqlConnection.Close();
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheKey, hotelValues, cacheItemPolicy);

                return hotelValues;
            }
        }
    }
}
