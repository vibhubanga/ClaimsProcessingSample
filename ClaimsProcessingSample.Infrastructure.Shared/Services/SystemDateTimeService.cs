using ClaimsProcessingSample.Application.Interfaces.Services;
using System;

namespace ClaimsProcessingSample.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}