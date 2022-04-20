using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DCU_Final.Maestros
{
    class Estudiantes
    {
        BaseDeDatos conexion = new BaseDeDatos();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        DataTable tabla2 = new DataTable();

        //METODO PARA MOSTRAR LOS ESTUDIANTES, EJECUTANDO EL STORE PROCEDURES EN LA BASE DE DATOS
        public DataTable Mostrar_estudiantes()
        {
            comando.Connection = conexion.Abrir_Cn();
            comando.CommandText = "MostrarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.Cerrar_Cn();
            return tabla;
        }


        //METODO PARA INSERTAR LOS ESTUDIANTES, EJECUTANDO EL STORE PROCEDURES EN LA BASE DE DATOS
        public void Insertar_estudiante(string nombre, string apellido, int edad, string correo, string numero_telefono, string direccion)
        {
            comando.Connection = conexion.Abrir_Cn();
            comando.CommandText = "InsertarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@numero_telefono", numero_telefono);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


        //METODO PARA ELIMINAR LOS ESTUDIANTES, EJECUTANDO EL STORE PROCEDURES EN LA BASE DE DATOS
        public void Eliminar_estudiantes(int id)
        {
            comando.Connection = conexion.Abrir_Cn();
            comando.CommandText = "EliminarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();                   
        }


        //METODO PARA ACTUALIZAR LOS ESTUDIANTES, EJECUTANDO EL STORE PROCEDURES EN LA BASE DE DATOS
        public void Update_estudiante(int id, string nombre, string apellido, int edad, string correo, string numero_telefono, string direccion)
        {
            comando.Connection = conexion.Abrir_Cn();
            comando.CommandText = "ActualizarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@numero_telefono", numero_telefono);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


        //METODO PARA BUSCAR LOS ESTUDIANTES POR ID, EJECUTANDO EL STORE PROCEDURE EN LA BASE DE DATOS
        public DataTable Buscar_Estudiante(string id)
        {
            comando.Connection = conexion.Abrir_Cn();
            comando.CommandText = "BuscarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id",id);
            leer = comando.ExecuteReader();
            tabla2.Load(leer);
            return tabla2;
        }

        //METODO PARA TRUNCAR LA TABLA ESTUDIANTE, EJECUTANDO EL STORE PROCEDURES EN LA BASE DE DATOS
        public void Truncate_table()
        {
            comando.Connection = conexion.Abrir_Cn();
            comando.CommandText = "TruncateTable";
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
