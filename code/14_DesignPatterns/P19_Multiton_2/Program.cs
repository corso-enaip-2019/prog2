using System;
using System.Collections.ObjectModel;
using System.IO;

namespace P19_Multiton_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person
            {
                FullName = "Mario Rossi",
                Age = 23,
                Salary = 1400,
            };

            Saver.Json.SaveOnFile(p);
            Saver.Xml.SaveOnFile(p);

            foreach (var s in Saver.List)
                s.SaveOnFile(p);
        }
    }

    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }

    public class Saver
    {
        static Saver()
        {
            Json = new Saver(JsonFormat, "person-as-json.txt");
            Xml = new Saver(XmlFormat, "person-as-xml.txt");

            List = new ReadOnlyCollection<Saver>(new Saver[] { Json, Xml });
        }

        public static Saver Json { get; }
        public static Saver Xml { get; }

        public static ReadOnlyCollection<Saver> List { get; }

        private Saver(Func<Person, string> formatter, string fileName)
        {
            _formatter = formatter;
            _fileName = fileName;
        }

        public void SaveOnFile(Person p)
        {
            string formatted = _formatter(p);

            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                _fileName);

            File.WriteAllText(path, formatted);
        }

        private static string JsonFormat(Person p)
        {
            return
                "{" +
                    $"\"{nameof(Person.FullName)}\":\"{p.FullName}\"," +
                    $"\"{nameof(Person.Age)}\":{p.Age}," +
                    $"\"{nameof(Person.Salary)}\":{p.Salary}" +
                "}";
        }

        private static string XmlFormat(Person p)
        {
            return $"<{nameof(Person)}>" +
                    $"<{nameof(Person.FullName)}>{p.FullName}</{nameof(Person.FullName)}>" +
                    $"<{nameof(Person.Age)}>{p.Age}</{nameof(Person.Age)}>" +
                    $"<{nameof(Person.Salary)}>{p.Salary}</{nameof(Person.Salary)}>" +
                $"</{nameof(Person)}>";
        }

        private Func<Person, string> _formatter;
        private string _fileName;
    }
}
