using MeichuHackaThon2024Model.ContextModel;
using Microsoft.EntityFrameworkCore;

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeichuHackaThonDBContext"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
