using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Services
{
    public static class OpMonths
    {
        private const int TOTAL_MONTHS = 12;
        public static int YearsToMonths(int years) 
        { 
            return (years * TOTAL_MONTHS); 
        }
    }
}
