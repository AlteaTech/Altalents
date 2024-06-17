namespace Altalents.Commun.Helpers
{
    public static class DoubleHelper
    {
        public static double ParseDouble(object value)
        {
            double result;

            string doubleAsString = value.ToString();
            IEnumerable<char> doubleAsCharList = doubleAsString.ToList();

            if (doubleAsCharList.Count(ch => ch == '.' || ch == ',') <= 1)
            {
                double.TryParse(doubleAsString.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out result);
            }
            else
            {
                if (doubleAsCharList.Count(ch => ch == '.') <= 1
                    && doubleAsCharList.Count(ch => ch == ',') > 1)
                {
                    double.TryParse(doubleAsString.Replace(",", string.Empty),
                        System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out result);
                }
                else if (doubleAsCharList.Count(ch => ch == ',') <= 1
                    && doubleAsCharList.Count(ch => ch == '.') > 1)
                {
                    double.TryParse(doubleAsString.Replace(".", string.Empty).Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out result);
                }
                else
                {
                    throw new Exception($"Error parsing {doubleAsString} as double, try removing thousand separators (if any)");
                }
            }

            return result;
        }
    }
}
