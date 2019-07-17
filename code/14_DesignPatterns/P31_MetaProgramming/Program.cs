using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace P31_MetaProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var objs = new List<object>
            {
                new Person
                {
                    Name = "Mario",
                    Surname = "Rossi",
                    GraduationDate = new DateTime(2019, 3, 1),
                    Age = 23,
                    Salary = 1400,
                },
                new Dog
                {
                    Nickname = "Fuffi",
                    Age = 32,
                    Race = DogRage.Pitbull,
                }
            };

            var jsonSaver = new JsonSaver();
            var xmlSaver = new XmlSaver();

            foreach(var obj in objs)
            {
                jsonSaver.SaveOnFile(obj);
                xmlSaver.SaveOnFile(obj);
            }
        }
    }

    class IgnoreOnSerializationAttribute : Attribute
    { }

    class FormatOnSerializationAttribute : Attribute
    {
        public FormatOnSerializationAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }

    class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [IgnoreOnSerialization]
        public string FullName { get { return $"{Name} {Surname}"; } }

        [FormatOnSerialization("yyyy-MM-dd")]
        public DateTime? GraduationDate { get; set; }

        public int Age { get; set; }

        [IgnoreOnSerialization]
        public int AgeInMonth { get { return Age * 12; } }

        public decimal Salary { get; set; }
    }

    class Dog
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DogRage Race { get; set; }
    }

    enum DogRage
    {
        Pug,
        Pitbull,
        Rottweiler,
    }

    abstract class BaseSaver
    {
        public void SaveOnFile(object obj)
        {
            var className = obj.GetType().Name;

            var properties = GetProperties(obj);

            string formatted = FormatAsString(className, properties);

            SaveOnFile(formatted);
        }

        private Dictionary<string, string> GetProperties(object obj)
        {
            return obj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => pi.GetCustomAttribute<IgnoreOnSerializationAttribute>() == null)
                .ToDictionary(
                    pi => pi.Name,
                    pi =>
                    {
                        var formatAttr = pi.GetCustomAttribute<FormatOnSerializationAttribute>();
                        var value = pi.GetValue(obj);

                        if (value != null)
                        {
                            if (formatAttr != null)
                                return string.Format("{0:" + formatAttr.Format + "}", value);
                            else
                                return value.ToString();
                        }
                        else
                        {
                            return "";
                        }
                    });
        }

        protected abstract string FormatAsString(string className, Dictionary<string, string> properties);

        private void SaveOnFile(string formatted)
        {
            var fileName = GetFileName();

            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName);

            File.AppendAllText(path, formatted);
        }

        protected abstract string GetFileName();
    }

    class JsonSaver : BaseSaver
    {
        protected override string FormatAsString(string className, Dictionary<string, string> properties)
        {
            var items = properties.Select(p => $"\"{p.Key}\":\"{p.Value}\"");

            return "{" + string.Join(',', items) + "}";
        }

        protected override string GetFileName()
        {
            return "person-as-json.txt";
        }
    }

    class XmlSaver : BaseSaver
    {
        protected override string FormatAsString(string className, Dictionary<string, string> properties)
        {
            var items = properties.Select(p => $"<{p.Key}>{p.Value}</{p.Key}>");

            return $"<{className}>{string.Concat(items)}</{className}>";
        }

        protected override string GetFileName()
        {
            return "person-as-xml.txt";
        }
    }
}
