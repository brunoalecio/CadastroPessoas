using CadastroPessoas.Application.Interfaces;
using CadastroPessoas.Infrastructure.SqlServer;
using CadastroPessoas.Infrastructure.SqlServer.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IViaCepService, ViaCepService>();

builder.Services.AddScoped<IPessoaProjectionRepository, PessoaProjectionRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<IPessoaWriteRepository, PessoaWriteRepository>();
builder.Services.AddScoped<IEventStoreRepository, EventStoreRepository>();

builder.Services.AddScoped<IPessoaReadRepository, PessoaReadRepository>();

builder.Services.AddMediatR(typeof(CreatePessoaFisicaCommand).Assembly);

builder.Services.AddSingleton<IMongoClient>(
    new MongoClient(builder.Configuration.GetConnectionString("Mongo")));

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("CadastroPessoasDB");
});

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
