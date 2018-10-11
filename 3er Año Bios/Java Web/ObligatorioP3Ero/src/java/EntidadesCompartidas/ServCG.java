/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package EntidadesCompartidas;

import java.util.Date;

/**
 *
 * @author Bruno
 */
public class ServCG extends Servicio
{
    
    private int NroServicio ;

    public int getNroServicio() {
        return NroServicio;
    }
    public void setNroServicio(int NroServicio) {
        this.NroServicio = NroServicio;
    }

    public ServCG(int NroServicio, int IdServicio, String Dispositivo, String Marca, String Problema, String Modelo, String Estado, Date FechaHoraIn, int Cedula, String Nombre, int Telefono, Date FechaHoraRep, Date FechaHoraEnt) {
        super(IdServicio, Dispositivo, Marca, Problema, Modelo, Estado, FechaHoraIn, Cedula, Nombre, Telefono, FechaHoraRep, FechaHoraEnt);
        this.NroServicio = NroServicio;
    }
    public ServCG(int NroServicio) {
        this.NroServicio = NroServicio;
    }
   
}
