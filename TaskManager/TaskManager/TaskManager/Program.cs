using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TaskManager.DataBaseConfiguration;
using TaskManager.TaskServices.TaskActions;

class Program : DbContext
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Services.GetRequiredService<IMenuService>().StartMainMenu();
    }

    private static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.ClearProviders(); });
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContextPool<IDbStorage, DbStorage>(options =>
                {
                    options.UseSqlite("Data Source=Task.db");
                    options.UseLoggerFactory(ConsoleLoggerFactory);
                });
                //services.AddScoped<IDbStorage, DbStorage>();
                services.AddScoped<ICreateTaskService, CreateTaskService>();
                services.AddScoped<IShowTasksService, ShowTasksService>();
                services.AddScoped<IChangeStatusService, ChangeStatusService>();
                services.AddScoped<IValidator, Validator>();
                services.AddTransient<IMenuService, MenuService>();
            });
    }
}

