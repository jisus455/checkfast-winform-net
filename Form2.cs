using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp1.Handlers;
using static tp1.Form1;

namespace tp1
{
    public partial class Form2 : Form
    {

        public bool actualizar;

        public string globalIdForm1()
        {
            return ClaseCompartida.Globalid.ToString();
        }

        public string Globalid = "";

        public string query = string.Empty;
        public string mensaje = string.Empty;


        public Form2()
        {
            InitializeComponent();
            // agrego los items al combobox genero de form2
            cmbGenero.Items.Insert(0, "Hombre");
            cmbGenero.Items.Insert(1, "Mujer");
            cmbGenero.Items.Insert(2, "Prefiero no decirlo");
            // agrego los items
            cmbOcupacionForm2.Items.Insert(0, "Educacion");
            cmbOcupacionForm2.Items.Insert(1, "Empresa");
            cmbOcupacionForm2.Items.Insert(2, "Evento");
        }

        private void btnAceptarForm2_Click(object sender, EventArgs e)
        {
                        
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || cmbGenero.Text == "" || cmbOcupacionForm2.Text == "" || cmbRolForm2.Text == "") 
            {
                MessageBox.Show("Es obligatorio completar todos los datos", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!actualizar)
            {
                // genero un numero random de 4 digitos
                Random rnd = new Random();
                lblCodigo.Text = Convert.ToString(rnd.Next(1, 10000 + 1));
  
                lblEstado.Text = "Agregado";
                // inserto nuevo registro
                query = $"insert into autores values (null,'{txtDNI.Text}','{txtNombre.Text}','{txtApellido.Text}','{cmbGenero.Text}','{cmbOcupacionForm2.Text}','{cmbRolForm2.Text}','{lblCodigo.Text}','{lblEstado.Text}');";
                mensaje = "Registro creado correctamente";    

            } 
            else if (actualizar)
            {
                // hago un update
                Globalid = globalIdForm1();
                query = $"update Autores set DNI = '{txtDNI.Text}' , Nombre = '{txtNombre.Text}' , Apellido = '{txtApellido.Text}' , Genero = '{cmbGenero.Text}' , Ocupacion = '{cmbOcupacionForm2.Text}' , Rol = '{cmbRolForm2.Text}' , Codigo = '{lblCodigo.Text}' , Estado = '{lblEstado.Text}'  where id =" + Globalid;
                mensaje = "Registro actualizado correctamente";
            }

            bool result = SqliteHandlers.Exec(query);
            
            if (result)
            {
                MessageBox.Show(mensaje);
            }

            // cierro la ventana
            this.Hide();

        }
    

        private void btnCancelarForm2_Click(object sender, EventArgs e)
        {
            if (!(txtDNI.Text == "") || !(txtNombre.Text == "") || !(txtApellido.Text == "") || !(cmbGenero.Text == "") || !(cmbOcupacionForm2.Text == "") || !(cmbRolForm2.Text == ""))

            {
                DialogResult dialogResult = MessageBox.Show("Estas seguro de abandonar, los datos se perderan?", "Atencion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                
                if (dialogResult == DialogResult.OK)
                {
                    // cierro la ventana
                    this.Hide();
                }
                else if (dialogResult == DialogResult.Cancel) 
                {
                    // no cierra la ventana
                    return;
                }
            }
            else
            {
                // cierro la ventana
                this.Hide();
            }

        }

        private void cmbGenero_Leave(object sender, EventArgs e)
        {
            // vaciamos el contenido si quiere cambiar de opcion
            cmbOcupacionForm2.Text = "";
            cmbRolForm2.Text = "";
        }

        private void cmbOcupacionForm2_Leave(object sender, EventArgs e)
        {
            // vaciamos el contenido si quiere cambiar de opcion
            cmbRolForm2.Text = "";

            if (cmbGenero.Text.Equals("Hombre") || cmbGenero.Text.Equals("Prefiero no decirlo"))
            {

                if (cmbOcupacionForm2.Text.Equals("Educacion"))
                {
                    // agrego los items
                    cmbRolForm2.Items.Clear();
                    cmbRolForm2.Items.Insert(0, "Director");
                    cmbRolForm2.Items.Insert(1, "Profesor");
                    cmbRolForm2.Items.Insert(2, "Estudiante");
                }
                else if (cmbOcupacionForm2.Text.Equals("Empresa"))
                {
                    cmbRolForm2.Items.Clear();
                    cmbRolForm2.Items.Insert(0, "Presidente");
                    cmbRolForm2.Items.Insert(1, "Supervisor");
                    cmbRolForm2.Items.Insert(2, "Empleado");
                }
                else if (cmbOcupacionForm2.Text.Equals("Evento"))
                {
                    cmbRolForm2.Items.Clear();
                    cmbRolForm2.Items.Insert(0, "Socio");
                    cmbRolForm2.Items.Insert(1, "Invitado");
                }
            }
            else if (cmbGenero.Text.Equals("Mujer"))
            {
                if (cmbOcupacionForm2.Text.Equals("Educacion"))
                {
                    // agrego los items
                    cmbRolForm2.Items.Clear();
                    cmbRolForm2.Items.Insert(0, "Directora");
                    cmbRolForm2.Items.Insert(1, "Profesora");
                    cmbRolForm2.Items.Insert(2, "Estudiante");
                }
                else if (cmbOcupacionForm2.Text.Equals("Empresa"))
                {
                    cmbRolForm2.Items.Clear();
                    cmbRolForm2.Items.Insert(0, "Presidenta");
                    cmbRolForm2.Items.Insert(1, "Supervisora");
                    cmbRolForm2.Items.Insert(2, "Empleada");
                }
                else if (cmbOcupacionForm2.Text.Equals("Evento"))
                {
                    cmbRolForm2.Items.Clear();
                    cmbRolForm2.Items.Insert(0, "Socia");
                    cmbRolForm2.Items.Insert(1, "Invitada");
                }
            }
        }

    }
}
