namespace Crosscutting.Validator
{
    public class RegisterValidator
    {
        public static string[] Formats { get; set; } = { "@HOTMAIL.COM", "@GMAIL.COM", "@YAHOO.COM.BR", @"OUTLOOK.COM", "@ICLOUD.COM" };

        public static bool IsValidName(string name)
        {
            return name.Length > 5 && name != "string";
        }
        public static bool IsValidEmail(string input)
        {
            if (ValidatorEmailFormat(Formats, input.ToUpper()))
                return true;

            return false;
        }
        private static bool ValidatorEmailFormat(string[] formats, string input)
        {
            foreach (var item in formats)
            {
                if (input.Contains(item))
                    return true;
            }
            return false;
        }
        public static bool IsValidPassword(string input)
        {
            return input.Length >= 4;
        }
    }
}