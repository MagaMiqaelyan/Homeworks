using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Context cntxt = new Context();
            cntxt.Database.Log = Console.WriteLine;
            //List<Cars> crs = new List<Cars>() {
            //    new Cars{ Id = 1, Model = "BMW", Year = "2010" },
            //    new Cars{ Id = 2, Model = "Audi", Year = "2008" },
            //    new Cars{ Id = 3, Model = "Opel", Year = "2005" },
            //    new Cars{ Id = 4, Model = "TOYOTA", Year = "2018" },
            //    new Cars{ Id = 5, Model = "RENO", Year = "2001" },
            //    new Cars{ Id = 6, Model = "JEEP", Year = "1999" },
            //};
            //List<Prices> prs = new List<Prices>() {

            //    new Prices{ Id = 1, Price = 18000},
            //    new Prices{ Id = 1, Price = 20000},
            //    new Prices{ Id = 1, Price = 30000},
            //    new Prices{ Id = 2, Price = 1000},
            //    new Prices{ Id = 2, Price = 5000},
            //    new Prices{ Id = 3, Price = 10000},
            //    new Prices{ Id = 3, Price = 12000},
            //    new Prices{ Id = 4, Price = 10000},
            //    new Prices{ Id = 4, Price = 13000},
            //    new Prices{ Id = 5, Price = 10000},
            //    new Prices{ Id = 5, Price = 16000},
            //    new Prices{ Id = 6, Price = 10000},
            //    new Prices{ Id = 6, Price = 11000},

            //};

            //crs.ForEach(Item => cntxt.Cars.Add(Item));
            //prs.ForEach(Item => cntxt.Prices.Add(Item));
            //cntxt.SaveChanges();

            List<Cars> lstCars = cntxt.Cars.ToList();
            List<Prices> lstPrice = cntxt.Prices.ToList();

            var result = (from a in lstCars
                          join b in lstPrice on a.Id equals b.Id
                          select new { md = a.Model, yr = a.Year, pr = b.Price }).ToList();


            foreach (var item in result)
            {
                Console.WriteLine(item.md + "   " + item.yr + "   " + item.pr);
            }
        }
    }
}
