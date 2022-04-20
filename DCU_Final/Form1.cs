using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCU_Final.Controlador;
using DCU_Final.Maestros;

namespace DCU_Final
{
    public partial class Form1 : Form
    {
        //INSTANCIA DE LA CLASE MESTUDIANTEF, LA CUAL CONTIENE LOS METODOS PARA PASAR LOS DATOS A LOS METODOS DE LA BASE DE DATOS  
        MEstudianteF Est = new MEstudianteF();
        private string id = null;
        private bool editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        //CARGA DEL FORM
        private void Form1_Load(object sender, EventArgs e)
        {
            MEstudianteFD();
        }


        //METODO PARA MOSTRAR LA TABLA CON LOS REGISTROS EN EL DATAGRIDVIEW
        public void MEstudianteFD()
        {
            MEstudianteF refresh = new MEstudianteF();
            dtgestudiante.DataSource = refresh.MEstudiante();
        }


        //METODO PARA LIMPIAR LOS CAMPOS DE TEXTO
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
        }


        //METODO PARA RELLENAR LOS TEXT BOXS CON LOS DATOS DE LA TABLA Y LUEGO MODIFICARLOS
        private void button2_Click(object sender, EventArgs e)
        {
            editar = true;
            if (dtgestudiante.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea modificar este registro?", "Modificar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    id = dtgestudiante.CurrentRow.Cells["id"].Value.ToString();
                    txtNombre.Text = dtgestudiante.CurrentRow.Cells["nombre"].Value.ToString();
                    txtApellido.Text = dtgestudiante.CurrentRow.Cells["apellido"].Value.ToString();
                    txtEdad.Text = dtgestudiante.CurrentRow.Cells["edad"].Value.ToString();
                    txtCorreo.Text = dtgestudiante.CurrentRow.Cells["correo"].Value.ToString();
                    txtTelefono.Text = dtgestudiante.CurrentRow.Cells["telefono"].Value.ToString();
                    txtDireccion.Text = dtgestudiante.CurrentRow.Cells["direccion"].Value.ToString();
                    tabControl1.SelectedIndex = 0;
                    btnGuardar.Text = "Modificar";
                }
                else
                {
                    //NO SUCEDE NADA EN EL CONTROL
                }
            }
            else
            {
                    MessageBox.Show("Seleccione la fila que desea modificar","Error!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


        //METODO QUE DEPENDIENDO DE LA CONDICION AGREGA Y/O MODIFICA LOS DATOS DE LOS ESTUDIANTES
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    Est.I_Estudiante(txtNombre.Text, txtApellido.Text, txtEdad.Text, txtCorreo.Text, txtTelefono.Text, txtDireccion.Text);
                    MessageBox.Show("El estudiante se insertó correctamente","Éxito!",MessageBoxButtons.OK,MessageBoxIcon.None);
                    MEstudianteFD();
                    Limpiar();
                    tabControl1.SelectedIndex = 1;
                    btnGuardar.Text = "Guardar";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            else
            {
                try
                {
                    if (MessageBox.Show("¿Desea modificar este registro?","Modificar!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Est.A_Estudiante(id, txtNombre.Text, txtApellido.Text, txtEdad.Text, txtCorreo.Text, txtTelefono.Text, txtDireccion.Text);
                        MessageBox.Show("Los datos de este estudiante se modificaron correctamente", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        editar = false;
                        tabControl1.SelectedIndex = 1;
                        MEstudianteFD();
                        Limpiar();
                        btnGuardar.Text = "Guardar";
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }


        //METODO QUE ELIMINA LOS DATOS DEL ESTUDIANTE SELECCIONADO EN LA TABLA
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea elminiar este registro?", "Eliminar!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dtgestudiante.SelectedRows.Count > 0)
                {
                    id = dtgestudiante.CurrentRow.Cells["id"].Value.ToString();
                    Est.E_Estudiante(id);
                    MessageBox.Show("Los datos de este estudiante se eliminaron correctamente", "Exito!",MessageBoxButtons.OK,MessageBoxIcon.None);
                    MEstudianteFD();
                }
                else
                {
                    MessageBox.Show("Seleccione la fila que desea eliminar", "Error!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }


        //METODO PARA BUSCAR LOS ESTUDIANTES MEDIANTE SU ID
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                string var = txtBuscar.Text;
                Estudiantes est = new Estudiantes();
                dtgestudiante.DataSource = est.Buscar_Estudiante(var);
            }
            else
                MessageBox.Show("Ingrese el ID del registro que desea buscar","Error!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }


        //METODO PARA ELIMINAR LOS ESTUDIANTES SELECCIONADOS EN LA TABLA
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar todos los registros?", "Eliminar todo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Estudiantes estu = new Estudiantes();
                estu.Truncate_table();
                MEstudianteFD();
                MessageBox.Show("Registros eliminados correctamente", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }


        //VALIDACION NECESARIA PARA QUE EL CAMPO DE TEXTO EDAD SOLO RECIVA VALORES NUMERICOS
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >=32 && e.KeyChar <= 47 ||  e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                MessageBox.Show("Solo se pueden ingresar valores numericos en este campo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //VALIDACION NECESARIA PARA QUE EL CAMPO DE TEXTO NOMBRE SOLO RECIVA VALORES LITERALES
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96)
            {
                e.Handled = true;
                MessageBox.Show("Solo se pueden ingresar valores literarios en este campo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //VALIDACION NECESARIA PARA QUE EL CAMPO DE TEXTO APELLIDO SOLO RECIVA VALORES LITERALES
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96)
            {
                e.Handled = true;
                MessageBox.Show("Solo se pueden ingresar valores literarios en este campo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //VALIDACION NECESARIA PARA QUE EL CAMPO DE TEXTO TELEFONO SOLO RECIVA VALORES NUMERICOS
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 44 || e.KeyChar == 46 || e.KeyChar == 47 || e.KeyChar == 48 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                MessageBox.Show("Solo se pueden ingresar valores numericos en este campo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //VALIDACION NECESARIA PARA QUE EL CAMPO DE TEXTO BUSCAR SOLO RECIVA VALORES NUMERICOS
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;
                MessageBox.Show("Solo se pueden ingresar valores numericos en este campo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        /*METODO QUE SE ENCARGA DE RETORNAR LOS REGISTROS DE LOS ESTUDIANTES AL DATAGRIDVIEW DESPUES DE REALIZAR UNA BUSQUEDA 
          Y QUE EL CAMPO DE TEXTO DE BUSQUEDA ESTE VACIO
         */
        private void TablaNoBug()
        {
            if (txtBuscar.Text == "")
            {
                MEstudianteFD();
            }
            //var vr = !string.IsNullOrEmpty(txtBuscar.Text);
            
        }


        //EVENTO QUE VALIDA EL RETORNO DE LOS DATOS DE LOS ESTUDIANNTES CUANDO EL CAMPO DE TEXTO BUSCAR ESTA VACIO
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            TablaNoBug();
        }

        private void dtgestudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
