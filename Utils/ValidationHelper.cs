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
        public static bool ValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool ValidPhone(string phone)
        {
            return phone.Length >= 7;
        }

        public static bool ValidDNI(string dni)
        {
            return !string.IsNullOrWhiteSpace(dni);
        }
    }
}
