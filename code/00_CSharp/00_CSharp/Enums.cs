using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace FirstConsole
{
    class Enums
    {
        public static void Run()
        {
            // 'GetNames()' dà un array di stringhe con i nomi dei valori ("OnDesign", "Open"...).
            var names = Enum.GetNames(typeof(ProjectType));

            // 'GetValues()' dà un array con tutti i valori di tipo ProjectType.
            var values = Enum.GetValues(typeof(ProjectType));

            foreach (var n in names)
                Console.WriteLine(n);

            Console.WriteLine();

            foreach(var v in values)
                // Per stampare i valori numerici posso fare un cast a int.
                // Se non lo faccio, la console mi stampa di nuovo i nomi!
                Console.WriteLine((int)v);
        }
    }

    enum ProjectType
    {
        OnDesign,
        Open,
        Closed,
    }

    // Quando devo gestire una collezione di stringhe, anche con spazi o caratteri speciali,
    // e non voglio passare per un enum:
    public class ProjectTypes
    {
        public const string ON_DESIGN = "On Design";
        public const string OPEN = "Open";
        public const string CLOSED = "Closed";

        public static ReadOnlyCollection<string> VALUES { get; }

        // Manualmente:
        //static ProjectTypes()
        //{
        //    VALUES = new ReadOnlyCollection<string>(new[]
        //    {
        //        ON_DESIGN,
        //        OPEN,
        //        CLOSED
        //    });

        //    // problema: se aggiungo costanti stringhe, devo ricordarmi di aggiornare la lista!
        //}

        // Dinamicamente sulla classe stessa:
        //static ProjectTypes()
        //{
        //    VALUES = new ReadOnlyCollection<string>(typeof(ProjectTypes)
        //        .GetFields(BindingFlags.Public | BindingFlags.Static)
        //        .Where(fi => fi.FieldType == typeof(string))
        //        .Select(fi => (string)fi.GetValue(null))
        //        .ToArray());
        //}

        // però se ho altre classi con la stessa logica, mi tocca duplicare il codice!

        // Dinamicamente con classe di utility che sfrutti i generics o comunque la classe Type:
        static ProjectTypes()
        {
            VALUES = EnumUtilities.GetValues<ProjectTypes>();
            //VALUES = EnumUtilities.GetValues(typeof(ProjectTypes));
        }

        // Se uso la versione di 'EnumUtilities.GetValues()' con i generics,
        // non posso dichiarare questa classe come statica. Allora, per ottenere lo stesso effetto,
        // rendo il costruttore privato:
        private ProjectTypes() { }

        // La seconda versione di 'EnumUtilities.GetValues()' non ha questo problema, perché non indico
        // parametri generic, ma passo un Type come parametro normale.
    }

    public static class EnumUtilities
    {
        // Due versioni:

        // versione 1: T non può essere una classe statica
        public static ReadOnlyCollection<string> GetValues<T>()
        {
            return new ReadOnlyCollection<string>(typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(fi => fi.FieldType == typeof(string))
                .Select(fi => (string)fi.GetValue(null))
                .ToArray());
        }

        // versione 2: T può essere una classe statica
        public static ReadOnlyCollection<string> GetValues(Type type)
        {
            return new ReadOnlyCollection<string>(type
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(fi => fi.FieldType == typeof(string))
                .Select(fi => (string)fi.GetValue(null))
                .ToArray());
        }
    }

}
