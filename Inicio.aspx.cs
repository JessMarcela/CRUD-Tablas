using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Pruebamaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.Text;

                    comando.Connection = ConexionBD.GetConexion();

                    if (ConexionBD.retornarEstado != false)
                    {
                        ConexionBD.GetConexion().Open();
                    }

                  
                    ConexionBD.CerrarConexion();
                    ConexionBD.retornarEstado = true;

                }
                catch (Exception)
                {
                  
                }
            }
           
        }
    }
}