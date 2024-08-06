using Microsoft.EntityFrameworkCore;
using minimal_api_distributed_rate_limiting_redis.Data;
using minimal_api_distributed_rate_limiting_redis.Models;
using minimal_api_distributed_rate_limiting_redis.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("minimal-api-distributed-rate-limiting-redis"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    dbContext.Customers.AddRange(
        new Customer { Name = "Peter Parker", Email = "peter.parker@marvel.com" },
        new Customer { Name = "Mary Jane", Email = "mary.jane@marvel.com" },
        new Customer { Name = "Ben Parker", Email = "ben.parker@marvel.com" }
    );

    dbContext.SaveChanges();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/customers/", async (HttpContext context, AppDbContext dbContext) =>
{
    var ipAddress = context.Connection.RemoteIpAddress?.ToString();
    var key = $"minimal-api-distributed-rate-limiting-redis:customers:get:{ipAddress}";

    if (await RateLimiter.IsRateLimited(key, 10, 60))
        return Results.Problem("Too many requests. Please try again later.", statusCode: StatusCodes.Status429TooManyRequests);

    var customers = await dbContext.Customers.AsNoTracking().ToListAsync();

    return Results.Ok(customers);
});

app.MapPost("/customers/", async (Customer model, HttpContext context, AppDbContext dbContext) =>
{
    var ipAddress = context.Connection.RemoteIpAddress?.ToString();
    var key = $"minimal-api-distributed-rate-limiting-redis:customers:post:{ipAddress}";

    if (await RateLimiter.IsRateLimited(key, 5, 60))
        return Results.Problem("Too many requests. Please try again later.", statusCode: StatusCodes.Status429TooManyRequests);

    await dbContext.Customers.AddAsync(model);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/customers/{model.Id}", model);    
});

app.Run();
