package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.*;





public class PruebaArticulo {
	
	public static void main(String [] args) throws SQLException{
		
		Connection connection =  DriverManager.getConnection(  
				"jdbc:mysql://localhost/dbprueba","root","sistemas");   //Modo de conexion BBDD
		
		//System.out.println("fin");
	Scanner tec= new Scanner(System.in);
	System.out.println("Elige opcion");
	Statement stmt =(Statement)  connection.createStatement();
	int opcion;
		
			System.out.println("1. Leer");
			System.out.println("2. Nuevo");
			System.out.println("3. Editar ");
			System.out.println("4. Eliminar");
			System.out.println("5. ");
			System.out.println("");
			System.out.println("");
			opcion= tec.nextInt();
		
		
		switch(opcion){
		case 1:
			System.out.println("************SELECCION DE DATOS***********************");
			
			ResultSet rs = stmt.executeQuery("select * from articulo");
			while (rs.next()) {
				System.out.print(rs.getString("id"));
				System.out.print(". ");
			     System.out.println(rs.getString("nombre"));
			     
			}
			break;
		
		case 2:
			
			stmt.executeUpdate("INSERT INTO articulo " + "VALUES (1001, 'Simpson', 'Mr.', 'Springfield', 2001)");
	
		
		case 3:
			
			
			
		case 4:
			System.out.println("*************BORRADO DE DATOS****************");
			System.out.println("que id quieres borrar?");
			int id= tec.nextInt();
			stmt.execute("DELETE from articulo where id="+id);
			break;
		}
	
	
	
	
	//UPDATE
	
	
	//INSERCION DATOS 
	connection.close();
	

	
	
		}
		}
	
	

