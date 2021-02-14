using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CourseForCreationDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }
    }
}
