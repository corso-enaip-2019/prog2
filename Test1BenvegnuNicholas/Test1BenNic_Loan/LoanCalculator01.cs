using System;
using System.Collections.Generic;
using System.Text;

namespace Test1BenNic_Loan
{
    class LoanCalculator01 : ILoanCalculator
    {
        public float InitialAmount { get; set; }
        public float FinalAmount { get; set; }
        public bool IsClient { get; set; }

        public void Run(float wantedLoan, int years, string typeOfRate, bool isAlreadyAClient, Dictionary<int, float> yearsOfFloatingRate)
        {
            Calculate(wantedLoan, years, typeOfRate, isAlreadyAClient, yearsOfFloatingRate);
        }

        public void Calculate(float wantedLoan, int years, string typeOfRate, bool isAlreadyAClient, Dictionary<int, float> yearsOfFloatingRate)
        {
            float finalAmount = 0f, sale = 0.80f;

            finalAmount = CalcFinalAmount(wantedLoan, years, typeOfRate, isAlreadyAClient, yearsOfFloatingRate);
            this.FinalAmount = isAlreadyAClient == true ? finalAmount * sale : finalAmount;

            return;
        }




        float CalcFinalAmount(float wantedLoan, int years, string typeOfRate, bool isAlreadyAClient, Dictionary<int, float> yearsOfFloatingRate)
        {
            float finalAmount = 0f;

            Dictionary<int, float> yearsOfInterests = new Dictionary<int, float>();

            foreach (int year in yearsOfFloatingRate.Keys)
                yearsOfInterests.Add(year, wantedLoan / years + wantedLoan / years * yearsOfFloatingRate[year]);

            foreach (int year in yearsOfInterests.Keys)
                finalAmount = finalAmount + yearsOfInterests[year];

            return finalAmount;
        }
    }
}