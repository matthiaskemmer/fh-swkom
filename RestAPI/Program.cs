
namespace dms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // CORS konfigurieren, um Anfragen von localhost:80 (WebUI) zuzulassen
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowWebUI",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost") // Die URL deiner Web-UI
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyMethod();
                    });
            });

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

            //app.UseHttpsRedirection();

            // Explicitly listen to HTTP only
            app.Urls.Add("http://*:8080"); // Stelle sicher, dass die App nur HTTP verwendet

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
