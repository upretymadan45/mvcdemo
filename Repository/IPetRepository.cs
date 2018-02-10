using System.Collections.Generic;
using mvcdemo.Models;

namespace mvcdemo.Repository{
    public interface IPetRepository
    {
        void Create(Pet pet);
        void Edit(Pet pet);
        Pet GetSinglePet(int id);
        void Delete(Pet pet);
        List<Pet> GetAllPets();
        bool VerifyName(string name);
        List<Pet> SearchPets(string search);
    }
}