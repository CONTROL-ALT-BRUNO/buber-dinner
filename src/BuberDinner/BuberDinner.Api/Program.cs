using BuberDinner.Application;
using BuberDinner.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
}

WebApplication app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}