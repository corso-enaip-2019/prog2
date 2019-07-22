using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_08_PublishingHouse.ViewModels
{
    public class BookRowViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> AuthorsList { get; set; }
    }
}