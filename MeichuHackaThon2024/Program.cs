using MeichuHackaThon2024Model.ContextModel;
using Microsoft.EntityFrameworkCore;
using MeichuHackaThon2024Services.DIService;  // 引用命名空間

var builder = WebApplication.CreateBuilder(args);

//4.2.8 在Program.cs中註冊及啟用Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<MeichuHackaThonDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeichuHackaThon2024DBContext"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 註冊其他服務
builder.Services.AddMeichuHackaThon2024Services();  // 使用你定義的注入方法

var app = builder.Build();

// 執行資料庫遷移
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<MeichuHackaThonDBContext>();

    // 自動執行資料庫遷移
    context.Database.Migrate();  // 這行會自動執行遷移

    SeedData.Initialize(service);  // 這行負責初始化資料
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//4.2.8 在Program.cs中註冊及啟用Session
//啟用seesion
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
