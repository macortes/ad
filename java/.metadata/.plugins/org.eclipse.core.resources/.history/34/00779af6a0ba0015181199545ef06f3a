package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.text.DecimalFormat;
import java.text.ParseException;
import java.util.Scanner;


public class PruebaArticuloProfe {
	private enum Action {Salir,Nuevo,Editar,Eliminar,Consultar,Listar};
	private static Scanner tec= new Scanner(System.in);
	
	private static Action scanAction(){
		while(true){
			System.out.print("0-Salir 1-Nuevo 2-Editar 3-Eliminar 4-Consultar 5-Listar ");
			String accion= tec.nextLine().trim(); //Quita espacios en blanco .trim()
			if(accion.matches("[012345]")){   //Que este entre esos numeros
				return Action.values()[Integer.parseInt(accion)];  //Parsear la accion
			}
			System.out.println("Opcion invalida.");
		
		}
		//return Action.Salir;
	}
	
	//CLASE PRIVADA ARTICULO PARA COGER LOS DATOS
	private static class Articulo{
		private long id;
		private String nombre;
		private long categoria;
		private BigDecimal precio;
	}
	
	private static String scanString(String label){
		System.out.println(label);
		return tec.nextLine().trim();
	}
	private static long scanLong(String label){
		while(true){
		System.out.println(label);
		//VALIDAR FORMATO LONG
		String data = tec.nextLine().trim();
		try{
			return Long.parseLong(data);
		}catch(NumberFormatException ex){
			System.out.println("debe ser un numero ");
		}
		}
	}
	private static BigDecimal scanBigDecimal(String label){
		while(true){
		System.out.println(label);
		String data = tec.nextLine().trim();
		DecimalFormat decimalFormat = (DecimalFormat)DecimalFormat.getInstance();
		decimalFormat.setParseBigDecimal(true);
		try{
			return (BigDecimal)decimalFormat.parse(data);
		}catch(ParseException e){
			System.out.println("Debe ser un numero decimal");
		}
		
		
		
		}
		
		
		
	}

	
	private static Articulo scanArticulo(){
		Articulo articulo = new Articulo();
		articulo.nombre = scanString("    Nombre:  ");
		articulo.categoria = scanLong("   Categoria: ");
		articulo.precio = scanBigDecimal("    Precio:  ");
		
		return articulo;
		
	}
	private void showArticulo(Articulo articulo) {
		System.out.println(" id"+articulo.id);
		System.out.println("  nombre"+articulo.nombre);
		System.out.println("   categoria"+articulo.categoria);
		System.out.println("   precio"+articulo.precio);
	}
	private static void showException(Exception e){
		System.out.println(e.getMessage());
	}
	
	private static Connection connection;
	
	private static  PreparedStatement insertPreparedStatement;
	private final static String insertSql = "insert into articulo (nombre,categoria,precio) values (?,?,?)";
	
	private static void Nuevo(){
		Articulo articulo = scanArticulo();
		try{
		 if(insertPreparedStatement ==null){
			 insertPreparedStatement = connection.prepareStatement(insertSql);
		}
		 insertPreparedStatement.setString(1,articulo.nombre);
		 insertPreparedStatement.setLong(2, articulo.categoria);
		 insertPreparedStatement.setBigDecimal(3,articulo.precio);
		 insertPreparedStatement.execute();
		}catch(SQLException e){
			showException(e);
		}
		
		
	}
	public static void main(String[] args) throws SQLException {
		// TODO Auto-generated method stub
		
	  Connection connection =  DriverManager.getConnection(  
				"jdbc:mysql://localhost/dbprueba","root","sistemas");   //Modo de conexion BBDD
	  
	
		while(true){
			Action action=	scanAction();
			if (action==Action.Salir){
				break;
			}
			
		if(action==Action.Nuevo)
			Nuevo();

			
		
		}connection.close();
		
	}

}
