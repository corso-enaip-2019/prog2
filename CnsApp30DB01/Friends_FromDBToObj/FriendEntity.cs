using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_FromDBToObj
{
    class FriendEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? FriendID { get; set; }

        #region ctor
        public FriendEntity() { }

        public FriendEntity(int iD, string name, int? friendID)
        {
            ID = iD;
            Name = name;
            FriendID = friendID;
        }
        #endregion
    }
}
