package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.mysql.jdbc.Statement;

//import com.mysql.jdbc.Statement;


public class PruebaArticulo {
	public static void main(String [] args) throws SQLException{
		
		Connection connection =  DriverManager.getConnection(  
				"jdbc:mysql://localhost/dbprueba","root","sistemas");   //Modo de conexion BBDD
		
		//System.out.println("fin");
	
	
	//SELECT 
	System.out.println("************SELECCION DE DATOS***********************");
	Statement stmt = (Statement) connection.createStatement();
	ResultSet rs = stmt.executeQuery("select * from articulo");
	while (rs.next()) {
	     System.out.println(rs.getString("nombre"));
	}
	
	//INSERCION DATOS 
	
	
	
	
	connection.close();
	
	}
}
