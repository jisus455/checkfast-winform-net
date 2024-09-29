using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace tp1.Handlers
{
    public class SqliteHandlers
    {
        public static string ConnString = string.Empty;

        public static bool CreateDatabase(string path, string query)
        {
            // esta linea crea la base de datos 
            SQLiteConnection.CreateFile(path);
            //esta linea crea u
            return Exec(query);

        }
        public static string GetJson(string query)
        {
            DataTable dt = new DataTable();
            dt = GetDataTable(query);
            String json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return json;
        }
        public static DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(ConnString);
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            command.CommandText = query;
            SQLiteDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            conn.Close();
            return dt;
        }
        public static bool Exec(string query)

        {
            bool result = false;
            //creo la conexion
            SQLiteConnection conn = new SQLiteConnection(ConnString);
            //crea un comando 
            SQLiteCommand commend = new SQLiteCommand(query, conn);
            conn.Open();// abro la conecion
            try
            {
                commend.ExecuteNonQuery();
                result = true;
            }
            catch (System.Exception)
            {
                result = false;
            }

            conn.Close();// cierro la conexion

            return result;
        }


        public static string read(string CommandText)
        {
            string resultado = "";
            try
            {
                SQLiteConnection sql_con = new SQLiteConnection(ConnString);
                sql_con.Open();
 
                SQLiteCommand sql_cmd = new SQLiteCommand(CommandText, sql_con);
                SQLiteDataReader sql_dtr = sql_cmd.ExecuteReader();

                while (sql_dtr.Read())
                {
                    resultado = Convert.ToString(sql_dtr[0]);
                    //string nombreEmpresa = (string)sql_dtr["nombre"];
                }
                sql_dtr.Close();
                sql_con.Close();
            }
            
            catch (Exception argEx)
            {
                MessageBox.Show("Exception message: " + argEx.Message);
                resultado = "error";
                return resultado;
                
            }

            return resultado;
        }

        public static List<string> readEstados()
        {
            List<string> list = new List<string>();
            string CommandText = $"select Estado from Autores";

            try
            {
                SQLiteConnection sql_con = new SQLiteConnection(ConnString);
                sql_con.Open();

                SQLiteCommand sql_cmd = new SQLiteCommand(CommandText, sql_con);
                SQLiteDataReader sql_dtr = sql_cmd.ExecuteReader();

                while (sql_dtr.Read())
                {
                    list.Add(Convert.ToString(sql_dtr[0]));
                    //= sql_dtr[0];
                    //string nombreEmpresa = (string)sql_dtr["nombre"];
                }
                sql_dtr.Close();
                sql_con.Close();
            }

            catch (Exception argEx)
            {
                MessageBox.Show("Exception message: " + argEx.Message);
                //resultado = "error";
                //return resultado;

            }

            return list;
        }


















    }
}
