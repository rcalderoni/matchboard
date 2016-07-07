using MatchBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatchBoard.Services
{
    public interface IGameService
    {
        List<Match> GetAllMatches();
        Match GetMatch(int gameId);
        Match CreateMatch(string homePlayerName, string awayPlayerName);
        void SubmitMatch(Match match);
        Player GetPlayer(string playerName);
        List<Player> GetPlayers();
        Player CreatePlayer(Player player);

    }
    public class GameMatchService : IGameService
    {

        public GameMatchService()
        {
            Matches = new List<Match>();
            Players = new List<Player>();
        }

        private List<Player> Players { get; set; }
        private List<Match> Matches { get; set; }

        public List<Match> GetAllMatches()
        {
            return Matches.ToList();
        }

        public Match GetMatch(int gameId)
        {
            return Matches.FirstOrDefault() ?? new Match();
        }

        public void SubmitMatch(Match match)
        {
            Matches.Add(match);
        }

        public Match CreateMatch(string homePlayerName, string awayPlayerName)
        {
            var match = new Match();

            var homePlayer = Players.First(p => p.Name == homePlayerName);
            var awayPlayer = Players.First(p => p.Name == awayPlayerName);

            if (homePlayer == null || awayPlayer == null)
            {
                throw new Exception("Player not found!");
            }

            match.Home = new Team
            {
                Player = homePlayer,
                Score = 0
            };

            match.Away = new Team
            {
                Player = awayPlayer,
                Score = 0
            };

            Matches.Add(match);

            return match;
        }

        public Player GetPlayer(string playerName)
        {
            var player = Players.FirstOrDefault(p => p.Name == playerName);

            if(player == null)
            {
                player = new Player(playerName);
                Players.Add(player);
            }

            return player;
        }

        public Player GetPlayer(Guid uuid)
        {
            var player = Players.FirstOrDefault(p => p.UUId == uuid);

            return player;
        }

        public List<Player> GetPlayers()
        {
            return Players.ToList();
        }

        public Player CreatePlayer(Player player)
        {
            Players.Add(player);

            return player;
        }
    }
}