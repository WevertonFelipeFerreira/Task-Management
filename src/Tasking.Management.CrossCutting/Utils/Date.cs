namespace Tasking.Management.CrossCutting.Utils
{
    public static class Date
    {
        public static string GetCurrentUnixTime()
        {
            string dateStart = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:sszzz");
            DateTime Start = DateTime.ParseExact(dateStart, "yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture);

            long unixStart = (long)Start
                .ToUniversalTime()
                .Subtract(DateTime.UnixEpoch)
                .TotalSeconds;

            return unixStart.ToString();
        }
    }
}
