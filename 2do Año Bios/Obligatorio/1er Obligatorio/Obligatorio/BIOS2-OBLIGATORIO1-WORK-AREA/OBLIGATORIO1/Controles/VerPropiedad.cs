using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

namespace Controles
{
    public class VerPropiedad: WebControl,INamingContainer
    {
        // CREO PROPIEDADES
        private Propiedad propiedad;

        // DATOS DE PROPIEDAD
        private Label _Padron;
        private Label _Direccion;
        private Label _TipoAccion;
        private Label _Baño;
        private Label _Habitaciones;
        private Label _TamañoPropiedad;
        private Label _Precio;

        // ATT Apartamento
        private CheckBox _Asensor;
        private Label _Piso;

        // ATT Casa
        private Label _TamañoCasa;
        private CheckBox _FondoJardin;

        // ATT Local
        private CheckBox _Habilitacion;

        // DATOS DE ZONA
        private Label _ZonaNombreOficial;
        private Label _ZonaDepartamento;
        private Label _ZonaNombre;
        private Label _ZonaCantidad;
        private ListBox _ZonaServicios;

        // ATT Resultado
        private Label _Resultado;
        // Panel para dibujar resultados en ejecucion
        private Panel _Panel;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            _Panel = new Panel();

            // Creo tabla
            _Panel.Controls.Add(new LiteralControl("<br/><table style='width:100%;border:solid;border-color:white'><tr><td style='width:10%'></td><td style='width:40%'>"));

            // Propiedad
            _Padron = new Label();
            _Direccion = new Label();
            _TipoAccion = new Label();
            _Baño = new Label();
            _Habitaciones = new Label();
            _TamañoPropiedad = new Label();
            _Precio = new Label();
            // Apartamento
            _Asensor = new CheckBox();
            _Piso = new Label();
            // Casa
            _TamañoCasa = new Label();
            _FondoJardin = new CheckBox();
            // Local
            _Habilitacion = new CheckBox();
            // Zona
            _ZonaCantidad = new Label();
            _ZonaNombreOficial = new Label();
            _ZonaDepartamento = new Label();
            _ZonaNombre = new Label();
            _ZonaServicios = new ListBox();
            // Resultado
            _Resultado = new Label();

            // TEXTOS
            _Padron.Text = Convert.ToString(propiedad.Padron);
            _Direccion.Text = propiedad.Direccion;
            _TipoAccion.Text = propiedad.TipoDeAccion;
            _Baño.Text = Convert.ToString(propiedad.Baño);
            _Habitaciones.Text = Convert.ToString(propiedad.Habitaciones);
            _TamañoPropiedad.Text = Convert.ToString(propiedad.MetrosCuadradosP);
            _Precio.Text = Convert.ToString(propiedad.Precio);

            _ZonaDepartamento.Text = propiedad.Zona.Departamento;
            _ZonaNombre.Text = propiedad.Zona.Nombre;
            _ZonaNombreOficial.Text = propiedad.Zona.NombreOficial;
            _ZonaCantidad.Text = Convert.ToString(propiedad.Zona.Habitantes);
            _ZonaServicios.DataSource = propiedad.Zona.Servicios;
            _ZonaServicios.DataBind();

            // AGREGAR AL PANEL
            // Propiedad
            _Panel.Controls.Add(new LiteralControl("<h4>DATOS DE PROPIEDAD</h4>"));
            _Panel.Controls.Add(new LiteralControl("Padron: "));
            _Panel.Controls.Add(_Padron);
            _Panel.Controls.Add(new LiteralControl("<br/>Direccion: "));
            _Panel.Controls.Add(_Direccion);
            _Panel.Controls.Add(new LiteralControl("<br/>Tipo de accion: "));
            _Panel.Controls.Add(_TipoAccion);
            _Panel.Controls.Add(new LiteralControl("<br/>Baño: "));
            _Panel.Controls.Add(_Baño);
            _Panel.Controls.Add(new LiteralControl("<br/>Habitaciones: "));
            _Panel.Controls.Add(_Habitaciones);
            _Panel.Controls.Add(new LiteralControl("<br/>Tamaño de propiedad: "));
            _Panel.Controls.Add(_TamañoPropiedad);

            if (propiedad is Apartamento)
            {
                // Apartamento
                Apartamento apartamento = (Apartamento)propiedad;

                _Asensor.Checked = apartamento.Ascensor;
                _Asensor.Enabled = false;
                _Piso.Text = Convert.ToString(apartamento.Piso);

                _Panel.Controls.Add(new LiteralControl("<br/>Asensor: "));
                _Panel.Controls.Add(_Asensor);
                _Panel.Controls.Add(new LiteralControl("<br/>Piso: "));
                _Panel.Controls.Add(_Piso);
            }

            else if(propiedad is Casa)
            {
                // Casa
                Casa casa = (Casa)propiedad;

                _TamañoCasa.Text = Convert.ToString(casa.MetrosCuadradosC);
                _FondoJardin.Checked = casa.FondoJardin;
                _FondoJardin.Enabled = false;

                _Panel.Controls.Add(new LiteralControl("<br/>Tamaño de la casa: "));
                _Panel.Controls.Add(_TamañoCasa);
                _Panel.Controls.Add(new LiteralControl("<br/>Fondo/Jardin: "));
                _Panel.Controls.Add(_FondoJardin);
            }

            else if(propiedad is Local)
            {
                // Local
                Local local = (Local)propiedad;

                _Panel.Controls.Add(new LiteralControl("<br/>Habilitacion: "));
                _Habilitacion.Checked = local.Habilitacion;
                _Habilitacion.Enabled = false;

                _Panel.Controls.Add(_Habilitacion);
            }

            _Panel.Controls.Add(new LiteralControl("<br/><h4>Precio: $"));
            _Panel.Controls.Add(_Precio);
            _Panel.Controls.Add(new LiteralControl("</h4>"));
            _Panel.Controls.Add(new LiteralControl("<br/>"));

            _Panel.Controls.Add(new LiteralControl("</td><td style='vertical-align:top;width:40%'>"));
            // DATOS DE LA ZONA
            // Zona
            _Panel.Controls.Add(new LiteralControl("<h4>DATOS DE ZONA</h4>"));
            _Panel.Controls.Add(new LiteralControl("Nombre oficial: "));
            _Panel.Controls.Add(_ZonaNombreOficial);
            _Panel.Controls.Add(new LiteralControl("<br/>Departamento: "));
            _Panel.Controls.Add(_ZonaDepartamento);
            _Panel.Controls.Add(new LiteralControl("<br/>Nombre: "));
            _Panel.Controls.Add(_ZonaNombre);
            _Panel.Controls.Add(new LiteralControl("<br/>Cantidad de habitantes: "));
            _Panel.Controls.Add(_ZonaCantidad);
            _Panel.Controls.Add(new LiteralControl("<br/>Servicios disponibles: <br/><br/>"));
            _ZonaServicios.Enabled = false;
            _Panel.Controls.Add(_ZonaServicios);

            _Panel.Controls.Add(new LiteralControl("</td><td style='width:10%'></td></tr></table><br/>"));
            this.Controls.Add(_Panel);

        }

        // PASA PROPIEDAD
        public void setPropiedad(Propiedad propiedadSet)
        {
            propiedad = propiedadSet;

        }

    }
}
