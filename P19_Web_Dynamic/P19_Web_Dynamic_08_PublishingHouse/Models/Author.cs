using System.Collections.Generic;

namespace P19_Web_Dynamic_08_PublishingHouse
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
