using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.ValidationAttributes;

namespace API.Models
{
    [CourseTitleMustBeDifferentFromDescription]
    public class CourseForCreationDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

    }
}
