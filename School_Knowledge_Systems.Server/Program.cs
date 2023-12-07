
using Microsoft.EntityFrameworkCore;
using School_Knowledge_Systems.Server.Data;
using School_Knowledge_Systems.Server.Models.Interfaces;
using School_Knowledge_Systems.Server.Models.Services;

namespace School_Knowledge_Systems.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SKSDbContext>(options => options.UseSqlServer(connString));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ILevels, LevelsService>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
                policy.WithOrigins("https://cookie-stand-admin-8tx2rlwtg-ahmads-projects-9160d70a.vercel.app") // replace with your client's URL
                      .AllowAnyHeader()
                      .AllowAnyMethod());

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
