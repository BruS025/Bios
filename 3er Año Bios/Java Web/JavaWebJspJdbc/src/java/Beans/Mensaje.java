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
public class Mensaje implements Serializable
{
    public int idMen;

    public Mensaje(int idMen) 
    {
        setIdMen (idMen);
    }

    public Mensaje()
    {
        this(1);
    }
    public int getIdMen() 
    {
        if(idMen >= 0)
        {
            ++idMen;
        }
        if(idMen == 10)
        {
            idMen=0;
        }
        return idMen;
    }

    public void setIdMen(int idMen) 
    {
        this.idMen = idMen;
    }
}

