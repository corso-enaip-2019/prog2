using System.ComponentModel;

namespace P16_Databases_07_EntityFramework
{
    public class Book : BaseModel
    {
        public int Id { get; set; }

        public string Title
        {
            get { return _Title; }
            set { SetAndRaise(value, ref _Title); }
        }
        private string _Title;

        public int Year { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
