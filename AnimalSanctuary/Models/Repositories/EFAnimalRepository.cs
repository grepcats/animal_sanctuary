using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSanctuary.Models.Repositories
{
    public class EFAnimalRepository : IAnimalRepository
    {
        SanctuaryContext db = new SantuaryContext();
    }
}
