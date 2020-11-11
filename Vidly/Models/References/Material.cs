using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models.References
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<Phone> Phones { get; set; }
    }
}