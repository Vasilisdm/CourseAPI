using System;
namespace API.Models
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string MainCategory { get; set; }
    }
}
