using BooksAPI.Data;
using BooksAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EmployeeDB"));
            builder.Services.AddScoped<IEmployeeRepository, EmployeeService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", b =>
                {
                    // Be Careful in adding URLS here, adding extra slash at the end will throw an error
                    b
                    //.AllowAnyOrigin()
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Management Services V1.0");
                    s.RoutePrefix = string.Empty;
                });
            }
            app.UseCors("MyCors");  

            app.MapControllers();

            app.MapGet("/books", () =>
            {
                return Results.Redirect("/api/books");
            });

            app.Run();
        }
    }
}
