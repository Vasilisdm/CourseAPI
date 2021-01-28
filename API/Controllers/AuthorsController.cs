using System;
using System.Collections.Generic;
using API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
using AutoMapper;
using API.ResourceParameters;

namespace API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(CourseLibraryRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors(
            [FromQuery] AuthorResourceParameters authorResourceParameters)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorResourceParameters);

            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(authorsFromRepo));
        }

        [HttpGet("{authorID:guid}")]
        public IActionResult GetAuthor(Guid authorID)
        {
            var author = _courseLibraryRepository.GetAuthor(authorID);
            if (author==null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDTO>(author));
        }
    }
}
