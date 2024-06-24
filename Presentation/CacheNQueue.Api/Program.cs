using CacheNQueue.Persistence;
using CacheNQueue.Application;
using CacheNQueue.Api.Middlewares;
using CacheNQueue.Infrastructure;
using CacheNQueue.Api.Middlewares.Filter;
using CacheNQueue.Api.Middlewares.Filter.Validation;
using CacheNQueue.Api.Middlewares.Filter.CacheNQueue.Api.Middlewares.Filter;
using FluentValidation.AspNetCore;
using CacheNQueue.Application.Validation;
var builder = WebApplication.CreateBuilder(args); 
// Add services to the container.
builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddAplicationService();
builder.Services.AddInfrastructureService();
builder.Services.addJwtHandler(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
