using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class Antwoord
    {
        public int AntwoordID { get; set; }
        public string Respons { get; set; }
        public int PollID { get; set; }
        public Poll Poll { get; set; }
        public List<Stem> Stemmen { get; set; }
    }
}
