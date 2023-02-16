using FitnessApp.Models.Options;
using FitnessApp.Models.Services.Application;
using FitnessApp.Models.Services.Infrastructure;
using GymApp.Models.Services.Application;
using GymApp.Models.Services.Infrastructure;
using GymApp.Models.Services.Insfrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

#region Services
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IUserService, EfCoreUserService>(); 
builder.Services.AddTransient<ILoginService, EfCoreLoginService>(); 
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


