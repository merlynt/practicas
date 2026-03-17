using System.ComponentModel.DataAnnotations;

namespace Practica_1.Models
{
    public class SpecialtyModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<StaffModel> StaffMembers { get; set; }
    }
}
