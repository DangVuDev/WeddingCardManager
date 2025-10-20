using Core.Configuration;
using Core.Extention;
using Core.Model.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using WeddingServer.Dto.Model;
using WeddingServer.Static;

var builder = WebApplication.CreateBuilder(args);

/// ====================== Kestrel HTTPS =======================
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(8080); // HTTP
//    options.ListenAnyIP(8081, listenOptions =>
//    {
//        listenOptions.UseHttps("certs/cert.pfx", "123456");
//    });
//});
/// ============================================================

// Tách phần cấu hình service ra hàm riêng
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Tách phần middleware pipeline ra hàm riêng
ConfigureMiddleware(app);

app.Run();

/// ====================== CONFIG METHODS =======================

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Controllers & Views
    services.AddControllersWithViews();

    services.AddControllers().AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
    services.AddAuthorization();

    // Cors + File Storage
    services.AddCorsService();
    services.AddFileStorage(configuration);

    // Password
    string password = configuration["Password"] ?? throw new Exception("Password not setting!");
    DataStatic.PassHash = password.ToSha256();

    // MongoDB
    var dbSetting = configuration.GetSection("MongoSettings:DatabaseWedding1")
                                 .Get<MongoDbSettings>() ?? throw new Exception("MongoDB settings not found in configuration.");
    services.AddMongoService(
        new MongoDbModelMapping
        {
            DbSettings = dbSetting!,
            Models = new[] { typeof(WishModel), typeof(GuestModel), typeof(WeddingConfigModel) }
        }
    );

    // Swagger
    services.AddSwaggerService();
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAll");

    // HTTPS redirection sẽ hoạt động nhờ Kestrel có HTTPS
    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.MapControllers();
}
