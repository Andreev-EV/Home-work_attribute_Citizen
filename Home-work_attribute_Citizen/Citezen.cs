using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_attribute_Citizen
{
    internal class Citezen
    {
        [Required(ErrorMessage ="Не указано имя гражданина")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от {2} до {1}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения гражданина")]
        [RegularExpression(@"^\d{2}.\d{2}.\d{4}", ErrorMessage = "Формат даты рождения: ХХ.ХХ.ХХХХ")]
        public string BirthDate { get; set; }

        public string Address { get; set; }
        [RegularExpression(@"^8\(\d{3}\) \d{3}-\d{2}-\d{2}$", ErrorMessage = "Формат телефона для ввода: 8(XXX) XXX-XX-XX")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан паспорт")]
        [Passport]
        public string Passportе { get; set; }
        
        public Citezen(string name, string birthDate, string phone, string passportе, string address)
        {
            Name = name;
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
            Passportе = passportе;
        }

        public void CreateCitezen()
        {
            Citezen citezen = new Citezen(Name, BirthDate, Phone, Passportе, Address);
            var result = new List<ValidationResult>();
            var context = new ValidationContext(citezen);

            if(!Validator.TryValidateObject(citezen, context, result, true))
            {
                foreach (var error in result)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine($"Объект создан успешно:\n\tИмя гражд.: \t{citezen.Name}\n\tДата рождения: \t{citezen.BirthDate}" +
                    $"\n\tПаспорт: \t{citezen.Passportе}\n\tАдрес: \t\t{citezen.Address}\n\tТелефон: \t{citezen.Phone}");
        }

    }
}
