using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.BankClientInfo
{
    internal class Adress
    {
        private string _City;
        private string _Street;
        private int _houseNumber;
        private int _flatNumber;

        public string City { get; }
        public string Street { get; }
        public int HouseNumber { get; }

        public int FlatNumber { get; }

        public Adress(string city, string street, int houseNumber, int flatNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }

        public override string ToString()
        {
            return $"City: {City}, Street: {Street}, House: {HouseNumber}, Apartment: {FlatNumber}";
        }
    }
}
