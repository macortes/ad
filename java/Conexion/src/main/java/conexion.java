
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.mysql.jdbc.Statement;

//import com.mysql.jdbc.Statement;


public class conexion {
	public static void main(String [] args) throws SQLException{
		
		Connection connection =  DriverManager.getConnection(  
				"jdbc:mysql://localhost/dbprueba","root","sistemas");   //Modo de conexion BBDD
		
		System.out.println("fin");
		
		//select 
		
		
		//insertar datos
		PreparedStatement stmt = connection.prepareStatement("insert into articulo(id,nombre,categoria,precio)values(?,?,?,?)");
		stmt.setInt(1,3);
		stmt.setString(2,"articulo 1");
		stmt.setInt(3,1);
		stmt.setFloat(4, (float) 12.5);
		
		stmt.executeUpdate();
		
		//delete
		PreparedStatement stmt1 = connection.prepareStatement("delete from  articulo where id=?");
		stmt1.setInt(1,1);
		stmt1.executeUpdate();
		
		
		
		
		
	}
}
	