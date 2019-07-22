using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_08_PublishingHouse.ViewModels
{
    public class AuthorAddViewModel
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }

        public AuthorAddViewModel()
        {
            Name = "";
        }

        public AuthorAddViewModel(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Nome non valido!" : name.ToString();
        }
    }
}