using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Clases
{
    public class Cliente
    {
        // Atributos
        private int _cedulaCliente;
        private string _direccionCliente;
        private long _telefonoCliente;
        private int _descuentoCliente;

        // Constructor por defecto
        public Cliente() { }

        // Constructor con parametros
        public Cliente(int cedulaCliente, string direccionCliente, long telefonoCliente, int descuentoCliente)
        {
            _cedulaCliente = cedulaCliente;
            _direccionCliente = direccionCliente;
            _telefonoCliente = telefonoCliente;
            _descuentoCliente = descuentoCliente;
        }

        // Propiedades Cedula
        public int Cédula
        {
            get { return _cedulaCliente; }
            set
            {
                if (value > 0)
                {
                    _cedulaCliente = value;
                }
            }
        }

        // Propiedades Dirección
        public string Dirección
        {
            get { return _direccionCliente; }
            set{ _direccionCliente = value;}
            
        }

        // Propiedades Telefono
        public long Teléfono
        {
            get { return _telefonoCliente; }
            set { _telefonoCliente = value; }           
        }

        // Propiedades Descuento
        public int Descuento
        {
            get { return _descuentoCliente; }
            set{ _descuentoCliente = Convert.ToInt32(value);}
        }

        // Metodo para verificar existencia de un documento
        public bool BuscarExistenciaDocumento(int documento , List<Cliente> listadoClientes)
        {           
          foreach (var cliente in listadoClientes)
           {
             if (cliente.Cédula == documento)
                {
                  return true;
                }
            }
          return false;
        }

        // Metodo para verificar existencia de busqueda en cualquier atributo
        public List<Cliente> BuscarExistencia(string coincidencia, List<Cliente> listadoClientes)
        {
            List<Cliente> listadoClientesBusqueda = new List<Cliente>();

            long numeroVerificarLong = 0;
            string stringVerificarLong = "";
            bool resultadoVerificarLong = false;

            stringVerificarLong = coincidencia;
            resultadoVerificarLong = Int64.TryParse(stringVerificarLong, out numeroVerificarLong); // Si es long retorna TRUE sino FALSE

                if (resultadoVerificarLong == true) // Primero verificamos si es long ya que LONG contiene a INT
                    {
                        int numeroVerificarInt = 0;
                        string stringVerificarInt = "";
                        bool resultadoVerificarInt = false;

                        stringVerificarInt = coincidencia;
                        resultadoVerificarInt = Int32.TryParse(stringVerificarInt, out numeroVerificarInt); // Si es int retorna TRUE sino FALSE

                        if ( resultadoVerificarInt == true)
                            {
                                foreach (var cliente in listadoClientes) // Busqueda por direccion / telefono / cedula / descuento
                                    {
                                        if (cliente.Dirección == coincidencia || cliente.Teléfono == Convert.ToInt64(coincidencia) || cliente.Cédula == Convert.ToInt32(coincidencia) || cliente.Descuento == Convert.ToInt32(coincidencia))
                                            {
                                                listadoClientesBusqueda.Add(cliente);
                                            }
                                    }
                            }
                        else // Busqueda por direccion / telefono
                            {
                                foreach (var cliente in listadoClientes)
                                    {
                                        if (cliente.Dirección == coincidencia || cliente.Teléfono == Convert.ToInt64(coincidencia))
                                            {
                                                listadoClientesBusqueda.Add(cliente);
                                            }
                                    }
                            }
                    }
                else // Busqueda por direccion
                    {
                        foreach (var cliente in listadoClientes)
                            {
                                if (cliente.Dirección == coincidencia)
                                    {
                                        listadoClientesBusqueda.Add(cliente);
                                    }
                            }
                    }                              
            return listadoClientesBusqueda;
        }

        // Metodo para agregar clientes al listado
        public List<Cliente> Agregar(List<Cliente> listadoClientes, Cliente clienteAgregar)
        {
            listadoClientes.Add(clienteAgregar);
            return listadoClientes;
        }

        // Metodo para eliminar clientes al listado
        public List<Cliente> Eliminar(List<Cliente> listadoClientes, Cliente clienteEliminar)
        {
            foreach (var cliente in listadoClientes)
            {
                if (clienteEliminar.Cédula == cliente.Cédula)
                {
                    listadoClientes.Remove(cliente);
                    return listadoClientes;
                }
            }
            
            return listadoClientes;                   
        }

        // Metodo para modificar listado de clientes
        public List<Cliente> Modificar(List<Cliente> listadoClientes, Cliente clienteModificar)
        {
            foreach (var cliente in listadoClientes)
            {
                if (cliente.Cédula == clienteModificar.Cédula)
                {
                    cliente.Cédula = clienteModificar.Cédula;
                    cliente.Dirección = clienteModificar.Dirección;
                    cliente.Teléfono = clienteModificar.Teléfono;
                    cliente.Descuento = clienteModificar.Descuento;

                    return listadoClientes;
                }
            }

            return listadoClientes;
        }
        
        // FIN
    }
}


