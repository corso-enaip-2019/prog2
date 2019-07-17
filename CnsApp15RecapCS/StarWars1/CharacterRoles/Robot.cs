using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars1
{
    class Robot:IComforter
    {
        public string Name { get;}

        public Robot(string name)
        {
            Name = name;
        }

        public void ComfortChild(Baby baby)
        {
            Console.WriteLine($"{Name} genera una frequenze armonica sulla quale sincronizza i movimenti delle sue braccia per cullare il bambino {baby.Name}.");
        }
    }
}