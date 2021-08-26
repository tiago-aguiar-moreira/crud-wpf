using System.Globalization;
using System.Windows.Controls;

namespace CadastroPessoasApp.ValidationRules
{
    public class MandatoryFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            => string.IsNullOrEmpty(value?.ToString().Trim())
                ? new ValidationResult(false, "Campo obrigatório.")
                : ValidationResult.ValidResult;
    }
}
