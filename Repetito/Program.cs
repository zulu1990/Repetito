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
        app.UseStaticFiles();
        app.UseSwagger();
        app.UseSwaggerUI(x=>x.InjectStylesheet("/swagger/ui/custom.css"));
    }

    app.UseHttpsRedirection();
    
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}

