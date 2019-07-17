using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid_principles_01
{
    // SINGLE RESPONSIBILITY
    // Ogni classe e ogni metodo dovrebbero avere una sola ragione per cambiare.

    // In questo esercizio abbiamo separato in diverse classi responsabilità diverse.

    class Program
    {
        static void Main(string[] args)
        {
            var inflationRates = CreateInflationRates();

            IGui gui = new ConsoleGui();

            gui.Output("*** Loan Calculator ***");

            var parameters = ReadParameters(gui);

            #region NO!!!! Troppa duplicazione, solo per decidere il tipo di mutuo!
            //if (loanType == "fisso")
            //{
            //    FixedLoanCalculator loanCalc = new FixedLoanCalculator();

            //    loanCalc.InitialAmount = askedLoan;
            //    loanCalc.IsClient = isClient;

            //    var loanApp = new LoanApplication(gui, loanCalc);
            //    loanApp.Run();
            //}
            //else if (loanType == "variabile")
            //{
            //    FloatingRateLoanCalculator loanCalc = new FloatingRateLoanCalculator();

            //    loanCalc.InitialAmount = askedLoan;
            //    loanCalc.IsClient = isClient;

            //    var loanApp = new LoanApplication(gui, loanCalc);
            //    loanApp.Run();
            //}
            #endregion

            ILoanCalculator loanCalc = CreateLoanCalculator(inflationRates, parameters.LoanType);

            loanCalc.InitialAmount = parameters.Amount;
            loanCalc.IsClient = parameters.IsClient;

            var loanApp = new LoanApplication(gui, loanCalc);
            loanApp.Run();

            Console.Read();
        }

        private static decimal[] CreateInflationRates()
        {
            return new[]
            {
                0.03M,
                0.02M,
                0.035M,
                0.01M,
                0M,
                0.05M,
                0.06M,
                0.07M,
                0.02M,
                0.01M,
            };
        }

        private static LoanParameters ReadParameters(IGui gui)
        {
            var amount = gui.InputDecimal("Inserisci il valore del mutuo che vuoi ricevere: ");

            var isClient = gui.InputBool("Sei già cliente (true/false)? ");

            var loanType = gui.InputStringInRange(
                    "Quale tipo di mutuo preferisci (fisso/variabile)? ",
                    new[] { "fisso", "variabile" });

            return new LoanParameters
            {
                Amount = amount,
                IsClient = isClient,
                LoanType = loanType,
            };
        }

        private static ILoanCalculator CreateLoanCalculator(decimal[] inflationRates, string loanType)
        {
            ILoanCalculator loanCalc;
            if (loanType == "fisso")
                loanCalc = new FixedLoanCalculator();
            else if (loanType == "variabile")
                loanCalc = new FloatingRateLoanCalculator(inflationRates);
            else
                throw new InvalidOperationException();
            return loanCalc;
        }
    }

    class LoanParameters
    {
        public decimal Amount { get; set; }
        public string LoanType { get; set; }
        public bool IsClient { get; set; }
    }

    class LoanApplication
    {
        private IGui _gui;
        private ILoanCalculator _loanCalculator;

        public LoanApplication(IGui gui, ILoanCalculator loanCalculator)
        {
            _gui = gui;
            _loanCalculator = loanCalculator;
        }

        public void Run()
        {
            _loanCalculator.Calculate();

            var finalAmount = Math.Round(_loanCalculator.FinalAmount, 2);

            _gui.Output($"ammontare finale: {finalAmount} {'\u20AC'}");
        }
    }

    interface IGui
    {
        void Output(string message);
        decimal InputDecimal(string question);
        bool InputBool(string question);
        string InputStringInRange(string question, string[] options);
    }

    class ConsoleGui : IGui
    {
        private const string INVALID_VALUE_MESSAGE = "Il valore inserito non è valido. Riprova: ";

        // costruttore statico, che viene chiamato la prima volta che l'app fa riferimento alla classe
        static ConsoleGui()
        {
            Console.OutputEncoding = Encoding.Default;
        }

        public decimal InputDecimal(string question)
        {
            Console.Write(question);

            while (true)
            {
                var canConvert = decimal.TryParse(Console.ReadLine(), out decimal value);

                if (canConvert && value > 0)
                    return value;

                Console.Write(INVALID_VALUE_MESSAGE);
            }
        }

        public bool InputBool(string question)
        {
            Console.Write(question);

            while (true)
            {
                var canConvert = bool.TryParse(Console.ReadLine(), out bool value);
                if (canConvert)
                    return value;

                Console.Write(INVALID_VALUE_MESSAGE);
            }
        }

        public string InputStringInRange(string question, string[] options)
        {
            Console.Write(question);

            while (true)
            {
                var value = Console.ReadLine();

                if (options.Contains(value))
                    return value;

                Console.Write(INVALID_VALUE_MESSAGE);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }

    interface ILoanCalculator
    {
        decimal InitialAmount { get; set;  }
        bool IsClient { get; set; }

        decimal FinalAmount { get; }

        void Calculate();
    }

    class FixedLoanCalculator : ILoanCalculator
    {
        const decimal INTERESTS_PERCENTAGE_CLIENT = 0.025M;
        const decimal INTERESTS_PERCENTAGE_NOT_CLIENT = 0.03M;

        public decimal InitialAmount { get; set; }
        public bool IsClient { get; set; }

        public decimal FinalAmount { get; private set;  }

        public void Calculate()
        {
            var rate = IsClient
                ? INTERESTS_PERCENTAGE_CLIENT
                : INTERESTS_PERCENTAGE_NOT_CLIENT;

            var amount = InitialAmount;

            for(int i = 0; i < 10; i++)
                amount *= (1 + rate);

            FinalAmount = amount;
        }
    }

    class FloatingRateLoanCalculator : ILoanCalculator
    {
        const decimal INTERESTS_PERCENTAGE_CLIENT = 0.01M;
        const decimal INTERESTS_PERCENTAGE_NOT_CLIENT = 0.015M;

        private decimal[] _inflationRates;

        public FloatingRateLoanCalculator(IEnumerable<decimal> inflationRates)
        {
            _inflationRates = inflationRates.ToArray();
        }

        public decimal InitialAmount { get;  set; }
        public bool IsClient { get; set; }

        public decimal FinalAmount { get; private set; }

        public void Calculate()
        {
            var rateSurplus = IsClient
                ? INTERESTS_PERCENTAGE_CLIENT
                : INTERESTS_PERCENTAGE_NOT_CLIENT;

            var amount = InitialAmount;

            for (int i = 0; i < 10; i++)
                amount *= (1 + (_inflationRates[i] + rateSurplus));

            FinalAmount = amount;
        }
    }
}
