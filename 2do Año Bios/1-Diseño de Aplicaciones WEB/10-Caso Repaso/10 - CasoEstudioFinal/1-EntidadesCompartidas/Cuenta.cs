using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public class Cuenta
    {

       // atributos
       private int _NumCta;
       private Cliente _unCliente;
       private double _SaldoCta;


       //propiedades
       public int NumCta
       {
           get { return _NumCta; }
           set { _NumCta = value; }
       }

       public Cliente UnCliente
       {
           get { return _unCliente; }
           set {
                if (value == null)
                     {
                        throw new Exception("Aca hay error pari");
                     }
                else
                    _unCliente = value; }
       }

       public double SaldoCuenta
       {
           get { return _SaldoCta; }//propiedad solo lectura cuyo valor solo puede modificarse por una accion (altamov)
       }

       public virtual string TipoCuenta //virtual marca un elemento como candidato a ser sobre escrito en una derivada es decir se le puede asignar otro codigo diferente
            //el virtual no es exclusivo de las opp se puede aplicar a cualquier elemento que mantenga codigo asociado
       {
           get { return "No se";}
            //En las derivadas no se puede cambiar la estructura de la propiedad solo el valor get
       }


       //constructores
       public Cuenta(int pNumCta, Cliente pUnCliente, double pSaldoCuenta)
       {
           NumCta = pNumCta;
           UnCliente = pUnCliente;
           _SaldoCta = pSaldoCuenta;
       }

       public override string ToString()
       {
           return (this.NumCta.ToString().Trim() + " - " + this.UnCliente.NomCli + " - " + this.TipoCuenta);
       }
 
    }
}
