using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controles
{           //WebControl indica que hago un control que se va a manejar en un ambiente web
            //INamigContainer es la interfaz hace que el control que estoy creando se comporte como un control contenedor
            //con identificacion propia dentro de una pagina
    public class Letras :WebControl, INamingContainer
    {
        //los atributos son de 2 tipos 1ero los atributos que reprecenten a los controles contenidos 
        //y luego estan los atributos de los datos que quiero mantener 
        private TextBox _txtIngreso;
        private DropDownList _ddlTipo;
        private Button _btnProceso;
        private Label _lblResultado;
        private Panel _unPanel; //es el control contenedor que necesito para poder dibujar el contenido del composite en tiempo de ejecucion

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //creo un panel para armar el diseño
            _unPanel = new Panel();

            //Agrego control caja de texto
            _txtIngreso = new TextBox();
            _txtIngreso.Height = Unit.Pixel(15);
            _txtIngreso.Width = Unit.Pixel(200);
            _txtIngreso.ForeColor = System.Drawing.Color.Blue;

            //Aca es donde ponemos las cosas dentro del panel
            _unPanel.Controls.Add(new LiteralControl("Ingrese Texto:"));
            _unPanel.Controls.Add(_txtIngreso);
            _unPanel.Controls.Add(new LiteralControl("<BR/>"));

            //Agrego un control DropDownList
            _ddlTipo = new DropDownList();
            _ddlTipo.Items.Add("Cantidad de Letras");
            _ddlTipo.Items.Add("Pasar a Mayusculas");
            _ddlTipo.Items.Add("Pasar a Minusculas");
            _unPanel.Controls.Add(new LiteralControl("Determine Accion:"));
            _unPanel.Controls.Add(_ddlTipo);

            //Agrego el boton proceso
            _btnProceso = new Button();
            _btnProceso.Text = "Procesar";
            _btnProceso.BackColor = System.Drawing.Color.Salmon;
            _btnProceso.Click += new EventHandler(Proceso);
            _unPanel.Controls.Add(_btnProceso);
            _unPanel.Controls.Add(new LiteralControl("<BR/>"));
            //Todos los eventos que yo quiera capturar y programar la unica opcion que tengo es haciendolo manualmente

            //Agrego control etiqueta
            _lblResultado = new Label();
            _lblResultado.Height = Unit.Pixel(15);
            _lblResultado.Width = Unit.Pixel(200);
            _lblResultado.ForeColor = System.Drawing.Color.Red;
            _unPanel.Controls.Add(new LiteralControl("Resultado: "));
            _unPanel.Controls.Add(_lblResultado);
            _unPanel.Controls.Add(new LiteralControl("<BR/>"));

            //Agrego el panel con los controles
            this.Controls.Add(_unPanel);
            //Si yo no agrego el panel a mi control no se va a ver nada
        }
        protected void Proceso(object sender, EventArgs e)
        {
            //Determino que opcion de dll se selecciono
            int _indice = _ddlTipo.SelectedIndex;

            //obtengo texto asignado
            string _texto = _txtIngreso.Text.Trim();

            //Realizo operacion
            if (_indice == 0)
            {
                _lblResultado.Text = _texto.Length.ToString();
            }
            else if (_indice == 1)
            {
                _lblResultado.Text = _texto.ToUpper();
            }
            else
            {
                _lblResultado.Text = _texto.ToLower();
            }
        }
    }
}
