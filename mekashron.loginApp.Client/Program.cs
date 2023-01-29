using Microsoft.Extensions.Configuration;
using mekashron.loginApp.BLL;
using mekashron.loginApp.Client;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

//In case if this test task would have required authtentication
//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = "ClientModel";
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    options.IdleTimeout = TimeSpan.FromMinutes(10000);
//    //options.Cookie.IsEssential = true;
//    //options.Cookie.SameSite = SameSiteMode.None;
//});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins("https://localhost:44320");
}));
builder.Services.AddAntiforgery(o =>
{
    o.SuppressXFrameOptionsHeader = true;
    o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
}
);
builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.AddInfrastructure(configuration);

var app = builder.Build();
var supportedCultures = new[] { "ru", "kk" };
var localizationOptions =
    new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
