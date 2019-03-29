using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesProcedural
{
    class VATNumberSimple
    {
        public int VATCode;
        public List<decimal> Bills;

        public VATNumberSimple(int vATCode, decimal firstBill)
        {
            this.VATCode = vATCode;
            this.Bills = new List<decimal>();
            this.Bills.Add(firstBill);
        }

        public VATNumberSimple(int vATCode)
        {
            this.VATCode = vATCode;
            this.Bills = new List<decimal>();
        }

        public VATNumberSimple()
        {
            //this.Bills = new List<decimal>();
        }
    }
}
