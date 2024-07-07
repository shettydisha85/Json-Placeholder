using Microsoft.Extensions.Options;
using JsonPost.Data;
using Microsoft.EntityFrameworkCore;
using JsonPost.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbOperations, DbOperations>();
builder.Services.AddTransient<IAddJsonPosts, AddJsonPosts>();
var connectionString = builder.Configuration.GetSection("Database").GetValue<string>("ConnectionString");

builder.Services.AddDbContextPool<PostDbContext>(options => 
options.UseSqlServer(connectionString)
);
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
