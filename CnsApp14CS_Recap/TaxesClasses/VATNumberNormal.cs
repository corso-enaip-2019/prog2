using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesClasses
{
    class VATNumberNormal
    {
        public int VATCode;
        public List<decimal> Bills;
        public List<decimal> Expenses;

        #region ctor
        public VATNumberNormal(int vATCode, decimal firstBill)
        {
            this.VATCode = vATCode;
            this.Bills = new List<decimal>();
            this.Bills.Add(firstBill);
            this.Expenses = new List<decimal>();
        }

        public VATNumberNormal(int vATCode)
        {
            this.VATCode = vATCode;
            this.Bills = new List<decimal>();
            this.Expenses = new List<decimal>();
        }

        public VATNumberNormal()
        {
            //this.Bills = new List<decimal>();
            //this.Expenses = new List<decimal>();
        }
        #endregion
    }
}