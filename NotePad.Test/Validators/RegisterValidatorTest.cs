using static Xunit.Assert;
using static Crosscutting.Validator.RegisterValidator;

namespace NotePad.Test.Validators
{
    public class RegisterValidatorTest
    {
        [Fact]
        public void IsValidName_ShouldBeFalse()
        {
            var actual = "Ana";

            var expected = IsValidName(actual);

            False(expected);
        }
        [Fact]
        public void IsValidName_ShouldBeTrue()
        {
            var actual = "Thiago";

            var expected = IsValidName(actual);

            True(expected);
        }
        [Fact]
        public void IsValidEmail_ShouldBeFalse()
        {
            var actual = "VICTOR@GMIL.COM";

            var expected = IsValidEmail(actual);

            False(expected);
        }
        [Fact]
        public void IsValidEmail_ShouldBeTrue()
        {
            var actual = "VICTOR@HOTMAIL.COM";

            var expected = IsValidEmail(actual);

            True(expected);
        }
        [Fact]
        public void IsValidPassword_ShouldBeFalse()
        {
            var actual = "123";

            var expected = IsValidPassword(actual);

            False(expected);
        }
        [Fact]
        public void IsValidPassword_ShouldBeTrue()
        {
            var actual = "12345";

            var expected = IsValidPassword(actual);

            True(expected);
        }
    }
}