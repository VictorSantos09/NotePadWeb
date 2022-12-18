namespace Crosscutting.Validator
{
    public class InputValidator
    {
        public static bool IsValidText(string input)
        {
            return input != "string" || string.IsNullOrEmpty(input);
        }
    }
}
