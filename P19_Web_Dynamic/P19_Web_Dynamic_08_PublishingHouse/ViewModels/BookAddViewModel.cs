using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_08_PublishingHouse.ViewModels
{
    public class BookAddViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public BookAddViewModel()
        {
            Title = "";
        }

        public BookAddViewModel(string title)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "" : title.ToString();
        }
    }
}