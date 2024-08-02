using Dinely.Application.Common.Interfaces.Services;

namespace Dinely.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
