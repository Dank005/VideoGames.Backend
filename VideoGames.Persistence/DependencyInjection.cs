using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGames.Application.Interfaces;
using VideoGames.Persistence;

namespace Notes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<VideoGamesDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IVideoGamesDbContext>(provider => provider.GetService<VideoGamesDbContext>());

            return services;
        }
    }
}
