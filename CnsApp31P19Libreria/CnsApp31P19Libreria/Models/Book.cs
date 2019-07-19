using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CnsApp31P19Libreria.Models
{
    public class Book
    {
        public int IDBook { get; set; }
        public string Title { get; set; }

        public List<Author> Authors { get; set; }
    }
}