using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;
using ProjectMiniShop.Utility;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, EmailService>();

#region matar configuare db
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddIdentity<AppUser,IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    
    
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


#endregion
builder.Services.AddAutoMapper(typeof(MappingConf));
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration["Facebook:AppId"].ToString();
    options.AppSecret = builder.Configuration["Facebook:AppSecret"].ToString();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
