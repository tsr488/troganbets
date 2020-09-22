using System.Data.Entity;

namespace Troganbets.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext() : base("name=defaultConnection")
        {}

        public System.Data.Entity.DbSet<Troganbets.Models.Bet> Bets { get; set; }
        public System.Data.Entity.DbSet<Troganbets.Models.Game> Games { get; set; }
    }
}
