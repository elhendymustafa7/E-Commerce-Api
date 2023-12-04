global using Microsoft.AspNetCore.Identity;
global using E_Commerce_Api.Model;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using E_Commerce_Api.Repository;
global using E_Commerce_Api.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using E_Commerce_Api.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add security definition and requirement
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(options =>{
                                                                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                                                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                                               })
                .AddJwtBearer(o =>{
                                                    o.RequireHttpsMetadata = false;
                                                    o.SaveToken = false;
                                                    o.TokenValidationParameters = new TokenValidationParameters
                                                    {
                                                        ValidateIssuerSigningKey = true,
                                                        ValidateIssuer = true,
                                                        ValidateAudience = true,
                                                        ValidateLifetime = true,
                                                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                                                        ValidAudience = builder.Configuration["JWT:Audience"],
                                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                                                    };
                                                });

builder.Services.AddAuthentication().AddFacebook(options =>
    {
        options.AppId = "345848101341813";
        options.AppSecret = "2dbe7293145d47f9118c55a2fbdd4751";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        // ... other Swagger UI configuration options
    }); 
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
