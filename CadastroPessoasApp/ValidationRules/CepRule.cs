using System.Globalization;
using System.Windows.Controls;

namespace CadastroPessoasApp.ValidationRules
{
    public class CepRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputValue = value?.ToString().Trim();

            if (string.IsNullOrEmpty(inputValue))
            {
                return new ValidationResult(false, "Campo obrigatório.");
            }
            
            if (inputValue.Length != 11)
            {
                return new ValidationResult(false, "O CEP deve conter 8 dígitos.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
