using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatchBoard.Models
{
    public class Match
    {
        public Team Home { get; set; }
        public Team Away { get; set; }
    }
}