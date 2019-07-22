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

        public string GetListOfAuthorsInString()
        {
            List<Author> inList = this.AuthorsList;
            if (inList == null)
                throw new ArgumentException("Ricevuto null come lista");

            else if (inList.Count == 0)
                return "[Lista d\'autori vuota]";

            else if (inList.Count == 1)
                return inList[0].Name.ToString();

            else
            {
                string outString = inList[0].Name.ToString();

                for (int i = 1; i < inList.Count; i++)
                {
                    string.Concat(outString, ", ", inList[i].Name.ToString());
                }

                return outString;
            }
        }
    }
}