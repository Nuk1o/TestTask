using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

namespace Database
{
    public static class MyDataBase
    {
        private const string fileName = "items.bytes";
        private static string DBPath = Path.Combine(Application.dataPath+"/Database/", fileName);
        private static SqliteConnection connection;
        private static SqliteCommand command;
        
        private static void OpenConnection()
        {
            connection = new SqliteConnection("Data Source=" + DBPath);
            Debug.Log(DBPath);
            command = new SqliteCommand(connection);
            connection.Open();
        }
        
        public static void CloseConnection()
        {
            connection.Close();
            command.Dispose();
        }
        
        public static string ExecuteQueryWithAnswer(string query)
        {
            OpenConnection();
            command.CommandText = query;
            var answer = command.ExecuteScalar();
            CloseConnection();

            if (answer != null) return answer.ToString();
            else return null;
        }
        
        public static DataTable GetTable(string query)
        {
            OpenConnection();

            SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);

            DataSet DS = new DataSet();
            adapter.Fill(DS);
            adapter.Dispose();

            CloseConnection();

            return DS.Tables[0];
        }
    }
}