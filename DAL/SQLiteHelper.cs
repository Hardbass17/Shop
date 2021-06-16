using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    class SQLiteHelper
    {
        internal static List<User> GetUsers()
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=Shop.sqlite"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT id, login, passwrd, sotrudniki.name_sotr, root FROM Users, Sotrudniki WHERE sotrudniki.id = users.id_sotr";
                    ExecuteReader();
                    using (var cmd = new SQLiteCommand("SELECT id, login, passwrd, sotrudniki.name_sotr, root FROM Users, Sotrudniki WHERE sotrudniki.id = users.id_sotr", connection))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            List<User> users = new List<User>();

                            while (rdr.Read())
                            {
                                users.Add(new User
                                {
                                    Id = rdr.GetInt32(0),
                                    Login = rdr.GetString(1),
                                    Passwrd = rdr.GetString(2),
                                    Name_sotr = rdr.GetString(3),
                                    Root = rdr.GetString(4),
                                });
                            }

                            return users;
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return null;
        }

//        internal static bool AddUser(User user)
//        {
//            try
//            {
//                using (var connection = new SQLiteConnection(@"Data Source=Shop.sqlite;Version=3;"))
//                {
//                    connection.Open();

//                    using (var cmd = new SQLiteCommand($@"INSERT INTO users (
//                      user_name,
//                      name,
//                      date_created
//                  )
//                  VALUES (
//                      '{user.UserName}',
//                      '{user.Name}',
//                      '{user.Date:yyyy-MM-dd}');", connection))
//                    {
//                        var res = cmd.ExecuteNonQuery();
//                        return true;
//                    }
//                }
//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            return false;
//        }

//        internal static bool SaveUser(User user)
//        {
//            try
//            {
//                using (var connection = new SQLiteConnection(@"Data Source=Shop.sqlite;Version=3;"))
//                {
//                    connection.Open();

//                    using (var cmd = new SQLiteCommand($@"UPDATE users  
//SET
//user_name = '{user.UserName}',
//name = '{user.Name}',
//date_created = '{user.Date:yyyy-MM-dd}'
//WHERE id = {user.Id};", connection))
//                    {
//                        var res = cmd.ExecuteNonQuery();
//                        return true;
//                    }
//                }
//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            return false;
//        }

//        internal static bool DeleteUser(int id)
//        {
//            try
//            {
//                using (var connection = new SQLiteConnection(@"Data Source=Shop.sqlite;Version=3;"))
//                {
//                    connection.Open();

//                    using (var cmd = new SQLiteCommand($@"DELETE FROM users WHERE id = {id};", connection))
//                    {
//                        var res = cmd.ExecuteNonQuery();
//                        return true;
//                    }
//                }
//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            return false;
//        }
    }
}
