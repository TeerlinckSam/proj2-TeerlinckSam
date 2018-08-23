using System;
using System.Collections.Generic;
using System.Text;

namespace BlizzPetApp.Models
{
    public class Pet
    {
        public bool canBattle { get; set; }

        public int creatureId { get; set; }
    
        public string name { get; set; }

        public string family { get; set; }

        public string icon { get; set; }

        public int qualityId { get; set; }

        public PetStat stats { get; set; }

        public string[] strongAgainst { get; set; }

        public int typeId { get; set; }

        public string[] weakAgainst { get; set; }


    }
}
