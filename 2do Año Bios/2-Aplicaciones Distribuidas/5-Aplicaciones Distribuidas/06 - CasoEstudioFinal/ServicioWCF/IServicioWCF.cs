using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioWCF" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioWCF
    {
        #region Cliente
        [OperationContract]
        void Alta(Cliente C);

        [OperationContract]
        void Baja(Cliente C);

        [OperationContract]
        void Modificar(Cliente C);

        [OperationContract]
        Cliente LogueoCliente(string pUsu, string pPass);

        [OperationContract]
        Cliente BuscarCliente(int pNumCli);

        [OperationContract]
        List<Cliente> ListarC();

        [OperationContract]
        string ListaMovsDeCliente(Cliente pCLiente);
        #endregion

        #region Cuenta
        [OperationContract]
        void AltaCuenta(Cuenta unaCuenta);

        [OperationContract]
        void BajaCuenta(Cuenta unaCuenta);

        [OperationContract]
        Cuenta BuscarCuenta(int pNumCta);

        [OperationContract]
        List<Cuenta> ListarTodasCuenta();

        [OperationContract]
        List<Movimiento> ListarMovimientosDeCuenta(Cuenta unaCuenta);
        #endregion

        #region Empleado
        [OperationContract]
        Empleado Logueo(int pCI, string pPass);
        #endregion

        #region Movimientos
        [OperationContract]
        void MovimientoAlta(Movimiento pMovimiento);

        [OperationContract]
        List<Movimiento> ListarTodosLosMovimientos();
        #endregion

        #region Prestamo
        [OperationContract]
        void AltaPrestamo(Prestamo pPrestamo);

        [OperationContract]
        List<Prestamo> ListoPrestamosCliente(Cliente unCliente);

        [OperationContract]
        List<Prestamo> ListoPrestamos();
        #endregion

    }
}
