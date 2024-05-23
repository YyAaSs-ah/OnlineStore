using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.ApplicationServices.Products;
using OnlineStore.Core.RequestResponse.Products.Create;
using OnlineStore.EndPoint.WebAPI.Infrastructures.Middlewares;
using OnlineStore.EndPoint.WebAPI.Infrastructures.ServiceRegisterations;
using OnlineStore.Infrastructure.Sql.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStoreConnectionString")));

builder.Services.RegisterDependencies();
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateProductHandler).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
