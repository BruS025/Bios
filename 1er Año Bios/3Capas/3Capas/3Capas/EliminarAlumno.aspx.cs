using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using CapaLogica;

namespace _3Capas
{
    public partial class EliminarAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btBuscarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = LogicaAlumno.MostrarDatos(Convert.ToInt32(txtCiEliminar.Text));
                txtGeneracionEliminar.Text = alumno.Generacion.ToString();
                txtNombreEliminar.Text = alumno.Nombre;
                txtNomCalleEliminar.Text = alumno.NomCalle;
                txtNroPuertaEliminar.Text = alumno.NroPuerta.ToString();

                int devolver = LogicaAlumno.Eliminar(alumno);
                
            }
            catch (Exception)
            {

                throw;
            } 
           
        }
    }
}