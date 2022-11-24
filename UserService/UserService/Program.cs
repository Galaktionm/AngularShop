using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserService;
using UserService.Controllers;
using UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(options =>options.JsonSerializerOptions.Converters.Add(new UserSerializer()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(
    options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
 .AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<MessagingService>();
builder.Services.AddScoped<WishListUpdateController>();



builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RequireExpirationTime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtParameters:Issuer"],
        ValidAudience = builder.Configuration["JwtParameters:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
        GetBytes(builder.Configuration["JwtParameters:SecurityKey"]))
        //The same constructor we used to generate credentials
        //when creating the JWT
    };
});

builder.Services.AddSignalR();

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AngularCORS",
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
});
*/

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext=scope.ServiceProvider.GetService<DatabaseContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

    User user = new User("", ""); //Username and Email ommited

    var userManager=scope.ServiceProvider.GetService<UserManager<User>>();


    var result=await userManager.CreateAsync(user, "password");

    if (result.Succeeded)
    {
        var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
        var role = await roleManager.CreateAsync(new IdentityRole("User"));
        var addRole = await userManager.AddToRoleAsync(user, "User");
    }

    var messaging=scope.ServiceProvider.GetService<MessagingService>();

    messaging.receiveMessage();

    dbContext.SaveChanges();


}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x=>x.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader());

app.MapControllers();

app.MapHub<WishListHub>("/api/WishListHub");

app.Run();
