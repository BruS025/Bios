using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Xml;
using System.Xml.Linq;


public partial class BusquedaLibros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    // Buscar
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            // Limpio el resultado anterior
            GvResultado.DataSource = null;
            GvResultado.DataBind();

            // Origen de datos
            XElement _doc = XElement.Load(Server.MapPath("~/XML/Libros.xml"));

            // LINQ busqueda - ISBN
            if (DdlTipo.SelectedIndex == 0)
            {
                var _resultado = (from unNodo in _doc.Elements("Libro") // NOdos primarios llamadaos Libro
                                  where (int)unNodo.Element("ISBN") == Convert.ToInt32(txtDato.Text)
                                  select new
                                  {
                                      Titulo = unNodo.Element("Titulo").Value,
                                      Categoria = unNodo.Attribute("Categoria").Value

                                  }).ToList();

                GvResultado.DataSource = _resultado;
                GvResultado.DataBind();
            }

            // BUsqueda por titulo 
            if (DdlTipo.SelectedIndex == 1)
            {
                var _resultado = (from unNodo in _doc.Elements("Libro")
                                  where (string)unNodo.Element("Titulo") == txtDato.Text.Trim()
                                  select new
                                  {
                                      ISBN = unNodo.Element("ISBN").Value,
                                      Titulo = unNodo.Element("Titulo").Value,
                                      Categoria = unNodo.Attribute("Categoria").Value

                                  }).ToList();

                GvResultado.DataSource = _resultado;
                GvResultado.DataBind();
            }

            // BUsuqeda por categria
            if (DdlTipo.SelectedIndex == 2)
            {
                var _resultado = (from unNodo in _doc.Elements("Libro")
                                  where (string)unNodo.Element("Titulo") == txtDato.Text.Trim()
                                  select new
                                  {
                                      ISBN = unNodo.Element("ISBN").Value,
                                      Titulo = unNodo.Element("Titulo").Value,
                                      Categoria = unNodo.Attribute("Categoria").Value

                                  }).ToList();

                GvResultado.DataSource = _resultado;
                GvResultado.DataBind();
            }

        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    
    }
}