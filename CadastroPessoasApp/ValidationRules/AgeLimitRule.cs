using System;
using System.Globalization;
using System.Windows.Controls;

namespace CadastroPessoasApp.ValidationRules
{
    public class AgeLimitRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputValue = value.ToString();

            if (string.IsNullOrEmpty(inputValue))
            {
                new ValidationResult(false, "Campo obrigatório.");
            }
            else if (inputValue.Length == 10)
            {
                if (DateTime.TryParse(inputValue, out var converted))
                {
                    var ageInYears = GetAge(converted);
                    if (ageInYears < 18)
                    {
                        new ValidationResult(false, "Cadastro permitido apenas para maiores de 18 anos.");
                    }
                }
            }

            return ValidationResult.ValidResult;
        }

        int GetAge(DateTime date)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - date.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (date.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
