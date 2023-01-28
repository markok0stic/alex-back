using Microsoft.EntityFrameworkCore;
using MusiciansAbilities.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDbContext<DbResultsContext>(options =>
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnectionString"]))
    .AddHttpContextAccessor()
    .AddCors(options=>
    {
        options.AddPolicy("CORS", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection(); 
app.UseRouting();
app.UseCors("CORS");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();