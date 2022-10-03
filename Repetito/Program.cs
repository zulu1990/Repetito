using Repetito.Application;
using Repetito.Common;
using Repetito.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

}



var app = builder.Build();
{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
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

}

