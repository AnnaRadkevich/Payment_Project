using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.BankClientInfo
{
    internal class User
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;

        public string Firstname { get; }
        public string Lastname { get; }
        public string PhoneNumber { get; }
        public User(string userFirtsName, string userLastName, string userPhoneNumber)
        {
            Firstname = userFirtsName;
            Lastname = userLastName;
            PhoneNumber = userPhoneNumber;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}, Phone number: {PhoneNumber}";
        }
    }
}
