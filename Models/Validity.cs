using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models
{
    internal class Validity
    {
        private DateOnly _date;

        public Validity(int year, int month, int day = 1)
        {
            _date = new DateOnly(year, month, day);
        }
        public override string ToString()
        {
            return $"{_date.Month}/{_date.Year}";
        }
    }
}
