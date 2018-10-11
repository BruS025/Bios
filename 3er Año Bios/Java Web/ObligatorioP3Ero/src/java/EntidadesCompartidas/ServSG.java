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
public class ServSG extends Servicio
{
    private String Diagnostico;
    private Date FechaHoraDiag;
    private int Presupuesto;
    private boolean Aceptado;
    private Date FechaHoraAcep;

    public String getDiagnostico() {
        return Diagnostico;
    }
    public void setDiagnostico(String Diagnostico) {
        this.Diagnostico = Diagnostico;
    }


    public Date getFechaHoraDiag() {
        return FechaHoraDiag;
    }
    public void setFechaHoraDiag(Date FechaHoraDiag) {
        this.FechaHoraDiag = FechaHoraDiag;
    }

    public int getPresupuesto() {
        return Presupuesto;
    }
    public void setPresupuesto(int Presupuesto) {
        this.Presupuesto = Presupuesto;
    }

    public boolean isAceptado() {
        return Aceptado;
    }
    public void setAceptado(boolean Aceptado) {
        this.Aceptado = Aceptado;
    }

    public Date getFechaHoraAcep() {
        return FechaHoraAcep;
    }
    public void setFechaHoraAcep(Date FechaHoraAcep) {
        this.FechaHoraAcep = FechaHoraAcep;
    }

    public ServSG(String Diagnostico, Date FechaHoraDiag, int Presupuesto, boolean Aceptado, Date FechaHoraAcep, int IdServicio, String Dispositivo, String Marca, String Problema, String Modelo, String Estado, Date FechaHoraIn, int Cedula, String Nombre, int Telefono, Date FechaHoraRep, Date FechaHoraEnt) {
        super(IdServicio, Dispositivo, Marca, Problema, Modelo, Estado, FechaHoraIn, Cedula, Nombre, Telefono, FechaHoraRep, FechaHoraEnt);
        this.Diagnostico = Diagnostico;
        this.FechaHoraDiag = FechaHoraDiag;
        this.Presupuesto = Presupuesto;
        this.Aceptado = Aceptado;
        this.FechaHoraAcep = FechaHoraAcep;
    }
    public ServSG(String Diagnostico, Date FechaHoraDiag, int Presupuesto, boolean Aceptado, Date FechaHoraAcep) {
        this.Diagnostico = Diagnostico;
        this.FechaHoraDiag = FechaHoraDiag;
        this.Presupuesto = Presupuesto;
        this.Aceptado = Aceptado;
        this.FechaHoraAcep = FechaHoraAcep;
    }

    
}
