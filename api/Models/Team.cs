//created by Nicolas Solioz
//last modified 2020-09-12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudaciaBallAPI.Models
{
    public class Team
    {
        public int idTeam { get; set; }
        public string name { get; set; }
        public int idPlayer1 { get; set; }
        public int idPlayer2 { get; set; }
    }
}