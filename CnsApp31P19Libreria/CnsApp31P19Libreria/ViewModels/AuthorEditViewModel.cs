using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CnsApp31P19Libreria.ViewModels
{
    public class AuthorEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> WrittenBooksIDs { get; set; }
    }
}