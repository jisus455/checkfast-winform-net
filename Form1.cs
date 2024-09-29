using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using tp1.Handlers;

namespace tp1
{
    public partial class Form1 : Form
    {

        public static class ClaseCompartida
        {
            // variables estáticas
            public static string Globalid;
        }

        public List<int> listIdTodos = new List<int>();
        public string filaId1;
        public int filaId;
        public int idCapturado;
        public bool noRepetido;
        public int filaEvent;
        public int totalSeleccion;
        // variables para calcular y setear la progress bar
        int totalEstado = 0;
        int confirmado = 0;
        // variable para cambiar el modo
        public bool modoEditar = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAutores();
            lblSelect.Text = "0 seleccionados";
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            // actualiza los registros cuando recupera el foco
            GetAutores();
            lblTotal.Text = grdDatos.RowCount.ToString() + " registros";
            actualizarProgressBar();
        }

        public void actualizarProgressBar()
        {
            totalEstado = 0;
            confirmado = 0;
            List<string> estados = new List<string>();

            estados = SqliteHandlers.readEstados();
            for (int i = 0; i < estados.Count; i++)
            {
                totalEstado++;
                if (estados[i].Equals("Confirmado"))
                {
                    confirmado++;
                }
            }

            // evitar la division por cero
            if (!(totalEstado == 0))
            {
                int valor = (confirmado * 100) / totalEstado;
                progressBar.Value = valor;
            }
            else
            {
                progressBar.Value = 0;
            }
            
        }
        public void GetAutores()
        {
            grdDatos.DataSource = SqliteHandlers.GetDataTable("select * from Autores");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = grdDatos.Rows[e.RowIndex];


            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // este es la columna seleccionar
            {
                ClaseCompartida.Globalid = row.Cells["Id"].Value.ToString();

                // guarda donde se hizo click en la tabla
                filaEvent = e.RowIndex;

                // guarda el id donde se hizo click en la tabla
                filaId1 = row.Cells["Id"].Value.ToString();

                // convierte a int el id
                filaId = Convert.ToInt32(filaId1);
                idCapturado = filaId;

                // bucle para borrar los no selec de la tabla
                noRepetido = true;

                for (int i = 0; i < listIdTodos.Count; i++)
                {
                    if (idCapturado == listIdTodos[i])
                    {
                        listIdTodos.Remove(idCapturado);
                        noRepetido = false;
                    }
                }

                if (noRepetido)
                {
                    listIdTodos.Add(filaId);
                }

                lblSelect.Text = Convert.ToString(listIdTodos.Count) + " seleccionados";
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // lanzar form3
            Form3 miPantalla3 = new Form3();
            miPantalla3.ShowDialog();
        }

        private void btnModo_Click(object sender, EventArgs e)
        {

            if (modoEditar)
            {
                btnModo.Text = "Modo Editar";
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnIniciar.Visible = true;
                modoEditar = false;
            }

            else if (!modoEditar)
            {
                btnModo.Text = "Modo Cargar";
                btnAgregar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnIniciar.Visible = false;
                modoEditar = true;
            }


        }

        public void btnAgregar_Click(object sender, EventArgs e)
        {
            // lanzar form2
            Form2 miPantalla2 = new Form2();
            miPantalla2.actualizar = false;
            miPantalla2.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            totalSeleccion = grdDatos.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells["Column1"].Value)).Count();

            if (totalSeleccion == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form2 miPantalla2 = new Form2();
            AddOwnedForm(miPantalla2);

            // cargamos los datos de la fila en los textbox antes de lanzar el form2
            miPantalla2.lblTituloForm2.Text = "EDITAR REGISTRO";

            miPantalla2.lblID.Text = Convert.ToString(idCapturado);

            miPantalla2.txtDNI.Text = this.grdDatos.Rows[filaEvent].Cells[2].Value.ToString();
            miPantalla2.txtNombre.Text = this.grdDatos.Rows[filaEvent].Cells[3].Value.ToString();
            miPantalla2.txtApellido.Text = this.grdDatos.Rows[filaEvent].Cells[4].Value.ToString();
            miPantalla2.cmbGenero.Text = this.grdDatos.Rows[filaEvent].Cells[5].Value.ToString();
            miPantalla2.cmbOcupacionForm2.Text = this.grdDatos.Rows[filaEvent].Cells[6].Value.ToString();
            miPantalla2.cmbRolForm2.Text = this.grdDatos.Rows[filaEvent].Cells[7].Value.ToString();
            miPantalla2.lblCodigo.Text = this.grdDatos.Rows[filaEvent].Cells[8].Value.ToString();
            miPantalla2.lblEstado.Text = this.grdDatos.Rows[filaEvent].Cells[9].Value.ToString();


            miPantalla2.actualizar = true;
            miPantalla2.ShowDialog();

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // creamos una nueva lista eliminando los repetidos
            List<int> listId = listIdTodos.Distinct().ToList();

            totalSeleccion = grdDatos.Rows.Cast<DataGridViewRow>().
                Where(p => Convert.ToBoolean(p.Cells["Column1"].Value)).Count();

            DialogResult dg;
            int Id;

            if (totalSeleccion == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (totalSeleccion == 1)
            {

                dg = MessageBox.Show("Desea eliminar el registro seleccionado?", "Atencion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dg == DialogResult.OK)
                {
                    for (int i = 0; i < listId.Count; i++)
                    {
                        Id = listId.ElementAt(i);
                        EliminarPer(Id);
                        listIdTodos.Remove(Id);
                    }
                }
            }

            else if (totalSeleccion >= 2)
            {

                dg = MessageBox.Show("Desea eliminar los " + totalSeleccion + " registros seleccionados?", "Atencion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dg == DialogResult.OK)
                {
                    for (int i = 0; i < listId.Count; i++)
                    {
                        Id = listId.ElementAt(i);
                        EliminarPer(Id);
                        listIdTodos.Remove(Id);
                    }
                }


            }

        }
        private void EliminarPer(int pId)
        {
            try
            {
                // comando para borrar los registros
                string delete = "delete from autores where Id = " + pId;
                bool result = SqliteHandlers.Exec(delete);
                if (result)
                {
                    MessageBox.Show("Registro " + pId + " eliminado correctamente", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAutores();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
