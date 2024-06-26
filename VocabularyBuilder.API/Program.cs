
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.App.Mappings;
using VocabularyBuilder.Domain.Interface;
using VocabularyBuilder.Domain.Interface.Services;
using VocabularyBuilder.Infra.Context;
using VocabularyBuilder.Infra.Repositories;
using VocabularyBuilder.Infra.Service;
using VocabularyBuilder.Infra.UnitOfWork;

namespace VocabularyBuilder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PostgreeSQL>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("defaultconnection")));
            builder.Services.AddScoped<IVocabularyRepository, VocabularyRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IVocabularyAPIService, VocabularyAPIService>();
            builder.Services.AddScoped<IMeaningAPIService,MeaningAPIService>();
            builder.Services.AddAutoMapper(typeof(MappingDTOs));
            builder.Services.AddHttpClient("dictionaryapi", HttpClient =>
            {
                HttpClient.BaseAddress = new Uri(builder.Configuration["ServiceUri:FreeDictionaryAPI"]);
            }); //Service para consumo de api externa chamado Cliente nomeado

            var app = builder.Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
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
