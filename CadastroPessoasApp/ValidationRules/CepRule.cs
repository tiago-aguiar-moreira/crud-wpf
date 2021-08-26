using System.Globalization;
using System.Windows.Controls;

namespace CadastroPessoasApp.ValidationRules
{
    public class CepRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputValue = value.ToString();

            if (string.IsNullOrEmpty(inputValue))
            {
                new ValidationResult(false, "Campo obrigatório.");
            }
            else if (inputValue.Length != 11)
            {
                new ValidationResult(false, "O CEP deve conter 8 dígitos.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
