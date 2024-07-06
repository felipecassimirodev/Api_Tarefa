using APITarefas.Data.Configurations;
using APITarefas.Data.Repositories;
using APITarefas.Data.Service;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APITarefas.Data;
using APITarefas.Data.Interfaces;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cassimiro APi", Version = "v1" });
            });

            services.AddEndpointsApiExplorer();

            //Dependency Injection MongoDB
            services.Configure<DataBaseConfig>(Configuration.GetSection(nameof(DataBaseConfig)));
            services.AddSingleton<IDataBaseConfig>(sp => sp.GetRequiredService<IOptions<DataBaseConfig>>().Value);

            services.AddSingleton<IAgenda, AgendaRepository>();
            services.AddSingleton<IVendas, VendasRepository>();
            services.AddSingleton<ITarefasRepository, TarefasRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<ITramiteRepository, TramiteRepository>();
            services.AddSingleton<ChamadosService>();
            
            //AddScoped ou AddTransient

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200", "http://172.17.0.2:4200");
                //Adicionar ip interno da máquina
                //origem de onde sera acessada 
            }));

            services.AddDbContext<APITarefasContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("APITarefasContext")));

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarefas V1"));
            }

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

        }


    }
}
