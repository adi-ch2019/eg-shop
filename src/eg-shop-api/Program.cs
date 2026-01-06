using MediatR;
using System.Reflection;
using EgShopApi.Domain.Services;
// using EgShopApi.Domain.Services.Inventory;
// using EgShopApi.Domain.Services.Payment;
// using EgShopApi.Domain.Services.Shipping;
using EgShopApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Register services
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ShippingService>();

// Register Grocery services
builder.Services.AddSingleton<EgShopApi.Domain.IGroceryRepository, EgShopApi.Infrastructure.InMemoryGroceryRepository>();
builder.Services.AddScoped<EgShopApi.Application.IGroceryService, EgShopApi.Application.GroceryService>();

// Add controllers
// Register global exception filter
builder.Services.AddControllers(options =>
{
    options.Filters.Add<EgShopApi.WebApi.Filters.GlobalExceptionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();


