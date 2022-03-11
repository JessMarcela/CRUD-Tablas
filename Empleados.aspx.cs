using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Empleados : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Consultar por Nit
            try
            {
          
                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();                // Obtiene la conexión con la base
                }

                int id = int.Parse(txtNit.Text);
                cargardatos(id);                                // Carga los empleados de esa empresa a la tabla
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El Nit no es válido!');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Método Consultar
            try
            {

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();                // Obtiene la conexión con la base
                }

                SqlCommand comando = new SqlCommand("SELECT * from Empleados where Identificacion = @Identificacion", ConexionBD.GetConexion());

                int ide = int.Parse(txtIdentificacion.Text);

                comando.Parameters.AddWithValue("@Identificacion", ide);        // Parámetro Nit

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)             // Si el objeto Reader contiene columnas
                {
                    while (reader.Read())                               // Obtiene los datos en orden como está en la tabla
                    {
                        txtNombre.Text = reader["Nombre"].ToString();      // Agrega el dato a el txt
                        txtApellido.Text = reader["Apellido"].ToString();
                        txtEdad.Text = reader["Edad"].ToString();
                        txtEmpresa.Text = reader["Empresa"].ToString();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La identificación no existe!');", true);
                    txtNombre.Text = "";                    // Se deja en blanco todos los campos
                    txtApellido.Text = "";                  // por si se desea otros datos
                    txtEdad.Text = "";
                    txtEmpresa.Text = "";
                }
               

                ConexionBD.CerrarConexion();

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La identificación no es válida!');", true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Método eliminar
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;         // Consulta tipo texto

                int id = int.Parse(txtIdentificacion.Text);

                comando.CommandText = "DELETE FROM Empleados WHERE Identificacion = " + id + "";

                comando.Connection = ConexionBD.GetConexion();      // Se realiza la conexión

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();
                }

                comando.ExecuteNonQuery();                  // Ejecuta la consulta
                ConexionBD.CerrarConexion();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El empleado ha sido eliminado!');", true);

                txtNit.Text = "";                       // Coloca el nit en blanco para evitar confusiobnes
                ConexionBD.retornarEstado = true;
               
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El empleado con esa identificación no existe!');", true);
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Método Actualizar

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;         // Consulta tipo texto

                int id = int.Parse(txtIdentificacion.Text);
                int edad = int.Parse(txtEdad.Text);
                int empresa = int.Parse(txtEmpresa.Text);

                comando.Connection = ConexionBD.GetConexion();      // Obtener conexión con la base

                comando.CommandText = "UPDATE Empleados SET Nombre = '" + txtNombre.Text + "', " +
                                     " Apellido = '" + txtApellido.Text + "', " +
                                     " Edad = " + edad + ", Empresa = " + empresa + " WHERE Identificacion = " + id;

                txtNit.Text = comando.CommandText;
                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();
                }


                if (comando.ExecuteNonQuery() == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El empleado con esa identificación no existe!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El empleado ha sido actualizado!');", true);
                }

                ConexionBD.CerrarConexion();
                 cargardatos(empresa);                          // Muestra en la tabla el dato actualizado segun su empresa
                ConexionBD.retornarEstado = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡Los espacios no deben estar en blanco!');", true);
            }
        } 
      

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Método Agregar
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;     // Nuevo Comando de texto

                int id = int.Parse(txtIdentificacion.Text);
                int edad = int.Parse(txtEdad.Text);
                int empresa = int.Parse(txtEmpresa.Text);


                comando.CommandText = "INSERT Empleados values(" + id + ", '"
                                         + txtNombre.Text + "' , '" + txtApellido.Text + "', " 
                                        + edad + ", "+empresa+")";

                comando.Connection = ConexionBD.GetConexion();      // Se obtiene conexión

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();
                }

                comando.ExecuteNonQuery();              // Se ejecuta la consulta
                ConexionBD.CerrarConexion();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El empleado ha sido registrado!');", true);

                txtIdentificacion.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtEdad.Text = "";
                txtEmpresa.Text = "";

                ConexionBD.retornarEstado = true;   // No generar conflictos con la próxima conexión
                cargardatos(empresa);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡Alguno de los datos no es válido o está en blanco!');", true);
            }
        }

        public void cargardatos(int id)
        {
            txtNit.Text = ""+id;                                    // Se escribe la nit para saber a que empresa pertenece
            String seleccion = "SELECT * FROM Empleados WHERE Empresa = " + id;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable tabladedatos = new DataTable();               //Objeto el cual nos permite adaptarnos a una tabla
            try
            {
                adaptador = new SqlDataAdapter(seleccion, ConexionBD.GetConexion());    // Conexión con la base
                adaptador.Fill(tabladedatos);                   // Llena los datos de la tabla
                datos.DataSource = tabladedatos;
                datos.DataBind();                           // Muestra los datos
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Mensaje de error: " + ex.Message);
            }
        }
    }
}