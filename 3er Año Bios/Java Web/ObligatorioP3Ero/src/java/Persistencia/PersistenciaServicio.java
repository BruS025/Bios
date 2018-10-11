/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Persistencia;



import EntidadesCompartidas.ServCG;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.Date;
import java.sql.SQLException;
import static java.sql.Types.INTEGER;
/**
 *
 * @author Bruno
 */
public class PersistenciaServicio implements IPersistenciaServicio 
{
    
    private static PersistenciaServicio instancia;
    
    
    public static PersistenciaServicio getInstancia() 
    {
        if (instancia == null) {
            instancia = new PersistenciaServicio();
        }
        
        return instancia;
    }

    private PersistenciaServicio() {}
    
    public int AgregarCG(ServCG servcg) throws SQLException
    {
        PersistenciaServicio CG = null;
        
        Connection conexion = null;
        CallableStatement consulta = null;
        try
        {
            conexion = Conexion.getConexion();
            conexion.setAutoCommit(false);
            
            consulta = conexion.prepareCall("{ ? = CALL AltaServCG(?,?,?,?,?,?,?,?,?,?,?,?) }");
            
            int p = 0;
            
            consulta.registerOutParameter(++p,java.sql.Types.INTEGER);
            consulta.setInt(++p,servcg.getIdServicio());
            consulta.setString(++p,servcg.getDispositivo());
            consulta.setString(++p,servcg.getMarca());
            consulta.setString(++p,servcg.getProblema());
            consulta.setString(++p,servcg.getModelo());
            consulta.setString(++p,servcg.getEstado());
            consulta.setDate(++p, (Date) servcg.getFechaHoraIn());
            consulta.setInt(++p,servcg.getCedula());
            consulta.setString(++p,servcg.getNombre());
            consulta.setInt(++p,servcg.getTelefono());
            consulta.setDate(++p, (Date) servcg.getFechaHoraRep());
            consulta.setDate(++p, (Date) servcg.getFechaHoraEnt());
            
            consulta.executeUpdate();
            
            int valor = consulta.getInt(p);
            
            return valor;
        }
        catch (SQLException ex) 
        {
            throw ex;
        }
        finally
        {
            conexion.close();
        }       
    }
}
