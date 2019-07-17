using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16_Databases_02_Readers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol1 = P16_Databases_02_Readers_Solution1.Application.ReadFriends();

            var sol2 = P16_Databases_02_Readers_Solution2.Application.ReadFriends();

            Console.Write("Operation successful, press a key to exit...");
            Console.Read();
        }
    }
}

namespace P16_Databases_02_Readers_Solution1
{
    public static class Application
    {
        public static List<Friend> ReadFriends()
        {
            var result = new List<Friend>();

            using (var conn = new SqlConnection(@"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        " SELECT f.Id, f.Name, f.BestFriendId, ff.Name as BestFriendName" +
                        " FROM Friends f JOIN Friends as ff on f.BestFriendId = ff.Id";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var e = new Friend
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                BestFriend = reader["BestFriendId"] != null
                                ? new Friend
                                    {
                                        Id = (int)reader["BestFriendId"],
                                        Name = (string)reader["BestFriendName"],
                                    }
                                : null
                            };
                            result.Add(e);
                        }
                    }
                }
            }

            foreach (var f in result)
                f.BestFriend = result.FirstOrDefault(x => x.Id == f.BestFriend.Id);

            return result;
        }
    }

    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Friend BestFriend { get; set; }
    }
}

namespace P16_Databases_02_Readers_Solution2
{
    public static class Application
    {
        public static List<Friend> ReadFriends()
        {
            var entities = new List<FriendEntity>();

            using (var conn = new SqlConnection(@"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        " SELECT Id, Name, BestFriendId FROM Friends";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var e = new FriendEntity
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                BestFriendId = reader["BestFriendId"] == DBNull.Value
                                    ? null
                                    : (int?)reader["BestFriendId"]
                            };
                            entities.Add(e);
                        }
                    }
                }
            }

            var result = entities
                .Select(e => new Friend
                    {
                        Id = e.Id,
                        Name = e.Name
                    })
                .ToList();

            foreach (var f in result)
            {
                var entity = entities.First(e => e.Id == f.Id);

                if (entity.BestFriendId != null)
                    f.BestFriend = result.First(x => x.Id == entity.BestFriendId);
            }

            return result;
        }
    }

    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Friend BestFriend { get; set; }
    }

    public class FriendEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BestFriendId { get; set; }
    }
}

namespace P16_Databases_02_Readers_Solution3
{
    public static class Application
    {
        public static List<Friend> ReadFriends()
        {
            var result = new List<Friend>();

            using (var conn = new SqlConnection(@"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        " SELECT Id, Name, BestFriendId FROM Friends";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var e = new Friend
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                BestFriendId = reader["BestFriendId"] == DBNull.Value
                                    ? 0
                                    : (int)reader["BestFriendId"]
                            };
                            result.Add(e);
                        }
                    }
                }
            }

            foreach (var f in result)
                if (f.BestFriendId != 0)
                    f.BestFriend = result.First(x => x.Id == f.BestFriendId);

            return result;
        }
    }

    public class Friend
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Friend BestFriend { get; set; }
        public int BestFriendId { get; set; }
    }
}
