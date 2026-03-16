using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clientes_DESKTOP.Utils
{
    public static class ValidationHelper
    {
        public static bool EmailValid(string email)
        {
            return Regex.IsMatch(email, @"^\S+@\S+\.\S+$");
        }

        public static bool PhoneValid(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9]{9}$");
        }

        public static bool DniValid(string dni)
        {
            return !string.IsNullOrWhiteSpace(dni);
        }

        public static bool DateValid(string date)
        {
            return DateTime.TryParse(date, out _);
        }
    }
}
