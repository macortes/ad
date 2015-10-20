using System;   //lamp para iniciar el servidor
using MySql.Data.MySqlClient;   //se usa para abrir archivos de la bbdd 
using System.Collections.Generic;
namespace pmysql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"  //cadena de conexion
				);
			mySqlConnection.Open ();    //abrir
			MySqlCommand r= mySqlConnection.CreateCommand ();
			r.CommandText = "select * from articulo";   //consulta
			MySqlDataReader mysqlDataReader = r.ExecuteReader ();

			updateDatabase (mySqlConnection);


		//	while (mysqlDataReader.Read()) {
		//		Console.WriteLine ("id={0} nombre={1}", mysqlDataReader ["id"], mysqlDataReader ["nombre"]); 
		//	}

			showColumNames(mysqlDataReader);
			show (mysqlDataReader);

			mysqlDataReader.Close ();
			mySqlConnection.Close ();

		}
		private static void showColumNames(MySqlDataReader mysqlDataReader){

			 // SOLUCION YO 
			int columns = mysqlDataReader.FieldCount;
			//Console.Write (columns);

			for (int i=0; i < columns; i++) {
				Console.Write (mysqlDataReader.GetName(i)+"        ");
			} 


//			// OTRA OPCION
//			int count = mysqlDataReader.FieldCount;  //cuenta  las columnas
//			List<string> columnNames = new List<string> ();  //crea una lista
//			for (int i=0; i< count; i++) {    //la recorre
//				columnNames.Add (mysqlDataReader.GetName (i));
			return columnNames.ToArray ();
//			}






//			/* SOLUCION PROFESOR
//			int columns = mysqlDataReader.FieldCount;
//			String [] columnNames = new string[columns];
//			for (int i=0; i<columns;i++){
//				columnNames [i] = mysqlDataReader.GetName (i);
//		}*/


		}
		private static void show(MySqlDataReader mysqlDataReader){
			Console.WriteLine ();
			while (mysqlDataReader.Read()) {
				Console.WriteLine ("{0}         {1}", mysqlDataReader ["id"], mysqlDataReader ["nombre"]); 
			}
		}
		private static void updateDatabase(MysqlConnection mysqlConnection){
			MySqlCommand mysqlCommand = mysqlConnection.CreateCommand();
			mysqlCommand.CommandText = "update articulo set categoria=null where id=4";
			mysqlCommand.ExecuteNonQuery ();
		
		}
	}
}
