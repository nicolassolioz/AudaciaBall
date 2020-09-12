//created by Nicolas Solioz
//last modified 2020-09-12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudaciaBallAPI.Models
{
    public class GamePlayer
    {
        public int idGame { get; set; }
        public int scoreBlue { get; set; }
        public int scoreRed { get; set; }
        public int fk_idPlayerBlue { get; set; }
        public string namePlayerBlue { get; set; }
        public int fk_idPlayerRed { get; set; }
        public string namePlayerRed { get; set; }
        public DateTime gameDate { get; set; }
    }
}