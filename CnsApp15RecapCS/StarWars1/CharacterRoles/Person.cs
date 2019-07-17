using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace StarWars1
{
    abstract class Person
    {
        #region OldStyle GetSet manuale
        //  private string name;
        //  public string GetName()
        //  {
        //     return name;
        //  }
        //  private void SetName(string value)
        //  {
        //     if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        //     {
        //         throw new ArgumentException("The name cannot be empty or blank.");
        //     }
        //  
        //     name = value;
        //  }

        /* « value.All(c => c == ' ') » controlla (con Linq) se contiene il carattere char spazio "normale" ' '.
         * Espone a tutti gl'altri caratteri di spazio (tab, spazi CJK, etc.). */
        //if (value == null || value == "" || value == string.Empty || value.All(c => c == ' '))
        //{
        //    throw new ArgumentException("The name cannot be empty or blank.");
        //}
        #endregion

        #region propFull01
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        #endregion

        #region ctor
        public Person(string name)
        {
            Name = name;
        }

        /* Costruttore con l'uso diretto della variabile privata. */
        //public Person(string name)
        //{
        //    this.name = name;
        //}

        /* Costruttore usando il GetSet manuale usando il metodo «SetName(string value)». */
        //public Person(string name)
        //{
        //    SetName(name);
        //}
        #endregion

        
    }
}