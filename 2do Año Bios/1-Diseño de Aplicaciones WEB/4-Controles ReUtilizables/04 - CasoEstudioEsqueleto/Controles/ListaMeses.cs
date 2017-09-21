using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class ListaMeses : DropDownList
    {
        private List<string> _Meses;

        public ListaMeses():base()
        {
            _Meses = new List<string>();
            _Meses.Add("Enero");
            _Meses.Add("Febrero");
            _Meses.Add("Marzo");
            _Meses.Add("Abril");
            _Meses.Add("Mayo");
            _Meses.Add("Junio");
            _Meses.Add("julio");
            _Meses.Add("Agosto");
            _Meses.Add("Setiembre");
            _Meses.Add("Octubre");
            _Meses.Add("Noviembre");
            _Meses.Add("Diciembre");

            //Asigno la lista al list
            this.DataSource = _Meses;
            this.DataBind();
        }

        public int SeleccionMes
        {
            get { return (this.SelectedIndex + 1); }
            set
            {
                if (value >= 1 && value <= 12)
                {
                    this.SelectedIndex = value - 1;
                }
                else
                {
                    throw new InvalidCastException("El valor asignado no se corresponde con ningun mes");
                }
            }
        }
    }
}
