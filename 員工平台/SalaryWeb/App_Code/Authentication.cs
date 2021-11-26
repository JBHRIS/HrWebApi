using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryWeb
{
    public class Authentication
    {
        public static bool isAuthentication(string SalaryEmpId, string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(SalaryEmpId) || string.IsNullOrWhiteSpace(plainTextPassword))
            {
                return false;
            }
            return true;
        }
    }
}