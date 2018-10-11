/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package EntidadesCompartidas;

import java.io.Serializable;
import java.util.Date;


/**
 *
 * @author Bruno
 */
public class Servicio implements Serializable
{
    private int IdServicio ;
    private String Dispositivo;
    private String Marca;
    private String Problema;
    private String Modelo;
    private String Estado;
    private Date FechaHoraIn;
    private int Cedula;
    private String Nombre;
    private int Telefono;
    private Date FechaHoraRep;
    private Date FechaHoraEnt;

    public void setIdServicio(int IdServicio) {
        this.IdServicio = IdServicio;
    }
    public int getIdServicio() {
        return IdServicio;
    }

    public void setDispositivo(String Dispositivo) {
        this.Dispositivo = Dispositivo;
    }
    public String getDispositivo() {
        return Dispositivo;
    }

    public void setMarca(String Marca) {
        this.Marca = Marca;
    }
    public String getMarca() {
        return Marca;
    }

    public void setProblema(String Problema) {
        this.Problema = Problema;
    }
    public String getProblema() {
        return Problema;
    }

    public void setModelo(String Modelo) {
        this.Modelo = Modelo;
    }
    public String getModelo() {
        return Modelo;
    }

    public void setEstado(String Estado) {
        this.Estado = Estado;
    }
    public String getEstado() {
        return Estado;
    }

    public void setFechaHoraIn(Date FechaHoraIn) {
        this.FechaHoraIn = FechaHoraIn;
    }
    public Date getFechaHoraIn() {
        return FechaHoraIn;
    }

    public void setCedula(int Cedula) {
        this.Cedula = Cedula;
    }
    public int getCedula() {
        return Cedula;
    }

    public void setNombre(String Nombre) {
        this.Nombre = Nombre;
    }
    public String getNombre() {
        return Nombre;
    }

    public void setTelefono(int Telefono) {
        this.Telefono = Telefono;
    }
    public int getTelefono() {
        return Telefono;
    }

    public void setFechaHoraRep(Date FechaHoraRep) {
        this.FechaHoraRep = FechaHoraRep;
    }
    public Date getFechaHoraRep() {
        return FechaHoraRep;
    }

    public void setFechaHoraEnt(Date FechaHoraEnt) {
        this.FechaHoraEnt = FechaHoraEnt;
    }
    public Date getFechaHoraEnt() {
        return FechaHoraEnt;
    }

    public Servicio(int IdServicio, String Dispositivo, String Marca, String Problema, String Modelo, String Estado, Date FechaHoraIn, int Cedula, String Nombre, int Telefono, Date FechaHoraRep, Date FechaHoraEnt) {
        this.IdServicio = IdServicio;
        this.Dispositivo = Dispositivo;
        this.Marca = Marca;
        this.Problema = Problema;
        this.Modelo = Modelo;
        this.Estado = Estado;
        this.FechaHoraIn = FechaHoraIn;
        this.Cedula = Cedula;
        this.Nombre = Nombre;
        this.Telefono = Telefono;
        this.FechaHoraRep = FechaHoraRep;
        this.FechaHoraEnt = FechaHoraEnt;
    }
     
    public Servicio(){}
}
    

