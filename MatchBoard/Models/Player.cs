using System;


namespace MatchBoard.Models
{
    public class Player
    {
        public Player() {
            UUId = Guid.NewGuid();
        }
        public Player(string name) : this()
        {
            Name = name;
            Wins = name.Length;
            Losses = 0;

        }

        public Guid UUId { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GamesPlayed { get { return Wins + Losses; } }
    }
}