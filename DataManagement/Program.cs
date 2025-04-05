
using DataManagement.Repositories.Interface;
using DataManagement.Repositories;

namespace DataManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();  // Enables OpenAPI generation
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient<PostRepository>();
            builder.Services.AddHttpClient<UserRepository>();

            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
