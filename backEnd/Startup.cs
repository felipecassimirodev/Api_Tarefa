using APITarefas.Data.Configurations;
using APITarefas.Data.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace APITarefas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration  { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreAPI.Mongo", Version = "v1" });
            });

            services.AddEndpointsApiExplorer();

            //Dependency Injection MongoDB
            services.Configure<DataBaseConfig>(Configuration.GetSection(nameof(DataBaseConfig)));
            services.AddSingleton<IDataBaseConfig>(sp => sp.GetRequiredService<IOptions<DataBaseConfig>>().Value);

            services.AddSingleton<ITarefasRepository, TarefasRepository>();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
            }));


        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");



            app.UseAuthorization();

            app.MapControllers();

        }


    }
}
