using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog(); // ! SERILOG

Log.Logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration).CreateLogger();
// .MinimumLevel.Information()
// .WriteTo.Console()
// .WriteTo.File("logs/myLogs-.txt", rollingInterval: RollingInterval.Day)
// .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(); // ! SERIAL REQUESTLOGGER MIDDLEWARE


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
