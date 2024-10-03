using MeichuHackaThon2024Model.ContextModel;
using Microsoft.EntityFrameworkCore;
using MeichuHackaThon2024Services.DIService;  // �ޥΩR�W�Ŷ�

var builder = WebApplication.CreateBuilder(args);

//4.2.8 �bProgram.cs�����U�αҥ�Session
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

// ���U��L�A��
builder.Services.AddMeichuHackaThon2024Services();  // �ϥΧA�w�q���`�J��k

var app = builder.Build();

// �����Ʈw�E��
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<MeichuHackaThonDBContext>();

    // �۰ʰ����Ʈw�E��
    context.Database.Migrate();  // �o��|�۰ʰ���E��

    SeedData.Initialize(service);  // �o��t�d��l�Ƹ��
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//4.2.8 �bProgram.cs�����U�αҥ�Session
//�ҥ�seesion
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
