using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternWithUnitOfWork.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(300)]
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
