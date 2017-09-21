using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controles
{
   public class CalendarioASP :WebControl ,INamingContainer
    {
        private ListaDias _listDias;
        private ListaMeses _listMes;
        private ListaAnio _listAnio;
        private Panel _unPanel;
        public DateTime Fecha
        {   
            
            get
            {
                try
                {
                    DateTime fechaver = new DateTime(_listAnio.SeleccionAnio, _listMes.SeleccionMes, _listDias.SeleccionDia);
                    return fechaver;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error en la fecha" + ex.Message);
                }   
            }
            set
            {
                _listAnio.SeleccionAnio = value.Year;
                _listMes.SeleccionMes = value.Month;
                _listDias.SeleccionDia = value.Day;
            }
            
    }
        protected override void CreateChildControls()
        {
            try
            {
                base.CreateChildControls();

                _unPanel = new Panel();

                _listDias = new ListaDias();
                _unPanel.Controls.Add(new LiteralControl("Seleccione un dia: "));
                _unPanel.Controls.Add(_listDias);
                _unPanel.Controls.Add(new LiteralControl("<BR/>"));

                _listMes = new ListaMeses();
                _unPanel.Controls.Add(new LiteralControl("Seleccione un mes: "));
                _unPanel.Controls.Add(_listMes);
                _unPanel.Controls.Add(new LiteralControl("<BR/>"));

                _listAnio = new ListaAnio();
                _unPanel.Controls.Add(new LiteralControl("Seleccione un año: "));
                _unPanel.Controls.Add(_listAnio);
                _unPanel.Controls.Add(new LiteralControl("<BR/>"));



                this.Controls.Add(_unPanel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
