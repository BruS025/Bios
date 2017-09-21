using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Calendario : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //determino mismo controlador para los controles de los meses
        lbtnEnero.Click += new EventHandler(DeterminoMeses);
        lbtnFebrero.Click += new EventHandler(DeterminoMeses);
        lbtnMarzo.Click += new EventHandler(DeterminoMeses);
        lbtnAbril.Click += new EventHandler(DeterminoMeses);
        lbtnMayo.Click += new EventHandler(DeterminoMeses);
        lbtnJunio.Click += new EventHandler(DeterminoMeses);
        lbtnJulio.Click += new EventHandler(DeterminoMeses);
        lbtnAgosto.Click += new EventHandler(DeterminoMeses);
        lbtnSetiembre.Click += new EventHandler(DeterminoMeses);
        lbtnOctube.Click += new EventHandler(DeterminoMeses);
        lbtnNoviembre.Click += new EventHandler(DeterminoMeses);
        lbtnDiciembre.Click += new EventHandler(DeterminoMeses);

        //Nuestro calendario permite modificar el mes de la fecha actualmente seleccionada para lo cual tengo los 12 botones 1 por cada mes
        //el trabajo de cada boton es identico basado en eso es que tengo 1 solo controlador para todos los botones ya que la unica
        //variable es el numero del mes pero la verificacion es la misma
    }

    protected void DeterminoMeses(object sender ,EventArgs e)
    {
        //obtengo datos de la fecha seleccionada
        int anio = cFecha.SelectedDate.Year;
        int mes = cFecha.SelectedDate.Month;
        int dia = cFecha.SelectedDate.Day;

        //determino la cantidad de dias del mes que se selecciono (me baso e el numero)
        int cantidad = DateTime.DaysInMonth(anio, Convert.ToInt32(((LinkButton)sender).Text));
        //daysinmonth es una operacion de tipo datetime que dado un año y un mes me dicen la cantidad de dias que tiene ese mes en ese año

        //verifico para cambio de mes en el control calendar
        if(dia <=cantidad)
        {
            //esta bien el dia
            cFecha.SelectedDate = new DateTime(anio, Convert.ToInt32(((LinkButton)sender).Text), dia);
            cFecha.VisibleDate = new DateTime(anio, Convert.ToInt32(((LinkButton)sender).Text), dia);
        }
        else
        {
            //el dia no corresponde, pongo el ultimo del mes
            cFecha.SelectedDate = new DateTime(anio, Convert.ToInt32(((LinkButton)sender).Text), cantidad);
            cFecha.VisibleDate = new DateTime(anio, Convert.ToInt32(((LinkButton)sender).Text), cantidad);
        }
    }

    public DateTime Fecha
    {
        get { return cFecha.SelectedDate; }
        set
        {
            cFecha.SelectedDate = value;
            cFecha.VisibleDate = value;
        }
    }

    protected void AnioAtras_Click(object sender, EventArgs e)
    {
        //le saco un año a la fecha seleccionada en el calendario
        DateTime unaFecha = cFecha.SelectedDate.AddYears(-1);
        cFecha.SelectedDate = unaFecha;
        cFecha.VisibleDate = unaFecha;
    }

    protected void AnioAdelante_Click(object sender, EventArgs e)
    {
        DateTime unaFecha = cFecha.SelectedDate.AddYears(1);
        cFecha.SelectedDate = unaFecha;
        cFecha.VisibleDate = unaFecha;
    }
}