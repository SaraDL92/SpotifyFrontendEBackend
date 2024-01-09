using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SpotiAPI.Data;
using SpotiAPI.Repo;
using SpotiAPI.Service;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .WithOrigins("http://localhost:3001")
                        .WithHeaders("Access-Control-Allow-Origin") // Aggiungi questa linea
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpotiAPI", Version = "v1" });
            });
            services.AddScoped<IGenericRepository<Radio>,GenericRepository<Radio>>();
            services.AddScoped<IGenericRepository<Song>, GenericRepository<Song>>();
            services.AddScoped<IGenericRepository<Album>, GenericRepository<Album>>();
            services.AddScoped<IGenericRepository<Artist>, GenericRepository<Artist>>();
            services.AddScoped<IGenericRepository<Director>, GenericRepository<Director>>();
            services.AddScoped<IGenericRepository<Movie>, GenericRepository<Movie>>();
            services.AddScoped<IGenericRepository<Setting>, GenericRepository<Setting>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<ISongService,SongService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IDirectorService,DirectorService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRadioService, RadioService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IUserService, UserService>();

            var connectionString = Configuration.GetConnectionString("RealStateConnectionString");
            services.AddDbContext<SpotifyDBContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpotiAPI v1"));
            }
            app.UseMiddleware<DisableCorsMiddleware>();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
