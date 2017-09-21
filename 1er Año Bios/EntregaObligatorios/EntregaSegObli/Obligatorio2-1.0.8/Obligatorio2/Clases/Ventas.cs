using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Clases
{
    public class Ventas
    {
        // Atributos
        private long _numeroVenta;
        private int _cedulaCliente;
        private long _codigoProducto;
        private DateTime _fechaVenta;
        private DateTime _fechaPago;
        private double _totalVenta;
        private int _cantidadProducto;
        private bool _pago;

        // Constructor por defecto
        public Ventas() { }

        // Constructor con parametros
        public Ventas(long numeroVenta,int cedulaCliente,long codigoProducto, DateTime fechaVenta,DateTime fechaPago, double totalVenta, int cantidadProducto ,bool pago)
        {
            _numeroVenta = numeroVenta;
            _cedulaCliente = cedulaCliente;
            _codigoProducto = codigoProducto;
            _fechaVenta = fechaVenta;
            _fechaPago = fechaPago;
            _totalVenta = totalVenta;
            _cantidadProducto = cantidadProducto;
            _pago = pago;
        }

        // Propiedades de "Numero de venta"
        public long NumeroVenta
        {
            get { return _numeroVenta; }
            set
            {
                if (value > 0)
                {
                    _numeroVenta = value;
                }
            }
        }

        // Propiedades de "Documento de cliente"
        public int DocumentoCliente
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

        // Propiedades de "Codigo de producto"
        public long CodigoBarra
        {
            get { return _codigoProducto; }
            set
            {
                if (value > 0)
                {
                    _codigoProducto = value;
                }
            }
        }

        // Propiedades de "Fecha de venta"
        public DateTime FechaVenta
        {
            get { return _fechaVenta; }
            set { _fechaVenta = value; }
        }

        // Propiedades de "Fecha de pago"
        public DateTime FechaPago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }

        // Propiedades de "Total de venta"
        public double TotalVenta
        {
            get { return _totalVenta; }
            set
            {
                if (value > 0)
                {
                    _totalVenta = value;
                }
            }
        }

        // Cantidad del producto
        public int CantidadProducto
        {
            get { return _cantidadProducto; }
            set
            {
                if (value > 0)
                {
                    _cantidadProducto = value;
                }
            }
        }

        // Propiedades de "Pago"
        public bool Pago
        {
            get { return _pago; }
            set { _pago = value;             
            }
        }

        // Metodo para verificar existencia del codigo de venta
        public bool BuscarExistenciaNumeroVenta(long numVenta, List<Ventas> listadoVentas)
        {
            foreach (var venta in listadoVentas)
            {
                if (venta.NumeroVenta == numVenta)
                {
                    return true;
                }
            }
            return false;
        }

        // Metodo que devuelve listado de ventas que realizo un cliente
        public List<Ventas> VentasCliente(int documento, List<Ventas> listadoVentas)
        {
            List<Ventas> nuevoListadoVentas = new List<Ventas>();

            foreach (var venta in listadoVentas)
                {
                    if (venta.DocumentoCliente == documento)
                        {
                            nuevoListadoVentas.Add(venta);
                        }
                }
            return nuevoListadoVentas;
        }

        // Metodo que devuelve listado de ventas que se realizaron de un producto
        public List<Ventas> VentasProducto(long codigo, List<Ventas> listadoVentas)
        {
            List<Ventas> nuevoListadoVentas = new List<Ventas>();

            foreach (var venta in listadoVentas)
            {
                if (venta.CodigoBarra == codigo)
                {
                    nuevoListadoVentas.Add(venta);
                }
            }
            return nuevoListadoVentas;
        }

        // Metodo para agregar ventas al listado
        public List<Ventas> Agregar(List<Ventas> listadoVentas, Ventas ventaAgregar)
        {
            if (ventaAgregar.BuscarExistenciaNumeroVenta(ventaAgregar.NumeroVenta, listadoVentas) == false)
            {
                listadoVentas.Add(ventaAgregar);
                return listadoVentas;
            }
            return listadoVentas;
        }
    }
}