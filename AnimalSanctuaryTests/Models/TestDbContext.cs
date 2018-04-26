using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Models
{
    public class TestDbContext : SanctuaryContext
    {
        public override DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=sanctuary_test;uid=root;pwd=root;");
        }
    }
}
