namespace StandardAddress.API
{
    public class Program
    {
        readonly static string CORSOpenPolicy = "OpenCORSPolicy";

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
                options.AddPolicy(
                    name: CORSOpenPolicy,
                    builder => {
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
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

            app.UseHttpsRedirection();
            app.UseCors(CORSOpenPolicy);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}