using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp09_Anagrams
{
    /// <summary>
    /// Dizionario (non necessariamente un Dictionary di C#!) d'anagrammi.
    /// Ogni dizionario deve possedere un metodo che 
    /// - data una parola (stringa) in ingresso restituisca una lista di suoi anagrammi;
    /// - date due parole restituisca (bool) se quest'ultime siano anagrammi fra loro i meno;
    /// - restituisca una parola (string) casuale (che possieda anagrammi).
    /// </summary>
    interface IAnagramRepo
    {
        /// <summary>
        /// Data una parola (stringa) in ingresso restituisce una lista di suoi anagrammi (List di string).
        /// </summary>
        /// <param name="inWord">Parola (string) della quale restituire una lista d'anagrammi.</param>
        /// <returns>Lista di parole (List di string) contenente gl'anagrammi della parola immessa.</returns>
        List<string> FromWordToAnagramList(string inWord);
        
        /// <summary>
        /// Date due parole (string), restituisce (bool) se sono anagrammi fra loro.
        /// Se sono la stessa parola, restituisce false.
        /// </summary>
        /// <param name="wordA"></param>
        /// <param name="wordB"></param>
        /// <returns>bool Sono anagrammi fra loro? Sono anagrammi -> true / Son sono anagrammi -> false / Sono la stessa parola -> false.</returns>
        bool TheseAreAnagrams(string wordA, string wordB);

        /// <summary>
        /// Se chiamato, scansiona il dizionario e restituisce una parola a caso che possiede almeno un anagramma.
        /// </summary>
        /// <returns>Una parola a caso che ha almeno un anagramma.</returns>
        string GetRandomWord_WichHasAnagrams();

        List<string> ReturnFullAnagramList();
    }
}