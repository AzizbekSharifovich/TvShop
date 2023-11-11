using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TvShop.DatabaseService.HealthChecks
{
    public class ConsistencyHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            bool isHealthy = await IsDbConsistentAsync();

            return isHealthy ? 
                HealthCheckResult.Healthy(description:"Database consistency OK") :
                HealthCheckResult.Unhealthy(description:"Databse consistency ERROR");
        }

        private Task<bool> IsDbConsistentAsync()
        {
            return  Task.FromResult(true);
        }
    }
}
