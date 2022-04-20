using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DCU_Final
{
    public class BaseDeDatos
    {
        SqlConnection conexion = new SqlConnection("Server=JIMKEEL\\AJ;DataBase=CRUDDCU;Integrated Security=true");

        public SqlConnection Abrir_Cn()
        {
            if (conexion.State == ConnectionState.Closed)
            
                conexion.Open();
            return conexion;
        }
        
        public SqlConnection Cerrar_Cn()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }

    

}
