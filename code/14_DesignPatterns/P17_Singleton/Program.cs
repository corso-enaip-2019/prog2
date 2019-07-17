using System;
using System.IO;

namespace P17_Singleton
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

            JsonSaver.Instance.SaveOnFile(p);
            XmlSaver.Instance.SaveOnFile(p);
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
        static JsonSaver()
        {
            Instance = new JsonSaver();
        }

        public static JsonSaver Instance { get;  }

        private JsonSaver() { }

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
        static XmlSaver()
        {
            Instance = new XmlSaver();
        }

        public static XmlSaver Instance { get; }

        private XmlSaver() { }

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
