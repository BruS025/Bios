using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Part2
{
    public class Asociados
    {
        list<Socio> _Socios;

        public Asociados() { }

        public Asociados(list<Socio> Socios)
        {
            _Socios = Socios;
        }

        public Socios
	{
		get{return _Socios;}
    set{_Socios = value;}
	}

	public double CobroMes()
{
    double valor = 0;

    foreach (socio item in list<Socios>)
    {
        valor = valor + item.pagoMensual();
        return valor;
    }
}
}
