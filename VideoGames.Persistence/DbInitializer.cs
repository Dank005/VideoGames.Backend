using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
