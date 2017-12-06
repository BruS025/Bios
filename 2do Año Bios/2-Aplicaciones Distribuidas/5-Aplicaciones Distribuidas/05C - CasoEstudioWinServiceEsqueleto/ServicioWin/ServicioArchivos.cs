using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using Logica;
using EntidadesCompartidas;
using System.Configuration;
using System.IO;

namespace ServicioWin
{
    partial class ServicioArchivos : ServiceBase
    {
        public ServicioArchivos()
        {
            InitializeComponent();

            //1.Inicializamos nuestro eventoLog personalizado
            //Si no existe se crea la entrada donde se "guardan" los mensajes a generar
            if (!System.Diagnostics.EventLog.SourceExists("MiServicioArchivos"))
                System.Diagnostics.EventLog.CreateEventSource("MiServicoArchivos", "ServicoArchivosLog");

            //2.Indicamos a nuestro servicio que va a loguear bajo los siguientes elementos
            elMensaje.Source = "MiServicioArchivos";
            elMensaje.Log = "ServicioArchivosLog";

            //Seteamos el path para el file system watcher
            fswRevision.Path = ConfigurationManager.AppSettings["fsPath"];
        }

        protected override void OnStart(string[] args)
        {
            //avisamos del inicio del servicio
            elMensaje.WriteEntry("Inicia el servicio - ServicioArchivos");

            //iniciamos el timer por si se freno
            Cronometro.Enabled = true;
            Cronometro.Start();
        }

        protected override void OnStop()
        {
            //avisamos del fin del servicio
            elMensaje.WriteEntry("Fin del servicio - ServicioArchivos");

            //iniciamos el timer por si se freno
            Cronometro.Enabled = false;
            Cronometro.Stop();
        }

        protected override void OnPause()
        {
            //avisamos pausa del servicio
            elMensaje.WriteEntry("Se pauso el servicio - ServicioArchivos");

            //iniciamos el timer por si se freno
            Cronometro.Enabled = false;
            Cronometro.Stop();
        }

        protected override void OnContinue()
        {
            //avisamos la continuidad del servicio
            elMensaje.WriteEntry("Se continua el servicio - ServicioArchivos");

            //iniciamos el timer por si se freno
            Cronometro.Enabled = true;
            Cronometro.Start();
        }

        private void fswRevision_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                //revisamos si se ha creado algun archivo que contengo en su nombre algun texto bios
                if (e.Name.ToLowerInvariant().Contains("bios"))
                {
                    //obtengo informacion del archivo
                    FileInfo info = new FileInfo(e.FullPath);

                    //creo objeto con datos
                    Archivo archivo = new Archivo(e.Name, info.Extension, info.Length, info.CreationTime);

                    //mando a dar de alta la informacion en la bd
                    FabricaLogica.getLogicaArchivo().AgregarArchivo(archivo);

                    //avisamos que se genero registro del archivo 
                    elMensaje.WriteEntry("El archivo" + e.Name + "Se agrego en la bd");
                }
                else
                {
                    elMensaje.WriteEntry("El archivo" + e.Name + "No sera considerado");
                }
            }
            catch (Exception ex)
            {
                elMensaje.WriteEntry(ex.Message + " - archivo " + e.Name);
            }
        }
    }
}
