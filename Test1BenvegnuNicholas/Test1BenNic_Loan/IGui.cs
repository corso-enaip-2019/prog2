using System;
using System.Collections.Generic;
using System.Text;

namespace Test1BenNic_Loan
{
    interface IGui
    {
        float RequestFloat(string message);
        string RequestString(string message);

        void ShowMessage(string message);
    }
}