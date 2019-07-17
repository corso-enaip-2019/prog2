using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace P17_Multiton
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

    public abstract class Saver
    {
        static Saver()
        {
            Json = new JsonSaver();
            Xml = new XmlSaver();
            List = new ReadOnlyCollection<Saver>(new Saver[] { Json, Xml });
        }

        public static JsonSaver Json { get; }
        public static XmlSaver Xml { get; }

        public static ReadOnlyCollection<Saver> List { get; }

        public void SaveOnFile(Person p)
        {
            string formatted = FormatAsString(p);

            SaveOnFile(formatted);
        }

        protected abstract string FormatAsString(Person p);

        private void SaveOnFile(string formatted)
        {
            var fileName = GetFileName();

            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName);

            File.WriteAllText(path, formatted);
        }

        protected abstract string GetFileName();
    }

    public class JsonSaver : Saver
    {
        internal JsonSaver() { }
        protected override string FormatAsString(Person p)
        {
            return
                "{" +
                    $"\"{nameof(Person.FullName)}\":\"{p.FullName}\"," +
                    $"\"{nameof(Person.Age)}\":{p.Age}," +
                    $"\"{nameof(Person.Salary)}\":{p.Salary}" +
                "}";
        }
        protected override string GetFileName()
        {
            return "person-as-json.txt";
        }
    }

    public class XmlSaver : Saver
    {
        internal XmlSaver() { }
        protected override string FormatAsString(Person p)
        {
            return
                $"<{nameof(Person)}>" +
                    $"<{nameof(Person.FullName)}>{p.FullName}</{nameof(Person.FullName)}>" +
                    $"<{nameof(Person.Age)}>{p.Age}</{nameof(Person.Age)}>" +
                    $"<{nameof(Person.Salary)}>{p.Salary}</{nameof(Person.Salary)}>" +
                $"</{nameof(Person)}>";
        }
        protected override string GetFileName()
        {
            return "person-as-xml.txt";
        }
    }
}
