using System.ComponentModel.DataAnnotations;

namespace GP_Project.Dtos
{
    public class CreateMarkDto
    {
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
