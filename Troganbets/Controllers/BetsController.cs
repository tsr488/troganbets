using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using Troganbets.Models;

namespace Troganbets.Controllers
{
    public class BetsController : Controller
    {
        private readonly MyDatabaseContext db = new MyDatabaseContext();
        private string ScottPassword => ConfigurationManager.AppSettings["ScottPassword"];

        // GET: Bets/Create/7d30c2c5-42fd-ab7a-c1bc-1196a93d2e53
        [HttpGet]
        public ActionResult Create(Guid? gameId)
        {
            Trace.WriteLine("GET /Bets/Create");
            Game game = db.Games.Find(gameId);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(new Bet { GameId = gameId.Value, Game = game });
        }

        // POST: Bets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,OnHomeTeam,Odds,Points,Entry")] Bet bet)
        {
            Trace.WriteLine("POST /Bets/Create");
            if (bet.Odds.ToString() != ScottPassword)
            {
                return new HttpUnauthorizedResult("You're not Scott");
            }
            else if (!ModelState.IsValid)
            {
                bet.Game = db.Games.Find(bet.GameId);
                if (bet.Game == null)
                {
                    return HttpNotFound();
                }
                return View(bet);
            }

            db.Bets.Add(bet);
            db.SaveChanges();
            return RedirectToAction("Index", "Games");
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
