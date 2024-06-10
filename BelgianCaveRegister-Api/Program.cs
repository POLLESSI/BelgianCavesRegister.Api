using BelgianCaveRegister_Api.Tools;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Bll.Interfaces;
using BelgianCavesRegister.Bll.Services;
using BelgianCaveRegister_Api.Hubs;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BelgianCavesRegister.Models.Services;
using BelgianCavesRegister.Bll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(o => o.AddPolicy("mypolicy", options => options.WithOrigins("http://localhost:7044", "https://localhost:7267")
//                .AllowCredentials()
//                .AllowAnyHeader()
//                .AllowAnyMethod()));

builder.Services.AddCors(
//    opt =>
//{
//    opt.AddPolicy(name: "mypolicy", builder =>
//    {
//        builder.WithOrigins(new string[] { "http://localhost:7044", "https://localhost:7267" })
//        .WithHeaders(new string[] { "bibliography", "chat", "lambdada", "nowner", "nperson", "nuser", "scientificdata", "site", "weatherforecast" })
//        .WithMethods(new string[] { "notifynewbibliography", "notifynewchat", "notifynewlambdaData", "notifynewnowner", "notifynewnperson", "notifynewnuser", "notifynewscientificdata", "notifynewsite", "notifynewweatherforecast" });
//    });
//});
);
builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

// Injections

builder.Services.AddScoped<IBibliographyService, BibliographyService>();
builder.Services.AddScoped<IBibliographyRepository, BibliographyRepository>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<ILambdaDataService, LambdaDataService>();
builder.Services.AddScoped<ILambdaDataRepository, LambdaDataRepository>();
builder.Services.AddScoped<INOwnerService, NOwnerService>();
builder.Services.AddScoped<INOwnerRepository, NOwnerRepository>();
builder.Services.AddScoped<INPersonService, NPersonService>();
builder.Services.AddScoped<INPersonRepository, NPersonRepository>();
builder.Services.AddScoped<INUserService, NUserService>();
builder.Services.AddScoped<INUserRepository, NUserRepository>();
builder.Services.AddScoped<IScientificDataService, ScientificDataService>();
builder.Services.AddScoped<IScientificDataRepository, ScientificDataRepository>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

builder.Services.AddSignalR();

builder.Services.AddSingleton<BibliographyHub>();
builder.Services.AddSingleton<ChatHub>();
builder.Services.AddSingleton<LambdaDataHub>();
builder.Services.AddSingleton<NOwnerHub>();
builder.Services.AddSingleton<NPersonHub>();
//builder.Services.AddSingleton<NUserHub>();
builder.Services.AddSingleton<ScientificDataHub>();
builder.Services.AddSingleton<SiteHub>();
builder.Services.AddSingleton<WeatherForecastHub>();

builder.Services.AddScoped<TokenGenerator>();

//Declaration des différents niveaux de sécurité à mettre en place dans le controller grâce à l'attribut [Authorize("nom_de_la_police")]

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("adminpolicy", option => option.RequireRole("admin"));
    o.AddPolicy("modopolicy", option => option.RequireRole("admin", "modo"));
    o.AddPolicy("userpolicy", option => option.RequireAuthenticatedUser());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenGenerator.secretKey)),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

var app = builder.Build();

// Configure the HTTP Request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    //// The default HSTS is 30 days. You want to change this for production scenarios, see https://aka.ms/aspnetcore.hsts.
    //app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseExceptionHandler("/Home/Error");
    //// The default HSTS is 30 days. You want to change this for production scenarios, see https://aka.ms/aspnetcore.hsts.
    //app.UseHsts();
    //c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "belgiancavesregister_api");
    //}
}
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

//app.MapControllerRoute(
       //name: "default",
       //pattern: "{controller-Home}/{action=Index}/Iid?}"
//   );
app.MapControllers();

//app.UseRouting();
app.MapHub<BibliographyHub>("/bibliographyhub");
app.MapHub<ChatHub>("/chathub");
app.MapHub<LambdaDataHub>("/lambdadatahub");
app.MapHub<NOwnerHub>("/nownerhub");
app.MapHub<NPersonHub>("/npersonhub");
app.MapHub<NUserHub>("/nuserhub");
app.MapHub<ScientificDataHub>("/scientificdatahub");
app.MapHub<SiteHub>("/sitehub");
app.MapHub<WeatherForecastHub>("/weatherforecasthub");

app.Run();






