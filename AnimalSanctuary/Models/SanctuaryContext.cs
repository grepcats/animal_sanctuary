using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models
{
    public class SanctuaryContext : DbContext
    {
        public SanctuaryContext()
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Vet> Vets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=Sanctuary;uid=root;pwd=root;");
        }

        public SanctuaryContext(DbContextOptions<SanctuaryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}