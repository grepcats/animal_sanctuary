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

    }
}
