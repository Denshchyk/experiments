using ABtesting.Dall.MainDbRepositories;
using ABtesting.DevicesExperiments;
using ABtesting.Experiments;
using ABtesting.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDevicesRepository, DevicesRepository>();
builder.Services.AddScoped<IExperimentRepository, ExperimentRepository>();
builder.Services.AddScoped<IDevicesExperimentRepository, DevicesExperimentRepository>();
builder.Services.AddTransient<IRandomProvider, RandomProvider>();
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddDbContextPool<ApplicationContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Applications")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();