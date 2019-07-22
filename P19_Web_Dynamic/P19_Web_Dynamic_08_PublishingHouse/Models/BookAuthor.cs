using System.ComponentModel.DataAnnotations.Schema;

namespace P19_Web_Dynamic_08_PublishingHouse
{
    [Table("BooksAuthors")]
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
