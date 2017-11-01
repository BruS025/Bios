using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.Threading;

using PresentacionWin.WSArticulos;


namespace PresentacionWin
{
    public partial class ABMArticulos : Form
    {
        List<int> losNO = new List<int>();
        List<WSArticulos.Articulo> listaArts = new List<WSArticulos.Articulo>();
        bool stoped = false;
        public ABMArticulos()
        {
            InitializeComponent();
        }

        private void ABMArticulos_Load(object sender, EventArgs e)
        {

        }

        private void TxtCodigo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TxtNombre.Text = "";
                TxtPrecio.Text = "";

                WSArticulos.ServicioArticulos sArts = new WSArticulos.ServicioArticulos();
                WSArticulos.Articulo art = sArts.BuscarArticulo(Convert.ToInt32(TxtCodigo.Text));

                if (art != null)
                {
                    TxtNombre.Text = art.Nombre;
                    TxtPrecio.Text = art.Precio.ToString();
                    BtnBaja.Enabled = true;
                    BtnModificar.Enabled = true;
                    BtnAlta.Enabled = false;
                }
                else
                {
                    BtnBaja.Enabled = false;
                    BtnModificar.Enabled = false;
                    BtnAlta.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LblError.Text= ex.Message;
            }  
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
 
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                WSArticulos.Articulo art = new WSArticulos.Articulo();

                art.Codigo = Convert.ToInt32(TxtCodigo.Text);
                art.Nombre = TxtNombre.Text;
                art.Precio = Convert.ToDecimal(TxtPrecio.Text);

                WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

                Service.AltaArticulo(art);

                btnDefdecto();
                losNO.Add(art.Codigo);
                toolStripStatusLabel1.Text = "Alta correcta";
            }
            catch (SoapException ex)
            {
                toolStripStatusLabel1.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            (new ListarArticulos()).ShowDialog();
        }

        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
            btnDefdecto();
        }

        void btnDefdecto() 
        {
            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
            BtnBaja.Enabled = false;
            BtnDeshacer.Enabled = true;
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtPrecio.Text = "";

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                WSArticulos.Articulo art = new WSArticulos.Articulo();

                art.Codigo = Convert.ToInt32(TxtCodigo.Text);
                art.Nombre = TxtNombre.Text;
                art.Precio = Convert.ToDecimal(TxtPrecio.Text);

                WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

                Service.ModificarArticulo(art);

                btnDefdecto();
                toolStripStatusLabel1.Text = "Modificación correcta";
            }
            catch (SoapException ex)
            {
                toolStripStatusLabel1.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
             try
            {
                WSArticulos.Articulo art = new WSArticulos.Articulo();

                art.Codigo = Convert.ToInt32(TxtCodigo.Text);
                art.Nombre = TxtNombre.Text;
                art.Precio = Convert.ToDecimal(TxtPrecio.Text);

                WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

                Service.BajaArticulo(art);

                btnDefdecto();
                toolStripStatusLabel1.Text = "Eliminación correcta";
            }
            catch (SoapException ex)
            {
                toolStripStatusLabel1.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            
        }

        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
