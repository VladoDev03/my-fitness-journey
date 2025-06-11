using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Utils
{
    public class NotInFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue <= DateTime.Today;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            string readableName = Regex.Replace(name, "(?<!^)([A-Z])", " $1");

            return $"{readableName} cannot be in the future.";
        }
    }
}
