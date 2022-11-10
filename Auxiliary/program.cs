using System.Text;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TODO: Alterar as configuracoes de seguranca e banco de dados no appsettings.Development.json
var connectionString = builder.Configuration.GetConnectionString("api");



    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    });

NativeInjectorBootStrapper.RegisterAppDependencies(builder.Services);
NativeInjectorBootStrapper.RegisterAppDependenciesContext(builder.Services, connectionString);

builder.Services
    .AddControllers()
    //Adiciona o conversor de Enum para string
    .AddJsonOptions(
        options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

//builder.Services.AddControllers();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
