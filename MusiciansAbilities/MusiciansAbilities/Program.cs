using AlertLogger;
using Microsoft.EntityFrameworkCore;
using MusiciansAbilities.Models;
using MusiciansAbilities.Services;

var builder = WebApplication.CreateBuilder(args);
builder.UseAlertLogger();
builder.Services.AddControllers();
builder.Services
    .AddHttpContextAccessor()
    .AddDbContext<DbResultsContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnectionString"]);
    })
    .AddCors(options=>
    {
        options.AddPolicy("CORS", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });
builder.Services
    .AddScoped<IDbService, DbService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseHttpsRedirection()
    .UseRouting()
    .UseCors("CORS")
    .UseStaticFiles()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Users}/{action=Index}");
    });
app.Run();