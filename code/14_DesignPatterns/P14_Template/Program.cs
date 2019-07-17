using System;
using System.IO;

namespace P14_Template
{
    /*
     * Esercizio su Pattern TEMPLATE
     * 
     * C'è una classe Person che definisce FullName, Age, Salary.
     * Vogliamo salvarla su file, o formattandola in formato JSON o XML.
     * Creare due classi separate di salvataggio.
     * Entrambe le classi convertono un oggetto Person di input in una stringa,
     * e poi salvano la stringa su file.
     * 
     * Implementare le due classi con il pattern TEMPLATE.
     */
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

            var jsonSaver = new JsonSaver();
            var xmlSaver = new XmlSaver();

            jsonSaver.SaveOnFile(p);
            xmlSaver.SaveOnFile(p);
        }
    }

    class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }

    abstract class BaseSaver
    {
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

    class JsonSaver : BaseSaver
    {
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

    class XmlSaver : BaseSaver
    {
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
