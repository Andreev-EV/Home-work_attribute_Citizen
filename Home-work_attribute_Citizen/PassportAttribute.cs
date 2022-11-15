using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Home_work_attribute_Citizen
{
    class PassportAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string pass)
            {
                Regex regex = new Regex(@"\d{2} \d{2} \d{6}");
                if (regex.IsMatch(pass))
                {
                    return true;
                }
                else
                {
                    ErrorMessage = "Верный формат для ввода паспорта: ХХ ХХ ХХХХХХ";
                    return false;
                }
            }
            return false;
        }
    }
}