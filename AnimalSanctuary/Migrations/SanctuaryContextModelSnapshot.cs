using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Migrations
{
    [DbContext(typeof(SanctuaryContext))]
    partial class SanctuaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("AnimalSanctuary.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HabitatType");

                    b.Property<bool>("MedicalEmergency");

                    b.Property<string>("Sex");

                    b.Property<string>("Species");

                    b.Property<int>("VetId");

                    b.HasKey("AnimalId");

                    b.HasIndex("VetId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalSanctuary.Models.Vet", b =>
                {
                    b.Property<int>("VetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Specialty");

                    b.HasKey("VetId");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("AnimalSanctuary.Models.Animal", b =>
                {
                    b.HasOne("AnimalSanctuary.Models.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
