using System;

using System.Collections.Generic;

namespace Test1BenNic_Loan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float> TEN_YEARS_OF_INFLACTION = new List<float>() { 0.9f, 1.1f, 1.2f, -0.1f, 0.1f, 0.2f, 1.2f, 3.0f, 2.8f, 1.5f };
            const float FIXED_RATE = 3.50f;
            const int YEARS = 10;

            #region ConstStr
            const string MSG_WANTED_LOAN = "Immettere l\'importo voluto.";
            const string MSG_WANTED_LOAN_TYPE = "Immettere il tipo del mutuo (\"fisso\" | \"variabile\").";
            const string MSG_ALREADY_A_CUSTOMER = "Si è già un cliente (\"sì\"|\"no\")?";

            const string MSG_INITIAL = "Test1BenvegnuNicholas\nApplicazione calcolo mutui.";
            const string MSG_INFO_YEARS_1 = " Il mutuo avrà sempre ";
            string MSG_INFO_YEARS_2 = YEARS.ToString();
            const string MSG_INFO_YEARS_3 = " anni.";
            string MSG_INFO_YEARS = MSG_INFO_YEARS_1 + MSG_INFO_YEARS_2 + MSG_INFO_YEARS_3;
            const string MSG_INFO_FIXED_1 = " Il mutuo fisso sarà sempre del ";
            string MSG_INFO_FIXED_2 = FIXED_RATE.ToString();
            const string MSG_INFO_FIXED_3 = "%.";
            string MSG_INFO_FIXED = MSG_INFO_FIXED_1 + MSG_INFO_FIXED_2 + MSG_INFO_FIXED_3;
            #endregion

            Dictionary<int, float> tenYearsOfFloatingRates = new Dictionary<int, float>(GetFloatingRateFromInflationList(TEN_YEARS_OF_INFLACTION));
            Dictionary<int, float> tenYearsOfFixedRates = new Dictionary<int, float>(GetFixedRateXForYYears(FIXED_RATE, YEARS));
            IGui cnsGui = new CnsGui();
            ILoanCalculator loanC = new LoanCalculator01();

            cnsGui.ShowMessage(MSG_INITIAL);
            cnsGui.ShowMessage("");

            while (true)
            {
                cnsGui.ShowMessage(MSG_INFO_YEARS);
                cnsGui.ShowMessage(MSG_INFO_FIXED);
                cnsGui.ShowMessage("");

                float wantedLoan = cnsGui.RequestFloat(MSG_WANTED_LOAN);
                cnsGui.ShowMessage("");

                string wantedLoanType = "?";
                while (!(wantedLoanType == "fisso" || wantedLoanType == "variabile"))
                {
                    wantedLoanType = cnsGui.RequestString(MSG_WANTED_LOAN_TYPE).ToLower();
                    if (wantedLoanType.ToLower() == "q")
                        return;

                }
                cnsGui.ShowMessage("");

                bool isAlreadyACustomer = false;
                string inIsAlreadyACustomer = ""; ;
                while (!(inIsAlreadyACustomer == "sì" || inIsAlreadyACustomer == "si" || inIsAlreadyACustomer == "s" || inIsAlreadyACustomer == "no" || inIsAlreadyACustomer == "n"))
                {
                    inIsAlreadyACustomer = cnsGui.RequestString(MSG_ALREADY_A_CUSTOMER);
                    isAlreadyACustomer = inIsAlreadyACustomer.ToLower()[0] == 's' ? true : false;

                    if (wantedLoanType.ToLower() == "q")
                        return;
                }
                cnsGui.ShowMessage("");
                cnsGui.ShowMessage("");
                cnsGui.ShowMessage("");

                if (wantedLoanType == "fisso")
                    loanC.Run(wantedLoan, YEARS, wantedLoanType, isAlreadyACustomer, tenYearsOfFixedRates);
                else
                    loanC.Run(wantedLoan, YEARS, wantedLoanType, isAlreadyACustomer, tenYearsOfFloatingRates);


                cnsGui.ShowMessage("Valore del mutuo: ");
                cnsGui.ShowMessage("\t" + loanC.FinalAmount);
                cnsGui.ShowMessage("");

                if (cnsGui.RequestString("").ToLower() == "q")
                    return;
            }
        }

        static public Dictionary<int, float> GetFloatingRateFromInflationList(List<float> inInflation)
        {
            Dictionary<int, float> floatingRates = new Dictionary<int, float>();
            int year = 1;
            float floatingRatePercentAdd = 1.75f;

            foreach (float inflation in inInflation)
            {
                floatingRates.TryAdd(year, inflation / 100f * (100f + floatingRatePercentAdd));
                year++;
            }

            return floatingRates;
        }

        static public Dictionary<int, float> GetFixedRateXForYYears(float fixedRate, int years)
        {
            Dictionary<int, float> fixedRates = new Dictionary<int, float>();

            for (int i = 1; i <= years; i++)
            {
                fixedRates.Add(i, fixedRate);
            }

            return fixedRates;
        }
    }
}