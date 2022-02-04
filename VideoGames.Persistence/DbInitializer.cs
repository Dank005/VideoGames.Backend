namespace VideoGames.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(VideoGamesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
