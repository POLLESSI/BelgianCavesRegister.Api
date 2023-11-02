using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BelgianCavesRegister.Api.Tools;
using BelgianCavesRegister.Bll.Services;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Api.Hubs;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BelgianCavesRegister.Models.Services;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Bll;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection, SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

// Injections

//builder.Services.AddScoped<IBibliographyService, BibliographyService>();
//builder.Services.AddScoped<IBibliographyRepository, BibliographyRepository>();
//builder.Services.AddScoped<ILambdaDataService, LambdaDataService>();
//builder.Services.AddScoped<ILambdaDataRepository, LambdaDataRepository>();
//builder.Services.AddScoped<INOwnerService, NOwnerService>();
//builder.Services.AddScoped<INOwnerRepository, NOwnerRepository>();
//builder.Services.AddScoped<INPersonService, NPersonService>();
//builder.Services.AddScoped<INPersonRepository, NPersonRepository>();
builder.Services.AddScoped<INUserService, NUserService>();
builder.Services.AddScoped<INUserRepository, NUserRepository>();
//builder.Services.AddScoped<IScientificDataService, ScientificDataService>();
//builder.Services.AddScoped<IScientificDataRepository, ScientificDataRepository>();
//builder.Services.AddScoped<ISiteService, SiteService>();
//builder.Services.AddScoped<ISiteRepository, SiteRepository>();

builder.Services.AddScoped<TokenGenerator>();

//Declaration des différents niveaux de sécurité à mettre en place dans le controller grâce à l'attribut [Authorize("nom_de_la_police")]
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AdminPolicy", option => option.RequireRole("Admin"));
    o.AddPolicy("ModoPolict", option => option.RequireRole("Admin", "Modo"));
    o.AddPolicy("UserPolicy", option => option.RequireAuthenticatedUser());
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
}
app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//        name: "default",
//        pattern: "{controller-Home}/{action=Index}/Iid?}"
//    );
app.MapControllers();

app.Run();






