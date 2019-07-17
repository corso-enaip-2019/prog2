using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp09_Anagrams.Gameplays
{
    class Challenge : IGameplay
    {
        public string Name => "Challenge";
        public string Description => $"Data una parola dal programma, scriverne un anagramma entro {sAvailableMaxTime} secondi.";
        public string Code => "c";

        int sAvailableMaxTime = 10;
        int[,] pointScale = new int[6, 2];
        DateTime requestMoment = new DateTime();
        DateTime responseMoment = new DateTime();

        #region ctor
        public Challenge(int inSAvailableMaxTime = 10)
        {
            int[,] pointScale =
                { { 10, 0 },
                { 9, 1 },
                { 8, 1 },
                { 7, 2 },
                { 6, 2 },
                { 5, 4 } };
        }
        #endregion

        #region metodi dall_interfaccia
        public void RunGameplay(IAnagramRepo chosenRepo, List<IUIHandler> usedUIHandlers)
        {
            foreach (IUIHandler handler in usedUIHandlers)
            {
                string inWord = "?";
                while (inWord != "000")
                {
                    handler.WriteStringToUI($" ");
                    handler.WriteStringToUI($"Modalità {Name}: {Description}");
                    handler.WriteStringToUI($" ");

                    string givenWord = chosenRepo.GetRandomWord_WichHasAnagrams();



                    requestMoment = DateTime.Now;
                    inWord = handler.AskForString($"Immettere un anagramma della parola «{givenWord}» (immettere «000» per uscire dalla modalità) ...");
                    responseMoment = DateTime.Now;

                    if (inWord == "000")
                    { break; }

                    if (chosenRepo.TheseAreAnagrams(givenWord, inWord))
                    {
                        int points=CalculateGainedPoints(requestMoment, responseMoment, pointScale, sAvailableMaxTime, out int elapsedSeconds);
                        handler.WriteStringToUI($"Anagramma trovato in {elapsedSeconds}!");
                        handler.WriteStringToUI($"Guadagnati {points} punti!");

                    }
                    else
                    { handler.WriteStringToUI("Anagramma non trovato!"); }


                    List<string> anagramList = new List<string>();
                    anagramList = chosenRepo.ReturnFullAnagramList();
                    anagramList = chosenRepo.FromWordToAnagramList(inWord);

                    handler.WriteStringToUI($"Lista d\'anagrammi di «{inWord}»:");

                    foreach (string anagram in anagramList)
                    {
                        handler.WriteStringToUI($" {anagram}");
                    }

                }
            }


        }
        #endregion

        //da controllare deltatime perché è un istante di tempo con 0 nel 1'970 e non una differenza di tempo
        int CalculateGainedPoints(DateTime ask, DateTime respond, int[,] pointScale, int maxSeconds, out int elapsedSeconds)
        {
            int points = 0;
            TimeSpan deltaTime = new TimeSpan();
            TimeSpan maxTimeToRespond = new TimeSpan(0,0,0,maxSeconds);
            deltaTime = respond - ask;
            if (deltaTime > maxTimeToRespond)
            { points = 0; }
            else
            {
                for (int i = 0; i < pointScale.Length / 2; i++)
                {
                    int seconds = pointScale[i, 0];
                    TimeSpan confrontSeconds = new TimeSpan(0, 0, 0, seconds);
                    int deltaPoints = pointScale[i, 1];
                    if (deltaTime < confrontSeconds)
                    { points = points + deltaPoints; }
                }
            }

            elapsedSeconds = ((deltaTime.Days*24 + deltaTime.Hours)*60 + deltaTime.Minutes)*60 + deltaTime.Seconds;
            return points;
        }
    }
}