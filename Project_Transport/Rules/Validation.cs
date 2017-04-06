using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Input;

namespace Project_Transport
{
   public class Validation
    {
        public void PreviewTextInput(object sender, TextCompositionEventArgs e) 
        {
            if (e.Text != "." && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ".")
            {
                
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;                 
                }
            }
        }
        public void PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "," && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ",")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
        }
        int i = 0;
        public void PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            Get_String g = new Get_String();
            string s = g.Vehicle_Number;
            if(!string.IsNullOrWhiteSpace(s))
            {
                 i = s.Length;
            }
            
            if(i<2)
            {
                if (IsNumber(e.Text) == false)
                {
                    
                    i++;
                }
                else if(IsNumber(e.Text) == true)
                {
                    e.Handled = true;
                }
                    
                //else if (e.Text == ".")
                //{
                //    if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                //    {
                //        e.Handled = true;
                //    }
                //}
            } 
            else
            {
                i = 1;
            }                    
           
        }
       
        private bool IsNumber(string text)
        {
            int output;
            return int.TryParse(text, out output);
        }
       

    }

    public class NumericRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Number Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericWithDotRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9.]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Number Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericWithCamaRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9,]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Number & , Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class CharacterRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z.]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and (.) Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class CharacterWithSlashRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z/-]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and (/,-) Only");
                    }
                }
            }

            return validationResult;
        }
    }   
    public class OnlyCharacterRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class CharacterWithSpaceRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z ]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and Space Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericWithCharacterRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and Numbers Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class DecimalRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString())) 
                {
                    var regex = new Regex(@"(?=\.\d\d\d)(?=[^0-9])"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Decimal Value Only");
                    }
                }
            }


            return validationResult;
        }
    }
    public class CharacterNumericSpecialRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z./, ]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Character,Number,(.,/) Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class CharacterWithSpecialRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z.:]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Character,Number,(.,:) Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericWithCharacterSpaceRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null); 

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z ]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and Numbers Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericWithCharacterSpaceDotRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z. ]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and Numbers Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericWithCharacterhifenRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z-]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and Numbers Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class CharacterSpaceCommaRule : ValidationRule  
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^a-zA-Z, ]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericCommaRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9,]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Numbers Only");
                    }
                }
            }

            return validationResult;
        }
    }
    public class NumericCharacterCommaRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9a-zA-Z,]"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Characters and Numbers Only");
                    }
                }
            }

            return validationResult;
        }
    }
}
