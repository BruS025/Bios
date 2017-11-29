using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;
using Logica;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioWCF" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioWCF.svc o ServicioWCF.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioWCF : IServicioWCF
    {
        #region Cliente
        void IServicioWCF.Alta(Cliente C)
        {
            FabricaLogica.GetLogicaCliente().Alta(C);
        }

        void IServicioWCF.Baja(Cliente C)
        {
            FabricaLogica.GetLogicaCliente().Baja(C);
        }

        void IServicioWCF.Modificar(Cliente C)
        {
            FabricaLogica.GetLogicaCliente().Modificar(C);
        }

        Cliente IServicioWCF.BuscarCliente(int pNumCli)
        {
            return FabricaLogica.GetLogicaCliente().Buscar(pNumCli);
        }
        
        Cliente IServicioWCF.LogueoCliente(string pUsu, string pPass)
        {
            return FabricaLogica.GetLogicaCliente().Logueo(pUsu, pPass);
        }

        List<Cliente> IServicioWCF.ListarC()
        {
            return FabricaLogica.GetLogicaCliente().Listar();
        }
        #endregion

        #region Cuenta
        void IServicioWCF.AltaCuenta(Cuenta unaCuenta)
        {
            FabricaLogica.GetLogicaCuenta().Alta(unaCuenta);
        }

        void IServicioWCF.BajaCuenta(Cuenta unaCuenta)
        {
            FabricaLogica.GetLogicaCuenta().Baja(unaCuenta);
        }

        Cuenta IServicioWCF.BuscarCuenta(int pNumCta)
        {
            return FabricaLogica.GetLogicaCuenta().Buscar(pNumCta);
        }

        List<Cuenta> IServicioWCF.ListarTodasCuenta()
        {
            return FabricaLogica.GetLogicaCuenta().ListarTodas();
        }

        List<Movimiento> IServicioWCF.ListarMovimientosDeCuenta(Cuenta unaCuenta)
        {
            return FabricaLogica.GetLogicaCuenta().ListarMovimientosDeCuenta(unaCuenta);
        }

        #endregion

        #region Empleado
        Empleado IServicioWCF.Logueo(int pCI, string pPass)
        {
           return FabricaLogica.GetLogicaEmpleado().Logueo(pCI, pPass);
        }
        #endregion

        #region Movimientos
        void IServicioWCF.MovimientoAlta(Movimiento pMovimiento)
        {
            FabricaLogica.GetLogicaMovimiento().MovimientoAlta(pMovimiento);
        }

        List<Movimiento> IServicioWCF.ListarTodosLosMovimientos()
        {
           return FabricaLogica.GetLogicaMovimiento().ListarTodosLosMovimientos();
        }

        string IServicioWCF.ListaMovsDeCliente(Cliente pCLiente)
        {
            return FabricaLogica.GetLogicaCliente().ListaMovsDeCliente(pCLiente).OuterXml;
        }
        #endregion

        #region Prestamo
        
        void IServicioWCF.AltaPrestamo(Prestamo pPrestamo)
        {
            FabricaLogica.GetLogicaPrestamo().Alta(pPrestamo);
        }
      
        List<Prestamo> IServicioWCF.ListoPrestamosCliente(Cliente unCliente)
        {
            return FabricaLogica.GetLogicaPrestamo().ListoPrestamosCliente(unCliente);
        }

        List<Prestamo> IServicioWCF.ListoPrestamos()
        {
            return FabricaLogica.GetLogicaPrestamo().ListoPrestamos();
        }
        #endregion
    }
}
