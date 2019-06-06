using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkRes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime();

            using (RestaurantsEntities context = new RestaurantsEntities())
            {
                List<Restaurant> restaurants = new List<Restaurant>()
                {
                    new Restaurant {Name = "Rena", Adress = "44/1 Mantashian St", Open = new DateTime(date.Year, date.Month, date.Day, 8, 30, 0).ToString("hh:mm tt"), Close = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).ToString("hh:mm tt")},
                    new Restaurant {Name = "Sherep", Adress = "1 Amiryan St", Open = new DateTime(date.Year, date.Month, date.Day, 8, 30, 0).ToString("hh:mm tt"), Close = new DateTime(date.Year, date.Month, date.Day, 23, 0, 0).ToString("hh:mm tt")},
                    new Restaurant {Name = "Dragon Garden", Adress = "76 Aram St", Open = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0).ToString("hh:mm tt"), Close = new DateTime(date.Year, date.Month, date.Day, 23, 0, 0).ToString("hh:mm tt")},
                    new Restaurant {Name = "Dolmama", Adress = "10 Pushkin St", Open = new DateTime(date.Year, date.Month, date.Day, 8, 30, 0).ToString("hh:mm tt"), Close = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).ToString("hh:mm tt")},
                    new Restaurant {Name = "Lavash", Adress = "21 Tumanian St", Open = new DateTime(date.Year, date.Month, date.Day, 9, 30, 0).ToString("hh:mm tt"), Close = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).ToString("hh:mm tt")}
                };

                foreach (var res in restaurants)
                {
                    context.Restaurants.Add(res);
                }
                context.SaveChanges();

            }
        }
    }
}
