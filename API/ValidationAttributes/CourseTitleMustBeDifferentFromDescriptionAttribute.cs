using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.ValidationAttributes
{
    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = (CourseForCreationDTO)validationContext.ObjectInstance;
            if (course.Title == course.Description)
            {
                return new ValidationResult(
                    ErrorMessage,
                    new[] { "CourseForCreationDTO" });
            }

            return ValidationResult.Success;
        }
    }
}
