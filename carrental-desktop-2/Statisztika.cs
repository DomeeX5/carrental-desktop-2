using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carrental_desktop_2
{
    internal class Statisztika
    {
        private static List<Car> cars = new List<Car>();
        public static void Run()
        {
            try
            {
                ReadData();
                CostsLessThan20000();
                CostsMoreThan26000();
                MostExpensiveCar();
                GroupedByBrand();
                Console.Write("Adjon meg egy rendszámot: ");
                string plate_number = Console.ReadLine();
                GetCarByPlateNumber(plate_number);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Nem sikerült csatlakozni az adatbázishoz!");
                Console.WriteLine(ex.Message);
            }
        }

        private static void CostsLessThan20000()
        {
            Console.WriteLine($"20.000 Ft-nál olcsóbb napidíjú autók száma: {LessThan20000Linq()}");
        }

        private static int LessThan20000Linq()
        {
            return cars.Where(car => car.Daily_cost < 2).Count();
        }

        private static void CostsMoreThan26000()
        {
            bool car_cost = cars.Any(car => car.Daily_cost > 26000);
            Console.WriteLine(car_cost ?
                "Van az adatok között 26.000 Ft-nál drágább napidíjú autó" 
                :
                "Nincs az adatok között 26.000 Ft-nál drágább napidíjú autó");
        }

        private static void MostExpensiveCar()
        {
            Car car = cars.MaxBy(car => car.Daily_cost);
            Console.WriteLine($"Legdrágább napidíjú autó: {car.License_plate_number} - {car.Brand} - {car.Model} - {car.Daily_cost} Ft");
        }

        private static void GroupedByBrand()
        {
            Console.WriteLine("Autók száma:");
            cars.GroupBy(car => car.Brand).ToList().ForEach(car => Console.WriteLine($"\t{car.Key}: {car.Count()}"));
        }

        private static void GetCarByPlateNumber(string plate_number)
        {
            Car car = cars.FirstOrDefault(car => car.License_plate_number == plate_number);
            if(car == null)
            {
                Console.WriteLine("Nincs ilyen autó");
            }
            else
            {
                Console.WriteLine(car.Daily_cost > 25000 ?
                    "A megadott autónapidíja nagyobb mint 25.000 Ft" 
                    :
                    "A megadott autónapidíja nem nagyobb mint 25.000 Ft");
            }
        }

        private static void ReadData()
        {
            DatabaseHandler handler = new DatabaseHandler();
            cars = handler.ReadData();
        }
    }
}
