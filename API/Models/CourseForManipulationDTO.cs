using System;
using System.ComponentModel.DataAnnotations;
using API.ValidationAttributes;

namespace API.Models
{
    [CourseTitleMustBeDifferentFromDescription(ErrorMessage = "Title must be different from Description")]
    public abstract class CourseForManipulationDTO
    {
        [Required(ErrorMessage = "You should fill out a title")]
        [MaxLength(100, ErrorMessage = "The Title shouldn't have more than 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "The Description shouldn't have more than 1500 characters.")]
        public virtual string Description { get; set; }
    }
}
