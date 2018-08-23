using BlizzPetApp.Models;
using BlizzPetApp.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlizzPetApp.Repositories
{
    public class PetRepository
    {
        private const string _BASEURL = "https://us.api.battle.net/wow/pet/?locale=en_US&apikey=crrwjd3h9hrmr6je6gpjdzfvft276krr";
        private RootPet _rootPet;

        public async Task<List<Pet>> GetAllPets(string family)
        {
            BaseRepository br = new BaseRepository();
            if (_rootPet == null)
                _rootPet = await br.GetAsync<RootPet>(_BASEURL);
            List<Pet> lstPetAll = _rootPet.pets as List<Pet>;
            List<Pet> lstPetFilter = new List<Pet>();
            foreach (Pet pet in lstPetAll)
            {
                if (pet.family == family) lstPetFilter.Add(pet);
            }
            return lstPetFilter;
        }





    }
}
