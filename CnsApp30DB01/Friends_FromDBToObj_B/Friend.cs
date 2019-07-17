using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_FromDBToObj_B
{
    class Friend
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FriendID { get; set; }
        public Friend HisFriend { get; set; }

        #region ctor
        public Friend() { }

        public Friend(int iD, string name, int friendID)
        {
            ID = iD;
            Name = name;
            FriendID = friendID;
        }

        public Friend(int iD, string name, Friend hisFriend)
        {
            ID = iD;
            Name = name;
            FriendID= (hisFriend == null)? FriendID = 0: hisFriend.ID;
            HisFriend = hisFriend;
        }
        #endregion
    }
}