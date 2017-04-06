using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_Transport 
{
    class Validation_Rules
    {
    }
    public class CharacterOnly : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            var ValidationResult = new ValidationResult(true, null);
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z]");
                    var sing = !regex.IsMatch(value.ToString());
                    if (!sing)
                    {
                        ValidationResult = new ValidationResult(false, "Character Only");

                    }
                }
            }
            return ValidationResult;
        }
    }
    public class NumberOnly : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            var ValidationResult = new ValidationResult(true, null);
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9]");
                    var sing = !regex.IsMatch(value.ToString());
                    if (!sing)
                    {
                        ValidationResult = new ValidationResult(false, "Number Only");

                    }
                }
            }
            return ValidationResult;
        }
    }
    public class NumericAndCharacter : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            var ValidationResult = new ValidationResult(true, null);
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z0-9]");
                    var sing = !regex.IsMatch(value.ToString());
                    if (!sing)
                    {
                        ValidationResult = new ValidationResult(false, "Numeric And Character Only");

                    }
                }
            }
            return ValidationResult;
        }
    }
    public class NumericAndCharacterWithSpace : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            var ValidationResult = new ValidationResult(true, null);
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z0-9 ]");
                    var sing = !regex.IsMatch(value.ToString());
                    if (!sing)
                    {
                        ValidationResult = new ValidationResult(false, "Numeric And Character With Space Only");

                    }
                }
            }
            return ValidationResult;
        }
    }
    public class NumberWithMinus : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            var ValidationResult = new ValidationResult(true, null);
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^-0-9]");
                    var sing = !regex.IsMatch(value.ToString());
                    if (!sing)
                    {
                        ValidationResult = new ValidationResult(false, "Number With Minus");
                    }
                }
            }
            return ValidationResult;
        }
    }
    public class DecimalNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            var ValidationResult = new ValidationResult(true, null);
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9.]");
                    var sing = !regex.IsMatch(value.ToString());
                    if (!sing)
                    {
                        ValidationResult = new ValidationResult(false, "Decimal Number Only");

                    }
                }
            }
            return ValidationResult;
        }
    }
}
