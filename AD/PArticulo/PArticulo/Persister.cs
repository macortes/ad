using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;


namespace PArticulo
{
	public class Persister
	{
		private const string INSERT_SQL="insert into {0} {{1}} values {{2}}";
		public static int insert(object obj){
			//			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			//			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
			//				"values (@nombre, @categoria, @precio)";
			//			DbCommandHelper.AddParameter (dbCommand, "nombre", articulo.Nombre);
			//			DbCommandHelper.AddParameter (dbCommand, "categoria", articulo.Categoria);
			//			DbCommandHelper.AddParameter (dbCommand, "precio", articulo.Precio);
			//		 	return dbCommand.ExecuteNonQuery ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = getinsertSql (obj.GetType ());
			addParameters (dbCommand, obj);
			return dbCommand.ExecuteNonQuery ();

			//Recojo tipo
			Type type = obj.GetType ();


			//insercion de datos
			string insertSql = getinsertSql (type);
		}
		private static void addParameters(IDbCommand dbCommand,object obj){
			Type type = obj.GetType ();
			PropertyInfo[] propertyinfos = type.GetProperties ();
			foreach (PropertyInfo propertyinfo in propertyinfos) {
				if(!propertyinfo.Name.Equals("Id"));
				string name = propertyinfo.Name.ToLower();
				object value= propertyinfo.GetValue(obj,null);
				bCommandHelper.AddParameter (dbCommand,name,value);

			}

		}


		private static String getinsertSql(Type type){
			//Para las tablas en nombre en minuscula
			string tableName = type.Name.ToLower ();

			//llamas al metodo para coger los campos
			string[] fieldNames = getFieldNames (type);

			//lammas al metodo para los parametros
			string[] paramNames = getParamNames(fieldNames); 

			return string.Format(INSERT_SQL,tableName,string.Join(",",fieldNames),string.Join(",",paramNames));



		}
		//metodo recoger campos
		private static string[] getFieldNames(Type type){
			//SE CREA UNA LISTA PARA LOS CAMPOS
			List<string> fieldNames = new List<string> ();

			//recoges los valores en un array que es getProperties
			PropertyInfo[] propertyInfos = type.GetProperties ();

			//lo recorres uy si es igual a la id para la insercion
			foreach (PropertyInfo propertyInfo in propertyInfos) 
				if (!propertyInfo.Name.Equals ("Id")) 
					fieldNames.Add (propertyInfo.Name.ToLower ());  //CONVENCION EN MINUSCULA
			return fieldNames.ToArray ();


		}
		//RECOGER LOS PARAMETROS

		private static string[] getParamNames(string [] fieldNames){
			List<string> paramNames = new List <string> ();
			foreach (string fieldName in fieldNames){
				paramNames.Add ("@", fieldName);

			}
			return paramNames.ToArray();


		}






	}
}

