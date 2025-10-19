using Core.Configuration;
using Core.Extention;
using Core.Model.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using WeddingServer.Dto.Model;
using WeddingServer.Static;

var builder = WebApplication.CreateBuilder(args);

// Tách phần cấu hình service ra hàm riêng
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Tách phần middleware pipeline ra hàm riêng
ConfigureMiddleware(app);

app.Run();


// ====================== CONFIG METHODS =======================

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // OpenAPI
    builder.Services.AddControllersWithViews();

    // Controllers & Auth
    services.AddControllers().AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
    services.AddAuthorization();

    

    // Cors + File Storage
    services.AddCorsService();
    services.AddFileStorage(configuration);

    string password = configuration["Password"] ?? throw new Exception("Password not setting!");
    DataStatic.PassHash = password.ToSha256();

    // MongoDB
    var dbSetting = configuration.GetSection("MongoSettings:DatabaseWedding1")
                                 .Get<MongoDbSettings>() ?? throw new Exception("MongoDB settings not found in configuration.");
    services.AddMongoService(
        new MongoDbModelMapping
        {
            DbSettings = dbSetting!,
            Models = [typeof(WishModel), typeof(GuestModel), typeof(WeddingConfigModel)]
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
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}
