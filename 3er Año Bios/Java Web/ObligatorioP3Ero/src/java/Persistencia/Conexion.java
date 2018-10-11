/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Persistencia;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Bruno
 */
public class Conexion 
{

    private static String urlConexionBD;
    private static String usuarioBD;
    private static String claveAccesoBD;
    
    
    static {
        try {
            Class.forName("com.mysql.jdbc.Driver");
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(Conexion.class.getName()).log(Level.SEVERE, "No se pudo instanciar el driver JDBC.", ex);
        }
        
        urlConexionBD = "jdbc:mysql://localhost:3306/BdObligatorio";
        usuarioBD = "root";
        claveAccesoBD = "Bruno";
    }
    
    
    public static Connection getConexion() throws SQLException {
        return DriverManager.getConnection(urlConexionBD, usuarioBD, claveAccesoBD);
    } 
}
