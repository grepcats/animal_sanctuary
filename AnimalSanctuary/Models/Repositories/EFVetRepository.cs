using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSanctuary.Models.Repositories
{
    public class EFVetRepository : IVetRepository
    {
        SanctuaryContext db = new SanctuaryContext();

        public IQueryable<Vet> Vets
        { get { return db.Vets; } }

        public Vet Save(Vet vet)
        {
            db.Vets.Add(vet);
            db.SaveChanges();
            return vet;
        }

        public Vet Edit(Vet vet)
        {
            db.Entry(vet).State = EntityState.Modified;
            db.SaveChanges();
            return vet;
        }

        public void Remove(Vet vet)
        {
            db.Vets.Remove(vet);
            db.SaveChanges();
        }
    }
}
