using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class EjemploLinqToAdo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnCargaInicial_Click(object sender, EventArgs e)
    {
        System.Data.DataSet _ds = new System.Data.DataSet();
        System.Data.SqlClient.SqlDataAdapter _da = new System.Data.SqlClient.SqlDataAdapter("TodasLasMascotas", "Data Source=.; Initial Catalog = Veterinaria; Integrated Security = true");

        _da.Fill(_ds, "Mascotas");
        ViewState["Mascotas"] = _ds.Tables["Mascotas"];

        GVMostrarDesdeBD.DataSource = (System.Data.DataTable)ViewState["Mascotas"];
        GVMostrarDesdeBD.DataBind();
    }

    protected void BtnFiltrar1_Click(object sender, EventArgs e)
    {
        //1.Origen de los datos
        System.Data.DataTable _MiTabla = (System.Data.DataTable)ViewState["Mascotas"];

        //2. consulta
        var resultado = from unRegistro in _MiTabla.Select()
                        where (int)unRegistro["EdadMas"] > 5
                        select unRegistro;

        //3. Ejecucion
        LBResultado.Items.Clear();
        //var es lo mismo que datarow porque me tira datarow para afuera 
        foreach (var unReg in resultado)
        {
            LBResultado.Items.Add(unReg["NomMas"].ToString() +
                            "-" + unReg["RazaMas"].ToString() +
                            "-" + unReg["EdadMas"].ToString());
        }
    }

    protected void BtnFiltrar2_Click(object sender, EventArgs e)
    {
        //1.Origen de datos
        System.Data.DataTable _MiTabla = (System.Data.DataTable)ViewState["Mascotas"];

        //.2 Consu;ta
        var resultado = (from unRegistro in _MiTabla.Select()
                         orderby unRegistro["EdadMas"]
                         select unRegistro).Last();

        //3. Despliegue resultado
        LBResultado.Items.Clear();
        LBResultado.Items.Add(resultado["NomMas"].ToString() + "-"
                            + resultado["RazaMas"].ToString() + "-"
                            + resultado["EdadMas"]);

    }

    protected void BtnFiltrar3_Click(object sender, EventArgs e)
    {
        //1.Origen de datos
        System.Data.DataTable _MiTabla = (System.Data.DataTable)ViewState["Mascotas"];

        var resultado = (from unRegistro in _MiTabla.Select()
                         where (int)unRegistro["EdadMas"] == 15
                         select unRegistro).Any();

        LBResultado.Items.Clear();
        LBResultado.Items.Add(resultado.ToString());
    }


    protected void BtnFiltrar4_Click(object sender, EventArgs e)
    {
        System.Data.DataSet _ds = new System.Data.DataSet();
        System.Data.DataTable _tablaDuenios = null;
        System.Data.DataTable _tablaMascotas = null;

        //obtengo origen de datos dueños y lo muestro esta es la primera
        //es importante cual va primero porque agrupamos por la primera
        //queremos saber los dueños de las mascotas osea primero DUEñOS
        System.Data.SqlClient.SqlDataAdapter _daD = new System.Data.SqlClient.SqlDataAdapter("Select * From Dueños", "Data Source =.; Initial Catalog = Veterinaria;Integrated Security = True");

        _daD.Fill(_ds, "Dueños");
        _tablaDuenios = _ds.Tables["Dueños"];
        GVMostrarDesdeBD.DataSource = _tablaDuenios;
        GVMostrarDesdeBD.DataBind();

        //Obtengo origen de datos mascotas
        //
        System.Data.SqlClient.SqlDataAdapter _daM = new System.Data.SqlClient.SqlDataAdapter("Select * From Mascotas", "Data Source =.; Initial Catalog = Veterinaria;Integrated Security = True");

        _daM.Fill(_ds, "Mascotas");
        _tablaMascotas = _ds.Tables["Mascotas"];

        var resultado = from unRegistroD in _tablaDuenios.Select()
                            //es importante cual va primero porque agrupamos por la primera
                            //queremos saber los dueños de las mascotas osea primero DUEñOS
                        join unRegistroM in _tablaMascotas.Select()
                            //es de mascotas ahora la fuente de datos porque cruzamos con dueños
                        on unRegistroD["IdDueño"] equals unRegistroM["IdDueño"]
                            //los juntamos por la pk de dueños y la fk de mascotas
                        group unRegistroD by unRegistroD["NomDueño"]
                            //agrupamos por el nombre de dueños que esta en la tabla dueños
                        into tablaRes
                            //tenemos que crear algo en donde meter el resultado
                        select new
                        {
                            NomDueño = tablaRes.First()["NomDueño"],//first devuelve el primer valor del grupo,este elemento es un dataRow porque linq tiene dataRow
                            CantidaM = tablaRes.Count()//me devuelve la cantidad de elementos que tiene para ese dueño
                        };//el select es un objeto anonimo a partir de los datos que tengo
                            //me va a devolver tantos grupos como se hayan armado las consultas !
                            //en el objeto anonimo saco los valores que quiero de cada grupo 

        //Ejecuta la consulta
        LBResultado.Items.Clear();

        foreach (var unReg in resultado)
        {
            LBResultado.Items.Add(unReg.NomDueño.ToString() +
                               " ( " + unReg.CantidaM.ToString() + " ) ");
        }
    }


    protected void BtnFiltrar5_Click(object sender, EventArgs e)
    {
        System.Data.DataTable _MiTabla = (System.Data.DataTable)ViewState["Mascotas"];

        var resultado = from unRegistroD in _MiTabla.Select()
                        group unRegistroD by unRegistroD["IdDueño"]
                        into TablaRes
                        select TablaRes;//esto es un conjunto de conjuntos 

        LBResultado.Items.Clear();

        foreach (var unReg in resultado)
        {
            LBResultado.Items.Add(unReg.Key.ToString() + "-" + unReg.Count());
        }
    }
}