using System.ComponentModel.DataAnnotations;

namespace P19_Web_Dynamic_08_PublishingHouse.ViewModels
{
    public class AuthorRowViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public int BookCount { get; set; }
    }
}