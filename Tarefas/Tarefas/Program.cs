using Microsoft.EntityFrameworkCore;
using Tarefas.Context;
using Tarefas.Repository;
using Tarefas.Services;

var builder = WebApplication.CreateBuilder(args);
var permition = "_permition";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: permition,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
}
);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITarefasRepository, TarefasRepository>();
builder.Services.AddScoped<ITarefasService, TarefasService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(permition);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
