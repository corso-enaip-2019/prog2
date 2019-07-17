using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P13_DesignPattern_01.Employees
{
    class HourlyPaidEmpoyee : Employee
    {
        public HourlyPaidEmpoyee()
        {
            _WorkedTimes = new List<WorkedTime>();
        }

        // vedi nota a fondo file sul perché creare una proprietà così
        public IEnumerable<WorkedTime> WorkedTimes
        {
            get { return _WorkedTimes.ToList(); }
        }
        private readonly List<WorkedTime> _WorkedTimes;

        public decimal HourlyRate { get; set; }

        public void AddWorkedHours(int year, int month, int day, int workedHours)
        {
            _WorkedTimes.Add(new WorkedTime(year, month, day, workedHours));
        }

        public override decimal CalculatePay(DateTime date)
        {
            //var now = DateTime.Now.AddDays(1).Date;
            var now = date.Date.AddDays(1);

            var start = now.AddDays(-7);

            var workedHours = WorkedTimes
                .Where(wt => start < wt.Date && wt.Date < now)
                .Sum(wt => wt.Hours);

            return workedHours * HourlyRate;
        }

        public override bool IsPayDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday;
        }

        // siccome la classe ha solo due campi strettamente collegati tra loro,
        // in questo caso può aver senso usare una 'struct' invece di una 'class'
        public struct WorkedTime
        {
            public WorkedTime(int year, int month, int day, int hours)
            {
                Date = new DateTime(year, month, day);
                Hours = hours;
            }

            public WorkedTime(DateTime date, int hours)
            {
                Date = date;
                Hours = hours;
            }

            public DateTime Date { get; }
            public int Hours { get; }
        }
    }

    /*
     * Il vedere le ore pagate all'esterno della classe è implentato così:
     * - Ho un campo privato definito come List<WorkedTime>.
     *     Solo dentro la classe vedo questo campo e posso aggiungere e rimuovere elementi.
     *     Avendolo poi dichiarato readonly, solo nel costruttore posso assegnare un valore
     *     (ad esempio istanziando la lista).
     * - Ho una proprietà IEnumerable<WorkedTime> in solo get. Così nessuno da fuori può
     *     reimpostare il valore dell'intera lista.
     *     In più, essendo dichiarato come IEnumerable e non come List, da fuori posso solo
     *     fare un foreach sulla collezione di WorkedTime, NON posso aggiungere e rimuovere elementi.
     *     
     *  Questo modo di procedere si chiama INFORMATION HIDING, e serve a mantenere il codice "pulito":
     *  nascondo i dettagli implementativi di una classe, in modo che dall'esterno si usi
     *  solo quello che si deve usare.
     *  
     *  Occhio che ENCAPSULATION != INFORMATION HIDING != SECURITY !!!
     *  
     *  ENCAPSULATION è solo la modalità per cui incapsulo, dentro gli oggetti, dati e operazioni insieme
     *      (in questo la programmazione ad oggetti è la regina dell'encapsulation).
     *      
     *  INFORMATION HIDING, in C#, si può fare con i modificatori protected/private/interal,
     *  ma questo NON è SECURITY.
     *  
     *  Infatti, io potrei scrivere all'esterno questo codice:
     *      var list = (List<WorkedHour>)employee.WorkedHours.
     *  Il cast funzionerebbe, visto che dietro l'interfaccia IEnumerable c'è proprio una List.
     *  Quindi dall'esterno un "malintenzionato" può con facilità ritrovare la lista private dell'employee
     *  e aggiungere o rimuovere elementi.
     *  
     *  Potrei usare un "trucco": la proprietà non restituisce direttamente il campo List,
     *  ma da quella sua lista interna crea un altra lista da restituire (usando il ToList() di LINQ).
     *  Così, se anche all'esterno si fa un cast, lo si fa su una lista nuova che nulla ha a che vedere
     *  con la lista interna all'oggetto.
     *  
     *  Però un "malintenzionato" può vedere, tramite Reflection, tutto il contenuto della classe,
     *  anche 'private':
     * 
     *     typeof(HourlyPaidEmpoyee)
     *         .GetFields()
     *         .Where(fi => fi.IsPrivate)
     *         .ToList()
     *         .ForEach(fi => fi.SetValue(employee, null)); // <-- qui setto a null la lista 'private'
     * 
     * Notare che Reflection non è un tool da "hacker", è un tool che fa parte del mondo C#/.NET.
     */
}
