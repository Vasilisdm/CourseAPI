﻿using System;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

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
            var authors = _courseLibraryRepository.GetAuthors();
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
