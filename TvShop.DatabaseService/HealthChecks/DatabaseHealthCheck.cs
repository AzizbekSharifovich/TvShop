using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TvShop.DatabaseService.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            bool isHealthy = await IsDatabaseConnectionOkAsync();

            return isHealthy ?
                HealthCheckResult.Healthy(description:"Database connection is OK") :
                HealthCheckResult.Unhealthy(description:"Database connection ERROR");
        }

        private Task<bool> IsDatabaseConnectionOkAsync()
        {
            return Task.FromResult(DateTime.Now.Millisecond % 2 == 0);
        }
    }
}
