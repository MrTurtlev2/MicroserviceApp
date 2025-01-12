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
                    policy.WithOrigins("http://localhost:8080") 
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
                });
            });

 
            builder.Services.AddControllers();
            builder.Services.AddHttpClient();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

          
            builder.Services.AddHealthChecks();

            var app = builder.Build();

 
            app.UseSwagger();
            app.UseSwaggerUI();

          
            app.UseHttpsRedirection();

          
            app.UseCors("AllowLocalhost");

           
            app.UseAuthorization();
            app.MapControllers();

          
            app.MapHealthChecks("/health");

            app.Run();
        }
    }
}
