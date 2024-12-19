using ApiFood.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_lamoda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �������� ������ �����������
            var connectionString = builder.Configuration["ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("ConnectionString is missing in configuration.");
            }

            // ���������� DbContext
            builder.Services.AddDbContext<LucavicFoodEatContext>(
                options => options.UseSqlServer(connectionString));

            // ��������� CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // ���������� ������������
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ��������� HTTP-���������
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // ������������� CORS
            app.UseCors("MyPolicy");

            // ����������� ������������
            app.MapControllers();

            app.Run();
        }
    }
}