using MatchBoard.Models;
using MatchBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MatchBoard.Controllers
{
    public class MatchController : ApiController
    {
        private GameMatchService GameService { get; set; }

        public MatchController()
        {
            GameService = HttpContext.Current.Application["GameService"] as GameMatchService;
        }

        [HttpGet]
        [Route("games/all")]
        public List<Match> GetMatches()
        {
            return GameService.GetAllMatches();
        }

        [HttpGet]
        [Route("players/all")]
        public List<Player> GetPlayers()
        {
            return GameService.GetPlayers();
        }

        [HttpGet]
        [Route("games/new/{p1}/vs/{p2}")]
        public Match GetNewMatch(string p1, string p2)
        {
            return GameService.CreateMatch(p1, p2);
        }

        [HttpGet]
        [Route("players/wins/{w}/wins/{l}")]
        public Match UpdateRecord(int w, int l)
        {
            return GameService.CreateMatch(w.ToString(), l.ToString());
        }

        [HttpPost]
        [Route("games/submit")]
        public void PostMatch([FromBody]Match match)
        {
            GameService.SubmitMatch(match);
        }

        [HttpPost]
        [Route("players/new")]
        public Player PostPlayer(string name)
        {
            var player = new Player(name);

            return GameService.CreatePlayer(player);
        }

        [HttpGet]
        [Route("player/{name}")]
        public Player GetPlayer(string name)
        {
            return GameService.GetPlayer(name);
        }

        [HttpGet]
        [Route("player/id/{uuid}")]
        public Player GetPlayerById(Guid uuid)
        {
            return GameService.GetPlayer(uuid);
        }

        [HttpGet]
        [Route("players/new")]
        public Player GetNewPlayer(string playerName)
        {
            var player = new Player();

            return player;
        }

        [HttpPost]
        [Route("players/new")]
        public Player PostPlayer([FromBody] Player player)
        {
            return GameService.CreatePlayer(player);
        }
    }
}
