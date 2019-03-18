using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp03Registry2
{
    class Student
    {
        #region Attributi
        public string StudentSName { get; set; }
        #endregion

        #region Metodi
        #endregion

        #region Costruttori
        public Student(string name)
        { StudentSName = name.ToString(); }
        #endregion
    }
}
