using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp03Registry2
{
    class Grade
    {
        #region Attributi
        public string GradeSName { get; set; }
        List<Student> AttendingingStudent { get; set; }
        #endregion

        #region Metodi
        public bool AddStudentToGrade(Student studentToAdd)
        {
            bool SuccessfulAddition = false;

            if (AttendingingStudent.Contains(studentToAdd))
            { SuccessfulAddition = false; }
            else
            {
                AttendingingStudent.Add(studentToAdd);
                SuccessfulAddition = true;
            }

            return SuccessfulAddition;
        }
        #endregion

        #region Costruttori
        public Grade(string gradeSName)
        {
            GradeSName = gradeSName.ToString().ToUpper();
            AttendingingStudent = new List<Student>();
        }
        #endregion
    }
}