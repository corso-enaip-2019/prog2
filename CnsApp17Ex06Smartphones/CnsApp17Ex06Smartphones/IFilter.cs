using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp17Ex06Smartphones
{
    interface IFilter<T>
    {
        bool Filter(T item);
    }
}