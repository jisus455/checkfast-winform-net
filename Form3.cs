using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp1.Handlers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tp1
{
    public partial class Form3 : Form
    {

        public string CommandText = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void btnAceptarForm3_Click(object sender, EventArgs e)
        {
            if (txtDNIForm3.Text == "" || txtCodigoForm3.Text == "")
            {
                MessageBox.Show("Es obligatorio completar todos los datos", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // realizo una query obteniendo el codigo segun el dni
            CommandText = $"select Codigo from Autores where DNI = '{txtDNIForm3.Text}'";
            string codigoObtenido = SqliteHandlers.read(CommandText);

            // realizo una query obteniendo el id segun el dni
            CommandText = $"select Id from Autores where DNI = '{txtDNIForm3.Text}'";
            string idObtenido = SqliteHandlers.read(CommandText);

            // comparo si es igual al codig que ingreso el usuario
            if (txtCodigoForm3.Text.Equals(codigoObtenido))
            {
                // actualizamos el estado del registro
                string query = $"update Autores set Estado = 'Confirmado' where id =" + idObtenido;
                bool result = SqliteHandlers.Exec(query);
                if (result)
                {
                    MessageBox.Show("Validacion completada", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            else
            {
                MessageBox.Show("Los datos ingresados son incorrectos", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            

        }
    }
}
