using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using webapi.Data;
using webapi.Data.Configurations;
using webapi.Interfaces;
using webapi.Services;
using webapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Swashbuckle.AspNetCore.Filters;
using webapi.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericServices<>));
builder.Services.AddScoped<IRestaurantService, RestaurantServices>();
builder.Services.AddScoped<IAuthService, AuthServices>();
builder.Services.AddScoped<IMealRequestService, MealRequestServices>();
builder.Services.AddScoped<IUserService, UsersServices>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        //Scheme = JwtBearerDefaults.AuthenticationScheme,
        Scheme = "Bearer"
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure JWT authentication if needed
// Add Authentication and JwtBearer middleware to add to Header
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = false;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            //ValidateIssuerSigningKey=true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),

        };
        options.SecurityTokenValidators.Clear();
        // Makes my custom claim "email" discoverable by protected routes, which is not the case without. It maps the ClaimTypes.Email to "email" key.
        options.SecurityTokenValidators.Add(new JwtSecurityTokenHandler
        {
            InboundClaimTypeMap = new Dictionary<string, string>
            {
                { "email", ClaimTypes.Email }
                // Add more mappings as needed
            }
        });
    });

var supabaseUrl = builder.Configuration["Supabase:URL"];

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireClaim("sub", Admin.AdminUserId);
    });
});


//JSON Serializer
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
    .AddJsonOptions(options =>
         {
             options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
             options.JsonSerializerOptions.PropertyNamingPolicy = null;
         });


var app = builder.Build();

//Enable CORS
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
