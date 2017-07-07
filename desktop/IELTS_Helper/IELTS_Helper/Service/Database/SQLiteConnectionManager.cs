using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELTS_Helper.Service.Database
{
    class SQLiteConnectionManager
    {
        public SQLiteConnection sqLiteConnection;
        public SQLiteCommand sqLiteCommand;
        public static string DB_NAME = "Resources/Database/word_note.db";
        public readonly string DB_CONNECTION = "Data Source=" + DB_NAME + ";Version=3;New=False;Compress=True;";
        

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


    }
}
