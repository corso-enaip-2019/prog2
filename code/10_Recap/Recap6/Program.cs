using System;

namespace Recap6
{
    class Program
    {
        // Esercizio per dimostrare la necessità di avere strutture dati che
        // raggruppino informazioni tra loro collegate.
        // Qui vediamo i problemi che incontriamo se non abbiamo strutture dati come le classi.
        // Nel Recap6bis vedremo come una classe ci aiuta a risolverli.

        static void Main(string[] args)
        {
            // Leggo i valori che riguardano una persona.
            // Senza classi, devo dichiarare n variabili distinte.

            Console.Write("Inserire il nome della Persona: ");
            string name = Console.ReadLine();

            Console.Write("Inserire il cognome della Persona: ");
            string surname = Console.ReadLine();

            Console.Write("Inserire il genere della Persona: ");
            string gender = Console.ReadLine();

            Console.Write("Inserire lo stipendio della Persona: ");
            string salaryString = Console.ReadLine();
            decimal salary = decimal.Parse(salaryString);

            Console.Write("Inserire l'indirizzo della Persona: ");
            string address = Console.ReadLine();

            // Queste variabili devo sempre portarmele in giro,
            // Qualsiasi metodo io chiami:
            PrintAllModes(name, surname, gender, salary, address);

            Console.Read();
        }

        // Come il primo metodo, così tutti i sottometodi chiamati a loro volta
        // Devono elencare tutti i parametri:
        static void PrintAllModes(string name, string surname, string gender, decimal salary, string address)
        {
            PrintInline(name, surname, gender, salary, address);
            Console.WriteLine();
            PrintLarge(name, surname, gender, salary, address);
        }

        // anche qui, l'elenco di parametri è "duplicato".
        // Se devo cambiare un parametro, o aggiungerne o toglierne,
        // Devo andare a cambiare tutti i luoghi in cui ho l'elenco di parametri:
        static void PrintInline(string name, string surname, string gender, decimal salary, string address)
        {
            Console.Write($"nome: {name}; cognome: {surname}; genere: {gender}; salario: {salary} €; indirizzo: {address}");
        }

        static void PrintLarge(string name, string surname, string gender, decimal salary, string address)
        {
            Console.WriteLine($"nome: {name}");
            Console.WriteLine($"cognome: {surname}");
            Console.WriteLine($"genere: {gender}");
            Console.WriteLine($"salario: {salary}");
            Console.WriteLine($"indirizzo: {address}");
        }

        // C'è poi un ostacolo tecnico ancora più grande:
        // Per i metodi di stampa, avendo i parametri in input, posso elencarne quanti ne voglio.
        // Se invece volessi incapsulare la lettura dei valori, non potrei farlo,
        // perché dovrei scrivere un metodo che restituisca 6 valori, e in C#
        // come in molti altri linguaggi si può restituire solo un valore alla volta.
        // Ecco perché dobbiamo creare delle strutture dati che leghino dati fra loro coerenti
        // in modo che questi dati siano ricavabili a partire da un unico riferimento.
        // In Recap6bis vediamo una soluzione possibile.
    }
}
