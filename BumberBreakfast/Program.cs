using BumberBreakfast.Services.DbServices;
using BumberBreakfast.Services.RepoServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    var settings = config.Build();
//    config.AddAzureAppConfiguration(options =>
//    {
//        options.Connect("Endpoint=https://myappconfig8492.azconfig.io;Id=xBlI;Secret=kyLxx4Lzk7A7RGe8hKT0KWHEOcbBhI/3RbzSeYbNmU4=");
//    });
//});

builder.Services.AddScoped<IBreakfastRepository, BreakfastRepository>();
//var connectionstring = builder.Configuration.GetSection("Comman:ConnectionString").GetValue<string>("dbpassword");

builder.Services.AddDbContext<BreakfastDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
//app.UseExceptionHandler("/errors");
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
