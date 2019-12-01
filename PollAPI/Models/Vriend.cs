using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class Vriend
    {
        public int VriendID { get; set; }
        public int VerzenderID { get; set; }
        public int OntvangerID { get; set; }
        public bool Geaccepteerd { get; set; }
        public Gebruiker Verzender { get; set; }
        public Gebruiker Ontvanger { get; set; }

    }
}
