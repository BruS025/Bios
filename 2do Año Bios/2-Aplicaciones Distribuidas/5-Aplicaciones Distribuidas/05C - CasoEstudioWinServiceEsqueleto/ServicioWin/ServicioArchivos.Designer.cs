namespace ServicioWin
{
    partial class ServicioArchivos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Cronometro = new System.Windows.Forms.Timer(this.components);
            this.elMensaje = new System.Diagnostics.EventLog();
            this.fswRevision = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.elMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswRevision)).BeginInit();
            // 
            // Cronometro
            // 
            this.Cronometro.Interval = 5000;
            // 
            // fswRevision
            // 
            this.fswRevision.EnableRaisingEvents = true;
            this.fswRevision.Created += new System.IO.FileSystemEventHandler(this.fswRevision_Created);
            // 
            // ServicioArchivos
            // 
            this.CanPauseAndContinue = true;
            this.ServiceName = "ServicioArchivos";
            ((System.ComponentModel.ISupportInitialize)(this.elMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswRevision)).EndInit();

        }

        #endregion

        private System.Windows.Forms.Timer Cronometro;
        private System.Diagnostics.EventLog elMensaje;
        private System.IO.FileSystemWatcher fswRevision;
    }
}
