using Blazored.LocalStorage;
using Blazored.SessionStorage;
using KernelLogic.DataBaseObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using MudBlazor;
using MudBlazor.Services;
using PolimerWebProj.Shared.BasicObjects.JWT;
using PolimerWebProj.Shared.BasicServices;
using PolimerWebProj.Shared.Repository.BlogPost;
using PolimerWebProj.Shared.Repository.Image;
using PolimerWebProj.Shared.Repository.Product;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    //options.UseSqlServer("Server=faragos2_data; Initial Catalog=polimer;Integrated Security=false;User Id=faragos2_illegible; Password=abdalbaliISnothere@%$%");

    options.UseSqlServer(builder.Configuration["ConnectionStrings:MainData"]).EnableDetailedErrors().UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});
builder.Services.AddDbContext<IDentityContext>(options =>
{
    //options.UseSqlServer("Server=faragos2_data; Initial Catalog=polimer;Integrated Security=false;User Id=faragos2_illegible; Password=abdalbaliISnothere@%$%");
    options.UseSqlServer(builder.Configuration["ConnectionStrings:MainData"]).EnableDetailedErrors().UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IBlogPostRepo, BlogPostRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IImageRepo, ImageRepo>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<ITokenExtension, TokenExtension>();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("IllegibleCors", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("X-Pagination"));
});
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<ITokenExtension, TokenExtension>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IDentityContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton<HttpClient>(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature.Addresses.First();
    return new HttpClient { BaseAddress = new Uri(baseAddress) };
});
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IHttpRequestHandlerService, HttpRequestHandlerService>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.MaxDisplayedSnackbars = 2;
});
#region IDentity with jwt

var jwtSetting = new JwtSetting();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = jwtSetting.ValidateIssuer,
        ValidateAudience = jwtSetting.ValidateAudience,
        ValidateLifetime = jwtSetting.ValidateLifetime,
        ValidateIssuerSigningKey = jwtSetting.ValidateIssuerSigningKey,
        ValidIssuer = jwtSetting.ValidIssuer,
        ValidAudience = jwtSetting.ValidAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecuritySignInKey)),
    };
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("IllegibleCors");
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
//app.MapFallbackToFile("index.html");
app.MapFallbackToPage("/_Host");
app.Run();
