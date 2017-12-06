namespace ServicioWin
{
    partial class ProjectInstaller
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
            this.InstaladorProcesoServicio = new System.ServiceProcess.ServiceProcessInstaller();
            this.InstaladorServicio = new System.ServiceProcess.ServiceInstaller();
            // 
            // InstaladorProcesoServicio
            // 
            this.InstaladorProcesoServicio.Password = null;
            this.InstaladorProcesoServicio.Username = null;
            // 
            // InstaladorServicio
            // 
            this.InstaladorServicio.Description = "Instalador Servicio Archios";
            this.InstaladorServicio.DisplayName = "Servicio Archivos";
            this.InstaladorServicio.ServiceName = "ServicioArchivos";
            this.InstaladorServicio.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.InstaladorProcesoServicio,
            this.InstaladorServicio});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller InstaladorProcesoServicio;
        private System.ServiceProcess.ServiceInstaller InstaladorServicio;
    }
}