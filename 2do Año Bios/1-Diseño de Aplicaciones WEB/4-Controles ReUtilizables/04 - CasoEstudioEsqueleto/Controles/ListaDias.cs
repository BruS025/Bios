using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class ListaDias : DropDownList
    {
        private List<int> _Dias;

        public ListaDias():base()
        {
            _Dias = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                _Dias.Add(i);
            }
            this.DataSource = _Dias;
            this.DataBind();
        }

        public int SeleccionDia
        {
            get { return (this.SelectedIndex + 1); }
            set
            {
                if (value >= 1 && value <= 31)
                {
                    this.SelectedIndex = value - 1;
                }
                else
                {
                    throw new InvalidCastException("El valor asignado no se corresponde con ningun dia");
                }
            }
        }
    }
}
