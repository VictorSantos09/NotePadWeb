using static Xunit.Assert;
using static Crosscutting.Validator.InputValidator;

namespace NotePad.Test.Validators
{
    public class InputValidatorTest
    {
        [Fact]
        public void IsValidText_ShouldBeFalse()
        {
            var actual = "string";

            var expected = IsValidText(actual);

            False(expected);
        }
        [Fact]
        public void IsValidText_ShouldBeTrue()
        {
            var actual = "Escola";

            var expected = IsValidText(actual);

            True(expected);
        }
    }
}
