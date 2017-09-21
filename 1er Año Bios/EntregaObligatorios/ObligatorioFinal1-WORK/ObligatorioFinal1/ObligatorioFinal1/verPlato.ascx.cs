using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

namespace ObligatorioFinal1
{
    public partial class verPlato : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Mostrar(Plato plato)
        {
            nombrePlato.Text = plato.Nombre;
            precioPlato.Text = Convert.ToString(plato.Precio);
            fotoMostrar.Src = "/ImagenesPlato/" + plato.Foto;
            fotoMostrar.DataBind();

        }
    }
}