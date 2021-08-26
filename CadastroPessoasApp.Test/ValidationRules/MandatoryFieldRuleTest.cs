using CadastroPessoasApp.ValidationRules;
using FluentAssertions;
using System.Globalization;
using Xunit;

namespace CadastroPessoasApp.Test.ValidationRules
{
    public class MandatoryFieldRuleTest
    {
        private readonly MandatoryFieldRule _mandatoryFieldRule;

        public MandatoryFieldRuleTest()
        {
            _mandatoryFieldRule = new MandatoryFieldRule();
        }

        [Theory(DisplayName = "Field should be mandatory")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Field_Should_Be_Mandatory(string field)
        {
            var validationResult = _mandatoryFieldRule.Validate(field, new CultureInfo("pt-BR"));

            validationResult.IsValid.Should().BeFalse();
            validationResult.ErrorContent.Should().Be("Campo obrigatório.");
        }
    }
}
