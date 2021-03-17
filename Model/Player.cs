using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIModel.Model
{
    public class Player
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public DateTime PDOB { get; set; }
        public string PTeam { get; set; }

        public static implicit operator Player(string v)
        {
            throw new NotImplementedException();
        }
    }
}
