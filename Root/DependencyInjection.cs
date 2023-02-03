using System;
using Application.Services;
using BackgroundWorker;
using BackgroundWorker.Services;
using Data.Persistence;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Root
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<INotifyService, NotifyService>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFilterService, FilterService>();

            services.AddHostedService<UpdateDataWorker>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
        }

        public static void AddDatabase(this IServiceCollection services)
        {
            var connectionString = "";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
