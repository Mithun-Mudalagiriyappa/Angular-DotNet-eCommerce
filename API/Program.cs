using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

var app = builder.Build();

//Apply migrations and create the database at startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var dbContext = services.GetRequiredService<StoreContext>();
        await dbContext.Database.MigrateAsync();

        //await StoreContextSeed.SeedAsync(dbContext, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migration written in Program.cs");
    }
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseSwaggerDocumentation();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();