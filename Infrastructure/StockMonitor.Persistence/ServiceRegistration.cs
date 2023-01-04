using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Repositories.Identity;
using StockMonitor.Domain.Entities.Common;
using StockMonitor.Persistence.Contexts;
using StockMonitor.Persistence.Repositories.Identity;
using StockMonitor.Persistence.Services;

namespace StockMonitor.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<StockMonitorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString));
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<StockMonitorDbContext>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
