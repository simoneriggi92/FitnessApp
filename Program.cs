using FitnessApp.Models.Services.Application;
using FitnessApp.Models.Services.Infrastructure;
using GymApp.Models.Services.Application;
using GymApp.Models.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddTransient<IUserService, MongoUserService>(); 
builder.Services.AddTransient<ILoginService, LoginService>(); 
builder.Services.Configure<AppDatabaseSettings>(builder.Configuration.GetSection("AppDatabase"));
builder.Services.AddSingleton<MongoUserService>();
// builder.Services.AddSingleton<LoginService>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();


