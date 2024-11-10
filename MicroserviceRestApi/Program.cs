
using System.Net;

namespace MicroserviceRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 80);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.WithOrigins("http://localhost:8080")  // allow for calls from this address
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddHttpClient();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
           // {
                app.UseSwagger();
                app.UseSwaggerUI();
          //  }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowLocalhost");
            app.MapControllers();

            app.Run();
        }
    }
}
