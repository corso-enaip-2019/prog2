using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_FromDBToObj
{
    class Friend
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Friend HisFriend { get; set; }

        #region ctor
        public Friend() { }

        public Friend(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public Friend(int iD, string name, Friend hisFriend)
        {
            ID = iD;
            Name = name;
            HisFriend = hisFriend;
        }
        #endregion
    }
}