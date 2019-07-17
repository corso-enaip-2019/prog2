using System;

using System.Collections.Generic;

namespace CnsApp18LinQExtensions
{
    static class Extensions
    {
        #region filtri
        delegate bool Filter<T>(T item);

        //static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Filter<T> condition)
        //{
        //    List<T> outList = new List<T>();

        //    foreach (T item in input)
        //    {
        //        /* Il "== true" aggiunto al "if (condition(item) == true)" è inunile, l'ho aggiunto per esplicitare il fatto che il metodo/delegate deve dare un bool. */
        //        if (condition(item) == true)
        //        {
        //            outList.Add(item);
        //        }
        //    }

        //    return outList;
        //}

        #endregion

    }
}
