using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{

    public class PEnlatado : Producto
    {
        //Atributos
        private bool _abreFacil;

        //Costructor Completo
        public PEnlatado(int pCod, string pNom, DateTime pFecha, double pPrecio, bool pAbreFacil)
            : base(pCod, pNom, pFecha, pPrecio)
        {
            AbreFacil = pAbreFacil;
        }

        //Propiedades
        public bool AbreFacil
        {
            get { return _abreFacil; }
            set { _abreFacil = value; }
        }

        //ToString()
        public override string ToString()
        {

            return ("ENLATADO - " + base.ToString() + " , Abre Fácil: " + AbreFacil.ToString());
        }
    }

}