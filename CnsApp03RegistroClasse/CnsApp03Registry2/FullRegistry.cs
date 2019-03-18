using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp03Registry2
{
    class FullRegistry
    {
        #region Attributi
        Dictionary<int, Grade> RegisteredGrade { get; set; }
        #endregion

        #region Metodi
        public void RegisterGrade(int numberGrade, Grade gradeNameToAdd)
        {
            RegisteredGrade.Add(numberGrade, gradeNameToAdd);
            return;
        }

      
        // !!! Non conosco come ricavare la key dal value (che potenzialmente puo' essere gestito dalla classe grade?)
        //public bool AddStudentToNamedGrade(Student studentToAdd, string gradeName)
        //{
        //    bool SuccessfulAddition = false;

        //    /* Controllo dell'esistenza d'un "Grade" con quel nome. */
        //    if (RegisteredGrade.ContainsValue(gradeName))
        //    { SuccessfulAddition = this.RegisteredGrade[/*ComeOttenereLaKey?*/].AddStudentToGrade(studentToAdd); }
        //    else
        //    { SuccessfulAddition = false; }

        //    return SuccessfulAddition;
        //}


        public bool AddStudentToNumberedGrade(Student studentToAdd, int gradeNumber)
        {
            bool SuccessfulAddition = false;

            /* Controllo dell'esistenza d'un "Grade" con quel numero come Key. */
            if (RegisteredGrade.ContainsKey(gradeNumber))
            { SuccessfulAddition = this.RegisteredGrade[gradeNumber].AddStudentToGrade(studentToAdd); }
            else
            { SuccessfulAddition = false; }

            return SuccessfulAddition;
        }
        #endregion

        #region Costruttori
        public FullRegistry()
        { RegisteredGrade = new Dictionary<int, Grade>(); }
        #endregion
    }
}