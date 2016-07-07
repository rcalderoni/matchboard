using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatchBoard.Models
{
    public class Team
    {
        public Player Player { get; set; }
        public int Score { get; set; }
    }
}