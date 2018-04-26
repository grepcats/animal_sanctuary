using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSanctuary.Models.Repositories
{
    public class EFAnimalRepository : IAnimalRepository
    {
        SanctuaryContext db;
        public EFAnimalRepository()
        {
            db = new SanctuaryContext();
        }

        public EFAnimalRepository(SanctuaryContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Animal> Animals
        { get { return db.Animals; } }

        public Animal Save(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return animal;
        }

        public Animal Edit(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return animal;
        }

        public void Remove(Animal animal)
        {
            db.Animals.Remove(animal);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Animals;");
        }
    }
}
