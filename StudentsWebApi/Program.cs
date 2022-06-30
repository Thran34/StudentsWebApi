using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Students App",
        Version = "v1",
        Description = "Web app for managing students and classes",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Andrzej",
            Email = String.Empty,
            Url = new Uri("https://example.com/contact"),
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Used license",
            Url = new Uri("https://example.com/license")
        }
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "StudentsWebApi.xml");
    c.IncludeXmlComments(filePath);
}
);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentsWebApi.Infrastructure.Context.DBContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseHealthChecks("/hc");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
