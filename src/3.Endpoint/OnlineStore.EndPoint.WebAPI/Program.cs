using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineStore.Core.ApplicationServices.Products;
using OnlineStore.Core.RequestResponse.Products.Create;
using OnlineStore.EndPoint.WebAPI.Infrastructures.ServiceRegisterations;
using OnlineStore.Infrastructure.Sql.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStoreConnectionString")));

builder.Services.RegisterRepositories();
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateProductHandler).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
