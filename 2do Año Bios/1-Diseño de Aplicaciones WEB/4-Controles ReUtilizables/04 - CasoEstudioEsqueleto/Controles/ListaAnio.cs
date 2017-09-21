using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
   public class ListaAnio:DropDownList
    {
        private List<int> _Anio;

        public ListaAnio() : base()
        {
            _Anio = new List<int>();

            int anio = DateTime.Now.Year;

            for (int i = anio - 20; i <= anio + 20; i++)
            {
                _Anio.Add(i);
            }
            this.DataSource = _Anio;
            this.DataBind();
        }
        public int SeleccionAnio
        {
            get { return (Convert.ToInt32(SelectedValue)); }
            set
            {
                if (value >= (DateTime.Now.Year - 20) && value <= (DateTime.Now.Year + 20))
                {
                    this.SelectedIndex = value - (DateTime.Now.Year - 20);
                }
                else
                {
                    throw new InvalidCastException("El valor asignado no se corresponde con ningun año");
                }
            }
        }
    }
}
