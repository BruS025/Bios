using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Universidad _unaUniversidad = null;
            if (!IsPostBack)
            {
                //Como primer ingreso al sitio creo 
                //1.- Universidad
                _unaUniversidad = new Universidad("Bios");
                //2.-Materia
                _unaUniversidad.RegistrarMateria(new Materia("Aplicaciones Distribuidas"));
                _unaUniversidad.RegistrarMateria(new Materia("Base de Datos"));
                //Guardo en session
                Session["MiUniversidad"] = _unaUniversidad;
                //cargo listbox de despliegue
                LbAlumnos.DataSource = _unaUniversidad.ListaAlumnos;
                LbAlumnos.DataTextField = "Apellido";
                LbAlumnos.DataBind();

                LbMaterias.DataSource = _unaUniversidad.ListaMaterias;
                LbMaterias.DataTextField = "Nombre";
                LbMaterias.DataBind();
            }

        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void BtnAgregarAlumno_Click(object sender, EventArgs e)
    {
        try
        {
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];
            //creo un alumno y le asigno el controlador de eventos para inscripciones
            Alumno _unAlumno = new Alumno(TxtNom.Text.Trim(), TxtApe.Text.Trim());

            //aca es en la parte que el delegado asigna el controlador al evento del objeto alumno
            _unAlumno.InscripcionMateria += new inscripcionMateriaEventHandler(InscribirAlumnoMateria);
            //al evento le sumo otro delegado porque puede tener multiples controladores asignados
            //lo que esta entre parentecis es a donde apunta lo que va a buscar 

            //BtnAgregarAlumno_Click += new EventHandler(UnControlador);
            //Eso es lo que hacia visual por nosotros en el doble click

            _miUniversidad.RegistrarAlumno(_unAlumno);
            TxtNom.Text = "";
            TxtApe.Text = "";

            //refresco la lista
            LbAlumnos.Items.Clear();
            LbAlumnos.DataSource = _miUniversidad.ListaAlumnos;
            LbAlumnos.DataTextField = "Apellido";
            LbAlumnos.DataBind();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnInscribir_Click(object sender, EventArgs e)
    {
        try
        {
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];

            //Obtener el alumno
            Alumno _unAlumno = _miUniversidad.ListaAlumnos[LbAlumnos.SelectedIndex];

            //Obtener materia
            Materia _unMateria = _miUniversidad.ListaMaterias[LbMaterias.SelectedIndex];

            //invoco metodo del alumno que genera el evento
            /*esto provoca un operacion que a su vez provoca programaticamente el evento(lo mando a partir de una sentencia)en ese momento se manda a verificar
             * si el objeto que lo provoca tiene asociado al menos 1 delegado para ese evento si tiene asociado un delegado 
             * sigue el puntero del delegado llega al controlador(lo ejecuta) y este linea termina termina de ejecutarse 
             * si proboca en cualquier mometo tira la execpcion(el unico error que podemos tener es que el mismo alumno se quiera inscribir
             * 2 veces a la misma materia)
             * si no pasa nada nos va a decir que la inscripcion fue correcta*/
            _unAlumno.InscribirMateria(_unMateria);

            //si llego aca,se inscribio
            LblError.Text = "Inscripcion correcta";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;            
        }
    }

    protected void BtnAgregarMateria_Click(object sender, EventArgs e)
    {
        try
        {

            Materia _MatNueva = new Materia(txtAgregarMateria.Text.Trim());

            _MatNueva.InscripcionMateriaUniversidad += new inscripcionMateriaUniversidadEventHandler(AgregarMat);

            _MatNueva.InscripcioMatAUni();

            //refresco la lista
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];

            LbMaterias.Items.Clear();
            LbMaterias.DataSource = _miUniversidad.ListaMaterias;
            LbMaterias.DataTextField = "Nombre";
            LbMaterias.DataBind();

            txtAgregarMateria.Text = "";

        }
        catch (Exception ex)
        {
            LblError.Text = "Error " + ex.Message;
        }
    }

    //Esta firma esta definida por el delegado que esta asociado al evento que quiero controlar
    private void InscribirAlumnoMateria(object sender,MateriaEventArgs e)     
    {
         try 
	    {	        
	    	Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];
            _miUniversidad.RegistrarAlumnoMateria((Alumno)sender,e.LaMateria);
	    }
	    catch (Exception ex)
	    {
            //los errores de este catch no los muestra en pantalla porque cuando caen en un catch se muere la exepcio
            //LblError.Text=ex.Message;
            throw ex;
	    }
    }
    
    private void AgregarMat(Materia pMatNueva)
    {
        Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];

        _miUniversidad.RegistrarMateria(pMatNueva);
    }
}
