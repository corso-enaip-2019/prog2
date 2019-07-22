using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_08_PublishingHouse.ViewModels
{
    public class AuthorAddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AuthorAddViewModel()
        {
            Id = 0;
            Name = "Nome non immesso!";
        }

        public AuthorAddViewModel(string name)
        {
            Id = 0;
            Name = string.IsNullOrWhiteSpace(name) ? "Nome non valido!" : name.ToString();
        }
    }
}