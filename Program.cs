using System;
using System.IO;
using System.Windows.Forms;
using tp1.Handlers;

namespace tp1
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appPath = Application.StartupPath;

            string databasePath = appPath + @"\autores.db";

            SqliteHandlers.ConnString = "Data Source=" + databasePath;

            if (!File.Exists(databasePath))
            {
                string query = "create table autores( Id integer primary key autoincrement, DNI text, Nombre text, Apellido text, Genero text, Ocupacion text, Rol text, Codigo text, Estado text );";
                bool resultado = SqliteHandlers.CreateDatabase(databasePath, query);

                if (resultado)
                {
                    MessageBox.Show("Base creada correctamente");
                }
                else
                {
                    MessageBox.Show("ocurrio un problema");
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
