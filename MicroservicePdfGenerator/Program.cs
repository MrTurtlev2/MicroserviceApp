
using MicroservicePdfGenerator.Data;
using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace MicroservicePdfGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 80);
                options.ListenAnyIP(5001);
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.WithOrigins("http://localhost:8080")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            builder.Services.AddControllers();
            builder.Services.AddHttpClient();
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddHealthChecks();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();


            app.UseHttpsRedirection();


            app.UseCors("AllowLocalhost");


            app.UseAuthorization();
            app.MapControllers();


            //app.MapHealthChecks("/health");

            app.Run();
        }
    }
}
// curl -X GET http://microservicerestapi/api/trainers/1/pupils
