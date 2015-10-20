using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace SerpisAd
{
	public class PersisterHelper
	{

		public static QueryResult Get(string selectText) {
			IDbConnection dbConnection = App.Instance.DbConnection;  //Para conectarme
			IDbCommand dbCommand = dbConnection.CreateCommand ();   //creo el dbcomando
			dbCommand.CommandText = selectText; 
			//TODO completar
			QueryResult queryResult = new QueryResult ();
			//queryResult.ColumnNames = new string[] { "Columna 1", "Columna 2" };
			IDataReader dataReader= dbCommand.ExecuteReader ();
			queryResult.ColumnNames= getColumnNames( dataReader);

			List<IList> rows = new List<IList> ();


			//rows.Add (new object[] { 1, "art. uno" });
			//rows.Add (new object[] { 2, "art. dos" });
			while (dataReader.Read())
				rows.Add(getRow (dataReader));

			queryResult.Rows = rows;
			return queryResult;
		}

		private static string[] getColumnNames(IDataReader dataReader) {
			List<string> columnNames = new List<string> ();
			int count = dataReader.FieldCount;
			for (int index = 0; index < count; index++)
				columnNames.Add (dataReader.GetName (index));
			return columnNames.ToArray ();
		}

		private static IList getRow(IDataReader dataReader) {
			List<object> values = new List<object> ();
			int count = dataReader.FieldCount;
			for (int index = 0; index < count; index++)
				values.Add (dataReader [index]);
			return values;
		}
	}
}

