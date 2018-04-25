using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSanctuary.Models.Repositories
{
    public interface IVetRepository
    {
        IQueryable<Vet> Vets { get; }
        Vet Save(Vet vet);
        Vet Edit(Vet vet);
        void Remove(Vet vet);
    }
}
