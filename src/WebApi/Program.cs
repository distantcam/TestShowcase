using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Features;
using WebApi.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up Mediatr
builder.Services.AddMediatR(typeof(Program).Assembly);

// Set up database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
        );
});
builder.Services.AddTransient<IAppDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

// Register our modules
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule<AppModule>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // For development we just update the database.
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.Run();
