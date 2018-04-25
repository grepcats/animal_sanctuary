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
    }
}
