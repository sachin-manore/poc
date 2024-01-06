using Libraries.Common.Event.Helper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ServiceName.Api.Web.App_Start;
using ServiceName.Data.Entity;
using Swashbuckle.AspNetCore.SwaggerGen.ConventionalRouting;


var builder = WebApplication.CreateBuilder(args);


// entity registration
builder.Services.AddDbContext<Poc_Entities>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("poc_entities")));
builder.Services.AddScoped<Poc_Entities>();


builder.Services.AddMassTransit(config =>
{
    MessageBrokerSettings.settings = builder.Configuration.GetSection("EventBus");
    config.UsingRabbitMq((context, cfg) =>
    {
        //cfg.Host(MessageBrokerSettings.RabbitMQConnectionString);
        cfg.ConfigureEndpoints(context);

    });
});

// Adds cross-origin resource sharing services to the specified <see cref="IServiceCollection" />.
builder.Services.AddCors(options =>
{
    string corsOrigin = "PocCorsPolicy";
    options.AddPolicy(name: corsOrigin,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                      });
});

//Register DI 
builder.RegisterDI();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenWithConventionalRoutes(options =>
{
    options.IgnoreTemplateFunc = (template) => template.StartsWith("api/");
    options.SkipDefaults = true;
});
var app = builder.Build();
app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();

    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.UseEndpoints(endpoints =>
{
    ApiRoutes.MapControllerRoutes(endpoints);

});


app.Run();
