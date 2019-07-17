using System;
using System.Collections.Generic;
using System.Text;

namespace Test1BenNic_Loan
{
    interface ILoanCalculator
    {
        float InitialAmount { get; set; }
        float FinalAmount { get; set; }
        bool IsClient { get; set; }

        void Calculate(float wantedLoan, int years, string typeOfRate, bool isAlreadyAClient, Dictionary<int, float> yearsOfFloatingRate);

        void Run(float wantedLoan, int years, string typeOfRate, bool isAlreadyACustomer, Dictionary<int, float> yearsOfFloatingRate);
    }
}