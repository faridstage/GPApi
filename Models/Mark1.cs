using System.ComponentModel.DataAnnotations;

namespace GP_Project.Models
{
    public class Mark1
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


    }
}
