using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DCU_Final.Maestros;


namespace DCU_Final.Controlador
{
    class MEstudianteF
    {
        //INSTANCIA DE LA CLASE ESTUDIANTE, LA CUAL CONTIENE LOS METODOS PARA MANIPULAR LOS DATOS EN LA DB
        Estudiantes estudiante = new Estudiantes();


        //METODO PARA MOSTRAR LOS ESTUDIANTES EN EL FORM (DATAGRIDVIEW)
        public DataTable MEstudiante()
        {
            DataTable tabla = new DataTable();
            tabla = estudiante.Mostrar_estudiantes();
            return tabla;
        }


        //METODO PARA RECIBIR LOS DATOS DEL ESTIANTE QUE SE QUIERE AGREGAR Y LUEGO PASARLOS AL METODO QUE CONECTA LOS DATOS CON LA BASE DE DATOS
        public void I_Estudiante(string nombre, string apellido, string edad, string correo, string numero_telefono, string direccion)
        {
            estudiante.Insertar_estudiante(nombre, apellido, Convert.ToInt32(edad), correo, numero_telefono, direccion);
        }


        //METODO PARA RECIBIR EL ID DEL ESTUDIANTE QUE SE QUIERE ELIMINAR Y LUEGO PASARLOS AL METODO QUE CONECTA CON LA BASE DE DATOS
        public void E_Estudiante(string id)
        {
            estudiante.Eliminar_estudiantes(Convert.ToInt32(id));
        }


        //METODO PARA RECIBIR LOS DATOS DEL ESTUDIANTE QUE SE QUIERE MODIFICAR Y LUEGO PASARLOS AL METODO QUE CONECTA CON LA BASE DE DATOS
        public void A_Estudiante(string id, string nombre, string apellido, string edad, string correo, string numero_telefono, string direccion)        
        {
            estudiante.Update_estudiante(Convert.ToInt32(id), nombre, apellido, Convert.ToInt32(edad), correo, numero_telefono, direccion);
        }

    }
}
