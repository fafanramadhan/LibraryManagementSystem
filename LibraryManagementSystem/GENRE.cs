using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    class GENRE
    {
        MYDB db = new MYDB();

        public Boolean addGenre(string name) 
        {
            string query = "INSERT INTO `genre`(`name`) VALUES (@genre_name)";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@genre_name", MySqlDbType.VarChar);
            parameters[0].Value = name;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean editGenre(int id,string name)
        {
            string query = "UPDATE `genre` SET `name`=@genre_name WHERE `id`=@id";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@genre_name", MySqlDbType.VarChar);
            parameters[0].Value = name;
            parameters[1] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[1].Value = id;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean removeGenre(int id)
        {

            string query = "DELETE FROM `genre` WHERE `id`=@id";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GenreList()
        {
            DataTable table = new DataTable();
            table = db.getData("SELECT * FROM `genre`", null);
            return table;
        }
    }
}
