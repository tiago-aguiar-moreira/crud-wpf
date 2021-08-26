using CadastroPessoasApp.ValidationRules;
using FluentAssertions;
using System.Globalization;
using Xunit;

namespace CadastroPessoasApp.Test.ValidationRules
{
    public class CpfRuleTest
    {
        private readonly CpfRule _cpfRule;

        public CpfRuleTest()
        {
            _cpfRule = new CpfRule();
        }

        [Theory(DisplayName = "CPF should be mandatory")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Cpf_Should_Be_Mandatory(string cpf)
        {
            var validationResult = _cpfRule.Validate(cpf, new CultureInfo("pt-BR"));

            validationResult.IsValid.Should().BeFalse();
            validationResult.ErrorContent.Should().Be("Campo obrigatório.");
        }

        [Theory(DisplayName = "CPF should contain eleven digitis")]
        [InlineData("897987987987987897")]
        [InlineData("564asd")]
        [InlineData("1")]
        public void Cpf_Should_Contain_Eleven_Digits(string cpf)
        {
            var validationResult = _cpfRule.Validate(cpf, new CultureInfo("pt-BR"));

            validationResult.IsValid.Should().BeFalse();
            validationResult.ErrorContent.Should().Be("O CPF deve conter 11 dígitos.");
        }
    }
}
