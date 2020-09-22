using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Troganbets.Models;

namespace Troganbets.Controllers
{
    public class GamesController : Controller
    {
        private readonly MyDatabaseContext db = new MyDatabaseContext();

        // GET: Games/Index
        public ActionResult Index(int? week, bool? hideBoring)
        {
            Trace.WriteLine("GET /Games/Index");
            ViewBag.SeasonStart = new DateTime(2020, 9, 8, 16, 0, 0, DateTimeKind.Utc);
            int realTimeWeekNumber = (week ?? (int)((DateTime.UtcNow - ViewBag.SeasonStart).TotalDays / 7) + 1);
            DateTime earliestWeekDateTime = ViewBag.SeasonStart.AddDays(7 * (realTimeWeekNumber - 1));
            DateTime latestWeekDateTime = earliestWeekDateTime.AddDays(7);

            var gamesWithBets = db.Games
                .Where(game =>
                    game.UtcDateTime > earliestWeekDateTime &&
                    game.UtcDateTime < latestWeekDateTime)
                .Include(game => game.Bets)
                .OrderBy(game => game.UtcDateTime);

            if (hideBoring ?? false)
            {
                return View(gamesWithBets.Where(game => game.Bets.Any()));
            }

            return View(gamesWithBets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
