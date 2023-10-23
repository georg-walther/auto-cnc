var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IWorkpieceService, WorkpieceService>();
}
var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // if exception is thrown, return error page
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}