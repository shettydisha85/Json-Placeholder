using Microsoft.Extensions.Options;
using JsonPost.Data;
using Microsoft.EntityFrameworkCore;
using JsonPost.Services;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbOperations, DbOperations>();
builder.Services.AddTransient<IJsonPosts, JsonPosts>();
var connectionString = builder.Configuration.GetSection("Database").GetValue<string>("ConnectionString");

builder.Services.AddDbContextPool<PostDbContext>(options => 
options.UseSqlServer(connectionString)
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("/pages/index.html");

app.Run();
