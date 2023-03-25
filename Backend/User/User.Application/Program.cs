using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.Application;
using User.Application.Services;
using User.Infrastructure.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

// === CONFIGURE SERVICES ===
services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<UserDbContext>(options =>
{
    options.UseInMemoryDatabase("UserDatabase");
});

services.AddScoped<IPasswordService, PasswordService>();

services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(AssemblyPointer).Assembly);
});
services.AddAutoMapper(typeof(AssemblyPointer));

// === APP RUN ===
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();