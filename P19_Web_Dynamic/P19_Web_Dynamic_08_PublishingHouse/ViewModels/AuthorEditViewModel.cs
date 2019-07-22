using System.Collections.Generic;

namespace P19_Web_Dynamic_08_PublishingHouse.ViewModels
{
    public class AuthorEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> BooksIds { get; set; }
    }
}
