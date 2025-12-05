namespace ReorderPointSystem.Services
{
    internal static class Validator
    {
        public static bool IsValidString(string? value, int minLength = 1, int maxLength = 50)
        {
            // Not null, empty, or only whitespace
            if (string.IsNullOrWhiteSpace(value))
                return false;

            // Between 1-50 characters
            if (value.Length < minLength || value.Length > maxLength)
                return false;

            // Only allow safe characters
            var pattern = @"^[a-zA-Z0-9\s_.()&-]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, pattern))
                return false;

            return true;
        }

        public static bool IsValidInt(int value, int min = 0, int max = int.MaxValue)
        {
            // Ensures the integer is within allowed bounds
            return value >= min && value <= max;
        }

        public static int SanitizeInt(string? input, int min = 0, int max = int.MaxValue, int fallback = -1)
        {
            if (string.IsNullOrWhiteSpace(input))
                return fallback;

            if (!int.TryParse(input, out int value))
                return fallback;

            if (value < min)
                return min;

            if (value > max)
                return max;

            return value;
        }
    }
}
