namespace _07_Linq_esercizio
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) numero di inquilini di tutti gli appartamenti di classe energetica A o B
            // 2) media del numero di inquilini di tutti gli appartamenti
            // 3) di ogni città, nome di città e elenco di vie degli appartamenti
            // 4) di ogni città, nome di città e media dei metri quadri
            // 5) di ogni città, nome di città e media dei metri quadri,
            //        tutti ordinati per nome di città, e dentro la città ordinati per via.
            // 6) elenco dei nomi di città che hanno solo appartamenti NON in classe A, B, C.
        }
    }

    class Flat
    {
        public int SquareMeters { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Flatmates { get; set; }
        public EnergyClassType EnergyClass { get; set; }
    }
    
    enum EnergyClassType
    {
        A, B, C, D, E, F, G
    }
}
