using System;

namespace P22_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var installer = new TubeInstaller(new TubeFactory());

            installer.Install("pvc", 20);
            installer.Install("metal", 10);
            installer.Install("pvc", 30);

            // Se voglio testare il caso in cui il tubo venga fuori male,
            // mi creo un installer con una factory di mock:

            var installerWithErrors = new TubeInstaller(new MockTubeFactoryWithError());
            installerWithErrors.Install("pvc", 20);
            installerWithErrors.Install("metal", 10);
            installerWithErrors.Install("pvc", 30);

            Console.Read();
        }
    }

    abstract class Tube
    {
        protected Tube(double length)
        {
            Length = length;
        }

        public double Length { get; }
    }

    class PvcTube : Tube
    {
        public PvcTube(double length) : base(length) { }
    }

    class MetalTube : Tube
    {
        public MetalTube(double length) : base(length) { }
    }

    interface ITubeFactory
    {
        Tube Create(string material, double length);
    }

    class TubeFactory : ITubeFactory
    {
        public Tube Create(string material, double length) 
        {
            var randomValue = new Random().Next();
            if (randomValue < 0.000001)
                length = length * 1.03;

            switch(material)
            {
                case "metal":
                    return new MetalTube(length);
                case "pvc":
                    return new PvcTube(length);
                default:
                    throw new ArgumentException(nameof(material));
            }
        }
    }

    class MockTubeFactoryWithError : ITubeFactory
    {
        public Tube Create(string material, double length)
        {
            return new MetalTube(length * 1.1);
        }
    }

    class TubeInstaller
    {
        private ITubeFactory _factory;

        public TubeInstaller(ITubeFactory factory)
        {
            _factory = factory;
        }

        public void Install(string material, double length)
        {
            var tube = _factory.Create(material, length);

            if (tube.Length == length)
            {
                Console.WriteLine($"installato tubo di {material} con lunghezza {length}");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
