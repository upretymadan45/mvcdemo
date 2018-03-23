using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvcdemo.Data;
using mvcdemo.Models;

namespace mvcdemo.Repository
{
    public class PetRepository : IPetRepository
    {
        private ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void Delete(Pet pet)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }

        public void Edit(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public List<Pet> GetPetByUserId(string userId)
        {
            return _context.Pets.Where(p=>p.UserId.Equals(userId)).ToList();
        }

        public Pet GetSinglePet(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
            return pet;
        }
        public List<Pet> SearchPets(string search)
        {
            int age;
            bool success = Int32.TryParse(search, out age);
            if (!success)
                age = 0;

            return _context.Pets
                            .Where(p => p.Name.Contains(search) || p.Color.Contains(search) || p.Age == age)
                            .ToList();
        }

        public bool VerifyName(string name)
        {
            return _context.Pets.Any(p => p.Name.Equals(name));
        }
    }
}