using CadastroPessoasApp.ValidationRules;
using FluentAssertions;
using System.Globalization;
using Xunit;

namespace CadastroPessoasApp.Test.ValidationRules
{
    public class CepRuleTest
    {
        private readonly CepRule _cepRule;

        public CepRuleTest()
        {
            _cepRule = new CepRule();
        }

        [Theory(DisplayName = "Zip code should be mandatory")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Zip_Code_Should_Be_Mandatory(string zipCode)
        {
            var validationResult = _cepRule.Validate(zipCode, new CultureInfo("pt-BR"));

            validationResult.IsValid.Should().BeFalse();
            validationResult.ErrorContent.Should().Be("Campo obrigatório.");
        }

        [Theory(DisplayName = "Zip code should contain eight digitis")]
        [InlineData("897987987987987897")]
        [InlineData("564asd")]
        [InlineData("1")]
        public void Zip_Code_Should_Contain_Eight_Digits(string zipCode)
        {
            var validationResult = _cepRule.Validate(zipCode, new CultureInfo("pt-BR"));

            validationResult.IsValid.Should().BeFalse();
            validationResult.ErrorContent.Should().Be("O CEP deve conter 8 dígitos.");
        }
    }
}
