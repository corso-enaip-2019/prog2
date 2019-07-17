using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria
{
    /// <summary>
    /// Definisce una porzione di caffé liquido (non una tazzina di caffé).
    /// </summary>
    class Coffee
    {
        //public enum CupSize { S, M, L }
        //messo in Program.cs

        public CupSize Size { get; /*set;*/ }
        public float Price { get; /*set;*/ }



        #region ctor
        public Coffee():this(CupSize.M)
        { }

        public Coffee(CupSize size)
        {
            Size = size;
            Price = FromSizeToPrice(size);
        }

        public Coffee(string strSize)
        {
            CupSize Size = FromStringToSize(strSize);
            Price = FromSizeToPrice(Size);
        }
        #endregion



        float FromSizeToPrice(CupSize size)
        {
            float price = 314f;

            switch (size)
            {
                case CupSize.S:
                    {
                        price = 0.90f;
                        break;
                    }
                case CupSize.M:
                    {
                        price = 1.00f;
                        break;
                    }
                case CupSize.L:
                    {
                        price = 1.10f;
                        break;
                    }
                default:
                    {
                        price = 666f;
                        break;
                    }
            }

            return price;
        }

        CupSize FromStringToSize(string strSize)
        {
            CupSize size;

            switch (strSize.ToLower())
            {
                case "s":
                    {
                        size = CupSize.S;
                        break;
                    }
                case "m":
                    {
                        size = CupSize.M;
                        break;
                    }
                case "l":
                    {
                        size = CupSize.L;
                        break;
                    }

                default:
                    {
                        //!!! 3rror ?
                        size = CupSize.S;
                        break;
                    }
            }

            return size;
        }
    }
}