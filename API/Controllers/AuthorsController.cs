using System;
using System.Collections.Generic;
using API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
using AutoMapper;
using API.ResourceParameters;
using CourseLibrary.API.Entities;

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

        [HttpGet("{authorID:guid}", Name = "GetAuthor")]
        public ActionResult GetAuthor(Guid authorID)
        {
            var author = _courseLibraryRepository.GetAuthor(authorID);
            if (author==null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDTO>(author));
        }

        [HttpPost]
        public ActionResult<AuthorDTO> CreateAuthor(AuthorForCreationDTO author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _courseLibraryRepository.AddAuthor(authorEntity);
            _courseLibraryRepository.Save();

            var authorToReturn = _mapper.Map<AuthorDTO>(authorEntity);
            return CreatedAtRoute("GetAuthor", new { authorID = authorToReturn.Id }, authorToReturn);
        }

        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
