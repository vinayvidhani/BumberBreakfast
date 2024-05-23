using BumberBreakfast.Services.DbServices;
using BumberBreakfast.Services.RepoServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBreakfastRepository, BreakfastRepository>();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var settings = config.Build();
    config.AddAzureAppConfiguration(options =>
    {
        options.Connect(builder.Configuration.GetConnectionString("AppConfig"));
    });
});


var connectionstring = builder.Configuration.GetSection("common:setting").GetValue<string>("connectionstring");


builder.Services.AddDbContext<BreakfastDbContext>(options => options.UseSqlServer(connectionstring));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
//app.UseExceptionHandler("/errors");
app.UseDeveloperExceptionPage();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
