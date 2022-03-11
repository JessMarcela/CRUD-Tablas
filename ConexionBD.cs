using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ConexionBD
    {
        private static SqlConnection ObjConexion;
        private static string Error;
        private static Boolean prueba = false;
        public static SqlConnection GetConexion()
        {
            if (ObjConexion != null)
                return ObjConexion;
            ObjConexion = new SqlConnection();
            ObjConexion.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Usuario\\Desktop\\EmpresasEmpleados\\BaseEmpresas.mdf;Integrated Security=True;Connect Timeout=30";
            
               try
            {
                ObjConexion.Open();
                return ObjConexion;
            }
            catch (Exception e)
            {
                Error = e.Message;
                return null;
            }
        }
        public static void CerrarConexion()
        {
            if (ObjConexion != null)
                ObjConexion.Close();
        }

        public static bool retornarEstado
        {

            get
            {
                return prueba;
            }
            set
            {
                prueba = value;
            }


        }
    }
           
}