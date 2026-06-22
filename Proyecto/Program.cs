using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Extensions;
using Proyecto.Services;
using Proyecto.Settings;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"--Environment: {builder.Environment.EnvironmentName}");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
    sqlServerOptionsAction: SqlOptions => { SqlOptions.EnableRetryOnFailure(); }) );

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<JwtService>();

builder.Services.AddCors(x =>
{
    x.AddPolicy(name: myAllowSpecificOrigins, builder => { 
        builder.WithOrigins("http://localhost:4200", "http://192.168.101.8:9095")
               .AllowAnyMethod()
               .AllowAnyHeader(); 
    });
});

var app = builder.Build();

app.UseSwaggerDocumentation();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.UseSwagger();
    //app.UseSwaggerUI();
//}
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
