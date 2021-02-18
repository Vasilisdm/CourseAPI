using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CourseForUpdateDTO : CourseForManipulationDTO
    {
        [Required(ErrorMessage = "You should fill out the description.")]
        public override string Description { get => base.Description; set => base.Description = value; }
    }
}
