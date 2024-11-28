using Azure.Identity;
using LoggingProvider.Contexts;
using LoggingProvider.Services;
using Microsoft.EntityFrameworkCore;

namespace LoggingProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMemoryCache();

            //var vaultUri = new Uri($"{builder.Configuration["KeyVault"]!}");

            //if (builder.Environment.IsDevelopment())
            //{
            //    builder.Configuration.AddAzureKeyVault(vaultUri, new VisualStudioCredential());
            //}
            //else if (builder.Environment.IsProduction())
            //{
            //    builder.Configuration.AddAzureKeyVault(vaultUri, new DefaultAzureCredential());
            //}
            //builder.Services.AddDbContext<LoggingContext>(options => options.UseSqlServer(builder.Configuration["LoggingDbSecret"]));
            builder.Services.AddDbContext<LoggingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestingConnection")));
            builder.Services.AddScoped<LoggingService>();
            builder.Services.AddScoped<ReportingService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}