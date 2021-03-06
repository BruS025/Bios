﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPlato
    {
        public static Plato Buscar(int id, long rut)
        {
            return PersistenciaPlato.Buscar(id, rut);
        }

        public static int Agregar(Plato plato, long rut)
        {
            return PersistenciaPlato.Agregar(plato, rut);
        }

        public static int Modificar(Plato plato, long rut)
        {
            return PersistenciaPlato.Modificar(plato, rut);
        }

        public static int Eliminar(int id, long rut)
        {
            return PersistenciaPlato.Eliminar(id,rut);
        }

        public static List<Plato> Listar(long rut)
        {
            return PersistenciaPlato.Listar(rut);
        }

        public static List<Plato> ListarPedido(int id, long rut)
        {
            return PersistenciaPlato.ListarPedido(id,rut);
        }
    }
}
