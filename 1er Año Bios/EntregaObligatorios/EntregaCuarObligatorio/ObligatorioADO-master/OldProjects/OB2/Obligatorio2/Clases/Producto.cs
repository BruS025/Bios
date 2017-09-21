using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Clases
{
    public class Producto
    {
        // Atributos
        private long _codigoBarrasProducto;
        private string _nombreProducto;
        private DateTime _fechaVencimientoProducto;
        private double _precioProducto;

        // Constructor por defecto
        public Producto() { }

        // Constructor con parametros
        public Producto(long codigoBarrasProducto, string nombreProducto, DateTime fechaVencimientoProducto, double precioProducto)
        {
            _codigoBarrasProducto = codigoBarrasProducto;
            _nombreProducto = nombreProducto;
            _fechaVencimientoProducto = fechaVencimientoProducto;
            _precioProducto = precioProducto;
        }

        // Propiedades Código
        public long Código
        {
            get { return _codigoBarrasProducto; }
            set
            {
                if (value > 0)
                {
                    _codigoBarrasProducto = value;
                }
            }
        }

        // Propiedades Nombre
        public string Nombre
        {
            get { return _nombreProducto; }
            set
            {
                if (value.Trim().Length > 0)
                {
                    _nombreProducto = value;
                }
            }
        }

        // Propiedades Vencimiento
        public DateTime Vencimiento
        {
            get { return _fechaVencimientoProducto; }
            set { _fechaVencimientoProducto = value; }
        }

        // Propiedades Precio
        public double Precio
        {
            get { return _precioProducto; }
            set
            {
                if (value > 0)
                {
                    _precioProducto = value;
                }
            }
        }

        // Metodo para agregar productos al listado
        public List<Producto> Agregar(List<Producto> listadoProductos, Producto productoAgregar)
        {
            if (productoAgregar.BuscarExistenciaProducto(productoAgregar.Código, listadoProductos) == false)
            {
                listadoProductos.Add(productoAgregar);

                return listadoProductos;
            }

            return listadoProductos;
        }

        // Metodo para verificar existencia de un producto
        public bool BuscarExistenciaProducto(long codigo, List<Producto> listadoProductos)
        {
            foreach (var producto in listadoProductos)
            {
                if (producto.Código == codigo)
                {
                    return true;
                }
            }
            return false;
        }

        // Metodo para modificar listado de productos
        public List<Producto> Modificar(List<Producto> listadoProductos, Producto productoModificar)
        {
            foreach (var producto in listadoProductos) // Verificar en el listado de producto, chequea tipo de producto y busca existencia para modificar
            {
                if (producto is ProductoEnlatado)
                {               
                    if (producto.Código == productoModificar.Código)
                        {
                            producto.Código = productoModificar.Código;
                            producto.Nombre = productoModificar.Nombre;
                            producto.Precio = productoModificar.Precio;
                            producto.Vencimiento = productoModificar.Vencimiento;
                            ((ProductoEnlatado)producto).Abrefácil = ((ProductoEnlatado)productoModificar).Abrefácil;

                            return listadoProductos;
                        }
                }
                else
                {
                    if ( producto.Código == productoModificar.Código)
                    { 
                        producto.Código = productoModificar.Código;
                        producto.Nombre = productoModificar.Nombre;
                        producto.Precio = productoModificar.Precio;
                        producto.Vencimiento = productoModificar.Vencimiento;
                        ((ProductoCongelado)producto).Peso = ((ProductoCongelado)productoModificar).Peso;

                        return listadoProductos;
                    }
                }
            }

            return listadoProductos;
        }

        // Metodo para eliminar productos al listado
        public List<Producto> Eliminar(List<Producto> listadoProductos, Producto productoEliminar)
        {
            foreach (var producto in listadoProductos)
            {
                if (productoEliminar.BuscarExistenciaProducto(productoEliminar.Código, listadoProductos) == true)
                {
                    listadoProductos.Remove(producto);

                    return listadoProductos;
                }
            }

            return listadoProductos;
        }

        // Inicio busqueda de producto en listado
        public List<ProductoEnlatado> BuscarEnlatado (string coincidencia, List<Producto> listadoProductos)
        {
            List<ProductoEnlatado> listadoProductosBusqueda = new List<ProductoEnlatado>();

            // Tipo Long
            long numeroVerificarLong = 0;
            string stringVerificarLong = "";
            bool resultadoVerificarLong = false;

            stringVerificarLong = coincidencia;
            resultadoVerificarLong = Int64.TryParse(stringVerificarLong, out numeroVerificarLong); // Si es long retorna TRUE sino FALSE
            // Fin tipo Long

            // Inicio tipo Int
            int numeroVerificarInt = 0;
            string stringVerificarInt = "";
            bool resultadoVerificarInt = false;

            stringVerificarInt = coincidencia;
            resultadoVerificarInt = Int32.TryParse(stringVerificarInt, out numeroVerificarInt); // Si es int retorna TRUE sino FALSE
            // Fin tipo Int

            // Inicio tipo double
            double numeroVerificarDouble = 0;
            string stringVerificarDouble = "";
            bool resultadoVerificarDouble = false;

            stringVerificarDouble = coincidencia;
            resultadoVerificarDouble = Double.TryParse(stringVerificarDouble, out numeroVerificarDouble); // Si es double retorna TRUE sino FALSE
            // Fin tipo double

            // Inicio tipo date-time
            DateTime numeroVerificarDateTime;
            string stringVerificarDateTime = "";
            bool resultadoVerificarDateTime;

            stringVerificarDateTime = coincidencia;
            resultadoVerificarDateTime = DateTime.TryParse(stringVerificarDateTime,out numeroVerificarDateTime);
            // Fin tipo date-time

            // Inicio bool
            bool numeroVerificarBool;
            string stringVerificarBool = "";
            bool resultadoVerificarBool = false;

            stringVerificarDouble = coincidencia;
            resultadoVerificarBool = Boolean.TryParse(stringVerificarBool, out numeroVerificarBool);
            // Fin tipo bool


            if (resultadoVerificarLong == true) // Verificamos LONG INT y luego DOUBLE 
                {
                    if (resultadoVerificarInt == true)
                        {
                            if (resultadoVerificarDouble == true)
                                {
                                    foreach (var producto in listadoProductos) // Busqueda por: Codigo / Nombre / Precio (Caso sin decimal) va este
                                        {
                                            if (producto is ProductoEnlatado)
                                                {
                                                    if (producto.Código == Convert.ToInt64(coincidencia) || producto.Nombre == coincidencia || producto.Precio == Convert.ToDouble(coincidencia))
                                                        {
                                                            listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                                        }
                                                }
                                        }
                                }
                            else
                                {
                                    foreach (var producto in listadoProductos) // Busqueda por: Codigo / Nombre
                                        {
                                            if (producto is ProductoEnlatado)
                                                {
                                                    if (producto.Código == Convert.ToInt64(coincidencia) || producto.Nombre == coincidencia)
                                                        {
                                                            listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                                        }
                                                }
                                        }
                                }
                }
                    else
                        {
                            foreach (var producto in listadoProductos) // Busqueda por: Codigo / Nombre
                                {
                                    if (producto is ProductoEnlatado)
                                        {
                                            if (producto.Código == Convert.ToInt64(coincidencia) || producto.Nombre == coincidencia)
                                                {
                                                    listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                                }
                                        }
                                }
                        }
                }
            else if (resultadoVerificarDouble == true)
            {                
                foreach (var producto in listadoProductos) // Busqueda por: Nombre / Precio (Caso con decimal)
                    {
                        if (producto is ProductoEnlatado)
                            {
                                if ( producto.Nombre == coincidencia || producto.Precio == Convert.ToDouble(coincidencia))
                                {
                                    listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                }
                            }
                    }
                
            }
            else if (resultadoVerificarDateTime == true)
                {
                    foreach (var producto in listadoProductos) // Busqueda por: Nombre / Fecha vencimiento
                        {
                            if (producto is ProductoEnlatado)
                                {
                                    if (producto.Nombre == coincidencia || producto.Vencimiento == Convert.ToDateTime(coincidencia))
                                        {
                                            listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                        }
                                }
                        }
                }
            else
            {
                if (coincidencia == "true" || coincidencia == "false")
                    { 
                        foreach (var producto in listadoProductos) // Busqueda por: Nombre
                            {
                                if (producto is ProductoEnlatado)
                                    {
                                        if (producto.Nombre == coincidencia || ((ProductoEnlatado)producto).Abrefácil == Convert.ToBoolean(coincidencia))
                                            {
                                                listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                            }
                                    }
                            }
                    }
                else
                    {
                        foreach (var producto in listadoProductos) // Busqueda por: Nombre
                            {
                                if (producto is ProductoEnlatado)
                                    {
                                        if (producto.Nombre == coincidencia)
                                            {
                                                listadoProductosBusqueda.Add((ProductoEnlatado)producto);
                                            }
                                    }
                            }
                    }
            }                      
            return listadoProductosBusqueda;
        }
        // Fin busqueda de producto enlatado en listado

        // Inicio busqueda de producto en congelado
        public List<ProductoCongelado> BuscarCongelado(string coincidencia, List<Producto> listadoProductos)
        {
            List<ProductoCongelado> listadoProductosBusqueda = new List<ProductoCongelado>();

            // Tipo Long
            long numeroVerificarLong = 0;
            string stringVerificarLong = "";
            bool resultadoVerificarLong = false;

            stringVerificarLong = coincidencia;
            resultadoVerificarLong = Int64.TryParse(stringVerificarLong, out numeroVerificarLong); // Si es long retorna TRUE sino FALSE
            // Fin tipo Long

            // Inicio tipo Int
            int numeroVerificarInt = 0;
            string stringVerificarInt = "";
            bool resultadoVerificarInt = false;

            stringVerificarInt = coincidencia;
            resultadoVerificarInt = Int32.TryParse(stringVerificarInt, out numeroVerificarInt); // Si es int retorna TRUE sino FALSE
            // Fin tipo Int

            // Inicio tipo double
            double numeroVerificarDouble = 0;
            string stringVerificarDouble = "";
            bool resultadoVerificarDouble = false;

            stringVerificarDouble = coincidencia;
            resultadoVerificarDouble = Double.TryParse(stringVerificarDouble, out numeroVerificarDouble); // Si es double retorna TRUE sino FALSE
            // Fin tipo double

            // Inicio tipo date-time
            DateTime numeroVerificarDateTime;
            string stringVerificarDateTime = "";
            bool resultadoVerificarDateTime;

            stringVerificarDateTime = coincidencia;
            resultadoVerificarDateTime = DateTime.TryParse(stringVerificarDateTime, out numeroVerificarDateTime);
            // Fin tipo date-time

            if (resultadoVerificarLong == true)
            {
                if (resultadoVerificarInt == true)
                {
                    if (resultadoVerificarDouble == true)
                    {
                        foreach (var producto in listadoProductos) // Busqueda por: Codigo / Nombre / Precio (Caso sin decimal) / Peso (Caso sin decimal)
                        {
                            if (producto is ProductoCongelado)
                            {
                                if (producto.Código == Convert.ToInt64(coincidencia) || producto.Nombre == coincidencia || producto.Precio == Convert.ToDouble(coincidencia) || ((ProductoCongelado)producto).Peso == Convert.ToDouble(coincidencia) )
                                {
                                    listadoProductosBusqueda.Add((ProductoCongelado)producto);
                                }
                            }
                        }
                    }
                }            
                else
                    {
                        foreach (var producto in listadoProductos) // Busqueda por: Codigo / Nombre
                            {
                                if (producto is ProductoCongelado)
                                    {
                                        if (producto.Código == Convert.ToInt64(coincidencia) || producto.Nombre == coincidencia)
                                            {
                                                listadoProductosBusqueda.Add((ProductoCongelado)producto);
                                            }
                                    }
                            }
                    }
                
            }
            else if (resultadoVerificarDouble == true)
            {
                foreach (var producto in listadoProductos) // Busqueda por: Nombre / Precio (Caso con decimal) // Peso (Caso con decimal)
                {
                    if (producto is ProductoCongelado)
                    {
                        if (producto.Nombre == coincidencia || producto.Precio == Convert.ToDouble(coincidencia) || ((ProductoCongelado)producto).Peso == Convert.ToDouble(coincidencia) )
                        {
                            listadoProductosBusqueda.Add((ProductoCongelado)producto);
                        }
                    }
                }

            }
            else if (resultadoVerificarDateTime == true)
            {
                foreach (var producto in listadoProductos) // Busqueda por: Nombre / Fecha vencimiento
                {
                    if (producto is ProductoCongelado)
                    {
                        if (producto.Nombre == coincidencia || producto.Vencimiento == Convert.ToDateTime(coincidencia))
                        {
                            listadoProductosBusqueda.Add((ProductoCongelado)producto);
                        }
                    }
                }
            }
            else
                {
                    foreach (var producto in listadoProductos) // Busqueda por: Nombre
                        {
                            if (producto is ProductoCongelado)
                                {
                                    if (producto.Nombre == coincidencia)
                                        {
                                            listadoProductosBusqueda.Add((ProductoCongelado)producto);
                                        }
                                }
                        }
                }           
            return listadoProductosBusqueda;
        }
        // Fin busqueda de producto enlatado en listado
    }
}