using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalSanctuary.Models
{
    [Table("Vets")]
    public class Vet
    {
        [Key]
        public int VetId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        public Vet() { }

        public Vet(string name, string speciality)
        {
            Name = name;
            Specialty = speciality;
        }

        public override bool Equals(object otherVet)
        {
            if (!(otherVet is Vet))
            {
                return false;
            }
            else
            {
                Vet newVet = (Vet)otherVet;
                return this.VetId.Equals(newVet.VetId);
            }
        }

        public override int GetHashCode()
        {
            return this.VetId.GetHashCode();
        }
    }
}
