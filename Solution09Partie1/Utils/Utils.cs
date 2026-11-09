using System.Globalization;

namespace Solution09Partie1.Utils
{
    public class Utils
    {
        public static DateOnly? ParseDateFromString(string input)
        {
            string[] allowedFormats = { "yyyyMMdd", "yyyy-MM-dd", "dd-MM-yyyy" };

            bool isValid = DateTime.TryParseExact(
                input,
                allowedFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate
            );

            if ( isValid )
                return DateOnly.FromDateTime(parsedDate);
            else
                return null;
        }

    }
}
