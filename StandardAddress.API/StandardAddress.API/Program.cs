using Microsoft.Extensions.DependencyInjection;

namespace StandardAddress.API
{
    public class Program
    {
        //readonly static string CORSOpenPolicy = "OpenCORSPolicy";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.Configure<DadataAuth>(builder.Configuration.GetSection(typeof(DadataAuth).Name));
            builder.Services.AddSingleton<DadataService>();
            builder.Services.AddHttpClient();
            builder.Services.AddAutoMapper(typeof(AddressProfile));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAccessControlAllowOriginAlways();
            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

    public static class AccessControlAllowOriginAlwaysExtensions
    {
        public static IApplicationBuilder UseAccessControlAllowOriginAlways(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessControlAllowOriginAlways>();
        }
    }

    public class AccessControlAllowOriginAlways
    {
        private readonly RequestDelegate _next;
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        public AccessControlAllowOriginAlways(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                if (!context.Response.Headers.ContainsKey(AccessControlAllowOrigin))
                {
                    context.Response.Headers.Add(AccessControlAllowOrigin, "http://localhost:4200");
                }
                return Task.CompletedTask;
            });
            return _next(context);
        }
    }
}