using FitnessApp.Models.Entities;
using GymApp.Customizations.Identity;
using GymApp.Models.Services.Application;
using GymApp.Models.Services.Insfrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
// Add services to the container.
builder.Services.AddMvc();

#region Services

// var connectionString ="Data Source=Data/gymApp.db";
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlite(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit =true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredUniqueChars = 4;

}).
AddPasswordValidator<CommonPasswordValidator<ApplicationUser>>()
.AddEntityFrameworkStores<AppDbContext>();

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<AppDbContext>();
// builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<AppDbContext>(item =>item.UseSqlite(builder.Configuration.GetConnectionString("AppDbContextConnection")));

builder.Services.AddDbContext<AppDbContext>();
// builder.Services.AddTransient<IUserService, EfCoreUserService>(); 
// builder.Services.AddTransient<ILoginService, EfCoreLoginService>(); 
#endregion


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllers();
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

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(routeBuilder=> {
    routeBuilder.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}" );
    routeBuilder.MapRazorPages();
});

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();



app.Run();


