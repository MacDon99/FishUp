namespace FishUp.Extensions
{
    public static class StringExtensions
    {
        public static Guid ToGuid(this string value)
        {
            if (!Guid.TryParse(value, out Guid result))
                throw new ArgumentException("Cannot convert provided string to guid");
            return result;
        }
    }
}
