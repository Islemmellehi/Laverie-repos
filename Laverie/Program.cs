using Microsoft.EntityFrameworkCore;

using Laverie.Infrastructure.Data;
using Laverie.Infrastructure.DAO.Connexion;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Laverie.Infrastructure.DAOImp;

namespace Laverie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var postgresConnectionString = builder.Configuration.GetConnectionString("PostgresConnection");

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(postgresConnectionString));  

            builder.Services.AddScoped<ConnexionPostgres>(provider => new ConnexionPostgres(postgresConnectionString));

            builder.Services.AddScoped<IDAOProprietaire, DAOImpProprietaire>();
            builder.Services.AddScoped<IDAOLaverie, DAOImpLaverie>();
            builder.Services.AddScoped<IDAOMachine, DAOImpMachine>();
            builder.Services.AddScoped<IDAOCycle, DAOImpCycle>();
            builder.Services.AddScoped<IDAOSerialize, DAOImpSerialize>();



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication3 API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
    
}

