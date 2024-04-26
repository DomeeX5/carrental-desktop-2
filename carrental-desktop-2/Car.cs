using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carrental_desktop_2
{
    internal class Car
    {
        private int id;
        private string license_plate_number;
        private string brand;
        private string model;
        private int daily_cost;

        public Car(int id, string license_plate_number, string brand, string model, int daily_cost)
        {
            this.id = id;
            this.license_plate_number = license_plate_number;
            this.brand = brand;
            this.model = model;
            this.daily_cost = daily_cost;
        }

        public int Id { get => id; }
        public string License_plate_number { get => license_plate_number; }
        public string Brand { get => brand;  }
        public string Model { get => model;  }
        public int Daily_cost { get => daily_cost; }
    }
}
