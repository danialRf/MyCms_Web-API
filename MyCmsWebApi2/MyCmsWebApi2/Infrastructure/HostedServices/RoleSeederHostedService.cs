using Microsoft.AspNetCore.Identity;

namespace MyCmsWebApi2.Infrastructure.HostedServices
{
    public class RoleSeederHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public RoleSeederHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleSeeder = new RoleSeeder(roleManager);
            await roleSeeder.SeedAsync();
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Perform any cleanup here
            return Task.CompletedTask;
        }
    }
}
