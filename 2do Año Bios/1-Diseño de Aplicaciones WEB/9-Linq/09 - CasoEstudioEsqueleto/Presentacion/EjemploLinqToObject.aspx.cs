using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EjemploLinqToObject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnCargaInicial_Click(object sender, EventArgs e)
    {
        GVDueños.DataSource = Logica.LogicaDueño.ListarDueñosManual();
        GVDueños.DataBind();
    }

    protected void BtnFiltrar1_Click(object sender, EventArgs e)
    {
        //1. obtengo la fuente de datos para LinQ
        List<EntidadesCompartidas.Dueño> _LosDuenios = Logica.LogicaDueño.ListarDueñosManual();

        //2. determino la consulta = solo quiero dueños con mas de 3 mascotas
        var resultado = from unDuenio in _LosDuenios
                        where unDuenio.CantMascotas > 3
                        select unDuenio;

        /*Segunda Opcion
        var resultado = from unDuenio in _LosDuenios
                        where unDuenio.MisMascotas.Count > 3
                        select unDuenio;*/

        //3. despliego el resultado en el listbox
        LBResultadoDueño.Items.Clear();
        foreach (EntidadesCompartidas.Dueño unDuenio in resultado)
        {
            LBResultadoDueño.Items.Add(unDuenio.ToString());
        }
    }

    protected void BtnFiltrar2_Click(object sender, EventArgs e)
    {
        //1. Obtengo la fuente de datos para Linq
        List<EntidadesCompartidas.Dueño> _LosDuenios = Logica.LogicaDueño.ListarDueñosManual();

        //2. determino la consulta = solo quiero dueños con menos de 6 caracteres en el nombre
        var resultado = from unduenio in _LosDuenios
                        where unduenio.Nombre.Trim().Length < 6
                        select unduenio;

        //3. despliego el resultado en le listbox
        foreach (var unDuenio in resultado)
        {
            LBResultadoDueño.Items.Add(unDuenio.ToString());
        }
    }

    protected void BtnCargaInicialMAscota_Click(object sender, EventArgs e)
    {
        GVMascota.DataSource = Logica.LogicaMascota.ListarMascotasManual();
        GVMascota.DataBind();
    }

    protected void BtnFiltrar3_Click(object sender, EventArgs e)
    {
        //1. Obtengo la fuente de datos para Linq
        List<EntidadesCompartidas.Mascota> _laMascota = Logica.LogicaMascota.ListarMascotasManual();

        //2. determino la consulta = solo quiero la edad de las mascotas > 10
        var resultado = from unaMascota in _laMascota
                        where unaMascota.Edad > 10
                        select unaMascota;

        //3. despliego el resultado en el listbox
        List<EntidadesCompartidas.Mascota> _resultado = new List<EntidadesCompartidas.Mascota>();

        foreach (EntidadesCompartidas.Mascota unaM in resultado)
        {
            _resultado.Add(unaM);//me quedo con cada objeto que me devuelve 

            GVMascota.DataSource = _resultado;
            GVMascota.DataBind();
        }
    }

    protected void BtnFiltrar4_Click(object sender, EventArgs e)
    {
        //Determino la consulta

        List<EntidadesCompartidas.Mascota> _listaResultado = (from UnaM in (Logica.LogicaMascota.ListarMascotasManual())
                                                              where UnaM.Raza.Contains("Perro")
                                                              select UnaM).ToList < EntidadesCompartidas.Mascota>();

        //despliego el resultado en la grilla
        GVMascota.DataSource = _listaResultado;
        GVMascota.DataBind();
    }
}