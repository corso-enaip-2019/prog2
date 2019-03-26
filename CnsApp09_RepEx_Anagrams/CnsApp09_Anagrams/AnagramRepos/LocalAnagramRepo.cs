using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp09_Anagrams.AnagramRepos
{
    /// <summary>
    /// Questo dizionario funziona direttamente con una lista di parole (List di string).
    /// </summary>
    class LocalAnagramRepo : IAnagramRepo
    {
        List<string> _localAnagramRepo;

        #region ctor
        public LocalAnagramRepo()
        {
            _localAnagramRepo = new List<string>() { "mare", "remo", "arme", "rame", "dodecaedro" };


        }
        #endregion



        #region Metodi dall_interfaccia
        public List<string> FromWordToAnagramList(string inWord)
        {
            List<string> anagramsList = new List<string>();

            inWord = AlphabeticallyOrderStringLetters(inWord);
            int inWordLength = inWord.Length;

            /* Il codice: */
            //
            //if (AlphabeticallyOrderStringLetters(word) == inWord)
            //{ anagramsList.Add(word); }
            //
            /* controlla solo se le due parole sono permutazioni fra loro. */

            foreach (string word in _localAnagramRepo)
            {

                if (word.Length == inWordLength)
                {
                    if (AlphabeticallyOrderStringLetters(word) == inWord)
                    { anagramsList.Add(word); }
                }
            }

            return anagramsList;
        }

        public string GetRandomWord_WichHasAnagrams()
        {
            string outWord = "NA";

            if ((_localAnagramRepo == null) || (_localAnagramRepo.Count < 3))
            { outWord = "Too few words!"; }
            else
            {
                bool goodWord = false;
                Random rnd = new Random();

                while (!goodWord)
                {
                    //goodWord = (ThisWordHasAnagrams(_localAnagramRepo[rnd.Next(0, _localAnagramRepo.Count - 1)], _localAnagramRepo)) ? true : false;
                    int WordIndex = rnd.Next(0, _localAnagramRepo.Count - 1);
                    outWord = _localAnagramRepo[WordIndex];
                    goodWord = (ThisWordHasAnagrams(outWord, _localAnagramRepo)) ? true : false;
                }
            }

            return outWord;
        }

        public bool TheseAreAnagrams(string wordA, string wordB)
        {
            bool thoseAreAnagrams = false;

            //!!!!!!!!!!
            //Ulteriori controlli da fare (per vedere se le parole sono parole)

            if (wordA.Length != wordB.Length)
            {
                thoseAreAnagrams = false;
            }
            else
            {
                wordA = wordA.ToLower();
                wordB = wordB.ToLower();


                //!!!!!!!!!!
                //«AlphabeticallyOrderStringLetters()» non è pronto
                wordA = AlphabeticallyOrderStringLetters(wordA);
                wordB = AlphabeticallyOrderStringLetters(wordB);

                thoseAreAnagrams = (wordA == wordB) ? true : false;
            }

            return thoseAreAnagrams;
        }

        public List<string> ReturnFullAnagramList()
        { return _localAnagramRepo; }
        #endregion



        #region Dizionario locale
        /// <summary>
        /// ancora d'implementare
        /// </summary>
        /// <param name="inWords"></param>
        void AddEntriesTo_anagramRepo(params string[] inWords)
        {





        }
        #endregion

        List<string> GetStringsListWithoutThisString(string inWord, List<string> inList)
        {
            while (inList.Contains(inWord))
            { inList.Remove(inWord); }

            return inList;

            //List<string> outList = new List<string>();
            //foreach (string word in inList)
            //{
            //    if (word.ToLower() != inWord.ToLower())
            //    { outList.Add(word.ToLower()); }
            //}
            //
            //return outList;
        }

        List<string> GetWordListWithSameLengthOfThisWord(string inWord, List<string> inList)
        {
            List<string> outList = new List<string>();

            foreach (string word in inList)
            {
                if (word.Length == inWord.Length)
                { outList.Add(word.ToLower()); }
            }

            return outList;
        }

        bool ThisWordHasAnagrams(string inWord, List<string> inList)
        {
            bool hasAnagrams = false;
            List<string> workingList = new List<string>();

            workingList = GetWordListWithSameLengthOfThisWord(inWord, inList);
            workingList = GetStringsListWithoutThisString(inWord, workingList);

            hasAnagrams = (workingList.Count < 1) ? false : true;

            return hasAnagrams;
        }

        /// <summary>
        /// Riordina le lettere d'una stringa in ingresso (dopo averne fatto un «.ToLower()» alfabeticamente (ASCII-betically).
        /// </summary>
        /// <param name="inString">La stringa che verrà "riordinata" con le lettere in ordine alfabetico.</param>
        /// <returns>La stringa in ingresso con le lettere messe in ordine alfabetico.</returns>
        string AlphabeticallyOrderStringLetters(string inString)
        {
            inString = inString.ToLower();
            char[] charArrayDaOrdinare = inString.ToCharArray();
            /* Bubblesort (preso già pronto) */
            char temp = '_'; //variabile temporanea per lo scambio degli elementi

            //ciclo di ordinamento
            for (int j = 0; j < (charArrayDaOrdinare.Length - 1); j++)
                for (int i = 0; i < (charArrayDaOrdinare.Length - 1); i++)
                    if (charArrayDaOrdinare[i] > charArrayDaOrdinare[i + 1])
                    {
                        temp = charArrayDaOrdinare[i];
                        charArrayDaOrdinare[i] = charArrayDaOrdinare[i + 1];
                        charArrayDaOrdinare[i + 1] = temp;
                    }

            /* « new string(charArrayDaOrdinare) » converte un char[] in una nuova string. */
            return new string(charArrayDaOrdinare);
        }
    }
}