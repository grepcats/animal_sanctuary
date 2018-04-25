using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalSanctuary.Models
{
    [Table("Animals")]
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
        public string HabitatType { get; set; }
        public bool MedicalEmergency { get; set; }
        public int VetId { get; set; }
        public virtual Vet Vet { get; set; }

        public Animal() { }

        public Animal(string species, string sex, string habitat, bool medical)
        {
            Species = species;
            Sex = sex;
            HabitatType = habitat;
            MedicalEmergency = medical;
        }

        public override bool Equals(object otherAnimal)
        {
            if (!(otherAnimal is Animal))
            {
                return false;
            }
            else
            {
                Animal newAnimal = (Animal)otherAnimal;
                return this.AnimalId.Equals(newAnimal.AnimalId);
            }
        }

        public override int GetHashCode()
        {
            return this.AnimalId.GetHashCode();
        }
    }
}
