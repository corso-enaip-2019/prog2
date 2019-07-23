using System.Collections.Generic;

namespace P19_Web_Dynamic_08_PublishingHouse
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }

        public Book() { }

        public Book(int id, string title)
        {
            Id = id;
            Title = string.IsNullOrWhiteSpace(title) ? "Titolo non valido!" : title.ToString();

            BookAuthors = new List<BookAuthor>();
        }
    }
}