using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace LibraryManagementSystem
{
    public class MYDB : DbContext
    {
        public MYDB()
            : base("name=MYDB1")
        {
        }

        private MySqlConnection connection = new MySqlConnection(
            "server=localhost;port=3306;username=root;password=;database=library");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public DataTable getData(string query, MySqlParameter[] parameters) 
        {
            MySqlCommand command = new MySqlCommand(query, GetConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public int setData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, GetConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            openConnection();

            int rows = command.ExecuteNonQuery();

            closeConnection();

            return rows;
        }

    }

    //public class MyEntity

}