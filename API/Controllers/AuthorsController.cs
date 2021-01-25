using System;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(CourseLibraryRepository));
        }

        public IActionResult GetAuthors()
        {
            var authors = _courseLibraryRepository.GetAuthors();
            return new JsonResult(authors);
        }
    }
}
