using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using RI.Novus.Core.Boundaries.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IExpedientRepositoryDummy, ExpedientRepositoryDummy>();
builder.Services.AddScoped<IAseguradoRepository, AseguradoRepository>();
builder.Services.AddScoped<IImmovableOwnersRepository, ImmovableOwnerRepository>();
builder.Services.AddScoped<IImmovablePropertyRepository, ImmovablePropertyRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.CustomSchemaIds(r => r.FullName); });


builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
