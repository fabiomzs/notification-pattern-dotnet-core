using FabioMuniz.NotificationPattern.API.Filters;
using FabioMuniz.NotificationPattern.Application.Handlers;
using FabioMuniz.NotificationPattern.Domain.Interfaces;
using FabioMuniz.NotificationPattern.Domain.Notifications;
using FabioMuniz.NotificationPattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerHandler>();
builder.Services.AddScoped<NotificationHandler>();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<NotificationFilter>();
});
builder.Services.AddMemoryCache();

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
