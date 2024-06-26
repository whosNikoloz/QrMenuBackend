using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Data;
using QrMenuBackend.Profiles;
using QrMenuBackend.Repositories;
using QrMenuBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductGroupService, ProductGroupService>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IOptionsValueRepository, OptionsValueRepository>();
builder.Services.AddScoped<IOptionValueService, OptionValueService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
