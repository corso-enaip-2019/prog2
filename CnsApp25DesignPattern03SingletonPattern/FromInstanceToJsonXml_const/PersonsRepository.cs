using System;
using System.Collections.Generic;
using System.Text;

namespace FromInstanceToJsonXml_const
{
    class PersonsRepository
    {
        #region singleton
        /* Costruttore "vero, normale" reso privato. */
        private PersonsRepository()
        {
            _items = new List<Person>();
        }

        /* Costruttore statico */
        static PersonsRepository()
        {
            InstanceOfPersonsRepository = new PersonsRepository();
        }

        /* Prop read-only dell'istanza. */
        public static PersonsRepository InstanceOfPersonsRepository { get; }
        #endregion

        #region campi privati
        private List<Person> _items;
        #endregion

        #region crud
        public void AddPerson(Person personToAdd)
        {

        }

        public void GetPerson(int personID)
        { }

        public void UpdatePerson(Person p)
        { }

        public void DeletePerson(Person personToDelete)
        { }

        public void DeletePerson(int personID)
        { }
        #endregion
    }
}