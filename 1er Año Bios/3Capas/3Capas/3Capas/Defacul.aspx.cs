using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using CapaLogica;
using System.Data.SqlClient;

namespace _3Capas
{
    public partial class Defacul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bListar_Click(object sender, EventArgs e)
        {
            List<Alumno> Lista = LogicaAlumno.ListarTodos();

            foreach(Alumno item in Lista)
            {
                lstListar.Items.Add(item.CiAlumno + " - " + item.Nombre);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Materias> Lista = LogicaMaterias.ListarMaterias();

            foreach (Materias item in Lista)
            {
                lstMaterias.Items.Add("La carga horaria es: " + item.CargaHoraria + " La id es: " + item.IdMateria + " El nombre es: " + item.Nombre);
            }
        }

        protected void lnkBAgregarMateria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMateria.aspx");
        }

        protected void LnkbAgregarAlumno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAlumno.aspx");
        }
    }
  }
