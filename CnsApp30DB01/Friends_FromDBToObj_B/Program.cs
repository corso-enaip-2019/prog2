using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20180508*/
/* Senza usare le FriendEntity. */
/* !!! Incompleto !!! */

namespace Friends_FromDBToObj_B
{

    class Program
    {
        private const string CNN_STRING = @"Server=TRISRV10\SQLEXPRESS; Database=CS2019_BenNic; Trusted_Connection=True;";

        static void Main(string[] args)
        {
            List<Friend> friendList = GetFriendListFromDB();


            Console.ReadLine();
        }

        static private List<Friend> GetFriendListFromDB()
        {
            List<Friend> friendsFromDB = new List<Friend>();

            using (var cnn = new SqlConnection(CNN_STRING))
            {
                cnn.Open();

                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    string cmdTxt = "SELECT [ID],[Name],[BestFriendID] FROM x02Friends";
                    cmd.CommandText = cmdTxt;

                    cmd.ExecuteNonQuery();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var frn = new FriendEntity()
                            {
                                ID = (int)rdr["ID"],
                                Name = rdr["Name"].ToString(),
                                FriendID = (rdr["BestFriendID"] == DBNull.Value) ? null : (int?)rdr["BestFriendID"]
                            };

                            friendsFromDB.Add(frn);
                        }
                    }
                }
            }

            return FromFriendEntityListToFriendList(friendsFromDB);
        }

        private static List<Friend> FromFriendEntityListToFriendList(List<FriendEntity> friendsFromDB)
        {
            List<Friend> friends = new List<Friend>();

            foreach (FriendEntity fe in friendsFromDB)
            {
                Friend frn = new Friend(fe.ID, fe.Name);
                friends.Add(frn);
            }


            return friends;
            //return PopulateBestFriends(friends);
        }

        static private List<Friend> PopulateBestFriends(List<Friend> friends)
        {
            /* Per ogni record, leggi FriendID -> set l'oggetto Friend con il Friend ID corrispondente. */
            /* Se è null, saltalo. */
            foreach (Friend f in friends)
            {
                //f.HisFriend = Friend con ID == FriendID

                //f.HisFriend = friends.FirstOrDefault(x => x.ID == f.FriendID);
            }

            return friends;
        }
    }
}