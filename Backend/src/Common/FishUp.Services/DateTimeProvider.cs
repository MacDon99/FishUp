using FishUp.Services.Abstract;

namespace FishUp.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDateTime() => DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public DateTime GetCurrentDate() => DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
    }
}
