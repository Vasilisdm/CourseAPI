using System;
using System.Collections.Generic;
using API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(CourseLibraryRepository));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            var authors = new List<AuthorDTO>();

            foreach (var author in authorsFromRepo)
            {
                authors.Add(new AuthorDTO
                {
                    Id = author.Id,
                    FullName = $"{author.FirstName} {author.LastName}",
                    Age = author.DateOfBirth.GetCurrentAge(),
                    MainCategory = author.MainCategory
                });
            }

            return Ok(authors);
        }

        [HttpGet("{authorID:guid}")]
        public IActionResult GetAuthor(Guid authorID)
        {
            var author = _courseLibraryRepository.GetAuthor(authorID);
            if (author==null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
