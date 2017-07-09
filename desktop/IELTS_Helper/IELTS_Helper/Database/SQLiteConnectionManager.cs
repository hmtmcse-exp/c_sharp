using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELTS_Helper.Database
{
    public class SQLiteConnectionManager
    {
        public SQLiteConnection sqLiteConnection;
        public SQLiteCommand sqLiteCommand;
        public static string DB_NAME = "Resources/Database/word_book.db";
        public readonly string DB_CONNECTION = "Data Source=" + DB_NAME + ";Version=3; FailIfMissing=True; Foreign Keys=True;";


        public SQLiteConnectionManager()
        {
            OpenConnection();
        }

        private void OpenConnection()
        {
            sqLiteConnection = new SQLiteConnection(DB_CONNECTION);
            sqLiteConnection.Open();
            sqLiteCommand = sqLiteConnection.CreateCommand();
        }


        private void CloseConnection()
        {
            sqLiteConnection.Close();
        }

        public void test()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(DB_CONNECTION))
                {
                    conn.Open();
                    string sql = "SELECT * FROM word ";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reader["en"].ToString();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
            }
        }
    }
}
