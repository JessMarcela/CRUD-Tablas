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
    public partial class Empresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Método Consultar
            try
            {
                
                SqlCommand comando = new SqlCommand("SELECT * from Empresa where Nit = @Nit", ConexionBD.GetConexion());
               

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();                // Obtiene la conexión con la base
                }

                int id = int.Parse(txtNit.Text);

                comando.Parameters.AddWithValue("@Nit", id);        // Parámetro Nit


                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())                               // Obtiene los datos en orden como está en la tabla
                    {
                        txtNombre.Text = reader["Nombre"].ToString();      // Agrega el dato a el txt
                        txtCiudad.Text = reader["Ciudad"].ToString();
                    }
                }
                else
                {
                    txtNombre.Text = "";
                    txtCiudad.Text = "";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El Nit no existe!');", true);
                }
            
                ConexionBD.CerrarConexion();
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡El Nit no es válido!');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Método eliminar
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;         // Consulta tipo texto

                int id = int.Parse(txtNit.Text);

                comando.CommandText = "DELETE FROM Empresa WHERE Nit = " + id + "";

                comando.Connection = ConexionBD.GetConexion();      // Se realiza la conexión

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();
                }

                comando.ExecuteNonQuery();
                ConexionBD.CerrarConexion();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La empresa ha sido eliminada!');", true);

                txtNit.Text = "";
                ConexionBD.retornarEstado = true;
                cargardatos();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La empresa con ese Nit no existe o contiene empleados!');", true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Método Actualizar

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;         // Consulta tipo texto

                int id = int.Parse(txtNit.Text);
              
                comando.Connection = ConexionBD.GetConexion();      // Obtener conexión con la base

                comando.CommandText = "UPDATE Empresa SET Nombre = '" + txtNombre.Text + "', " +
                                     " Ciudad = '"+txtCiudad.Text+"' WHERE Nit = " + id;
              

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();
                }


                if (comando.ExecuteNonQuery() == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La empresa con esa Nit no existe!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La empresa ha sido actualizada!');", true);
                }

                ConexionBD.CerrarConexion();
                cargardatos();
                ConexionBD.retornarEstado = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La empresa con esa identificación no existe!');", true);
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Método Agregar
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;     // Nuevo Comando de texto

                int id = int.Parse(txtNit.Text);

                comando.CommandText = "INSERT Empresa values(" + id + ", '"
                                         + txtNombre.Text + "' , '" + txtCiudad.Text + "')";

                comando.Connection = ConexionBD.GetConexion();      // Se obtiene conexión

                if (ConexionBD.retornarEstado != false)
                {
                    ConexionBD.GetConexion().Open();
                }

                comando.ExecuteNonQuery();              // Se ejecuta la consulta
                ConexionBD.CerrarConexion();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡La empresa ha sido registrada!');", true);

                txtNit.Text = "";
                txtCiudad.Text = "";
                txtNombre.Text = "";

                ConexionBD.retornarEstado = true;   // No generar conflictos con la próxima conexión
                cargardatos();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('¡Alguno de los datos no es válido!');", true);
            }
        }
        public void cargardatos()
        {
            String seleccion = "SELECT * FROM Empresa";
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable tabladedatos = new DataTable();
            try
            {
                adaptador = new SqlDataAdapter(seleccion, ConexionBD.GetConexion());
                adaptador.Fill(tabladedatos);
                datos.DataSource = tabladedatos;
                datos.DataBind();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Mensaje de error: " + ex.Message);
            }
        }

    }
}