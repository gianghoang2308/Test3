using ApiTest4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Đọc connection string từ file json
var connectionString = builder.Configuration.GetConnectionString("MyDb");
// Đăng ký DbContext vào DI container
builder.Services.AddDbContext<MyManagementContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });



var app = builder.Build();

// Cấu hình phục vụ các tệp tĩnh (cho ảnh, CSS, JS từ thư mục wwwroot)
app.UseStaticFiles();

// Nếu bạn muốn phục vụ thêm các tệp trong thư mục Views
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Views")),
    RequestPath = "/Views"
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();
