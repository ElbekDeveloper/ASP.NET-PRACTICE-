using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        [Key]
        [Display(Name = "Genre Id")]
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}