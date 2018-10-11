/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Beans;

import java.io.Serializable;

/**
 *
 * @author Bruno
 */
public class Producto implements Serializable
{
    private int codigo;
    private String descripcion;
    private float precio;
    private int stock;
    
    public Producto (int codigo, String descripcion, float precio, int stock)
    {
        setCodigo(codigo);
        setDescripcion(descripcion);
        setPrecio(precio);
        setStock(stock);
    }
    
    public Producto()
    {
        this(1 ,"N/D" ,0,0);
    }
        
    public int getCodigo() {
        return codigo;
    }

    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public double getPrecio() {
        return precio;
    }

    public void setPrecio(float precio) {
        this.precio = precio;
    }
    public void setStock(int stock)
    {
        this.stock = stock;
    }
    public int getStock(int stock)
    {
        return stock;
    }
}
