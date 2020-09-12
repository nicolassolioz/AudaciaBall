using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudaciaBallAPI.Models
{
    public class GameStats
    {
        public int idPlayer { get; set; }
        public string playerName { get; set; }
        public int gamesPlayed { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public int gf { get; set; }
        public int ga { get; set; }
    }
}