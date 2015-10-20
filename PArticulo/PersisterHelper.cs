using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PArticulo
{
	public class PersisterHelper
	{

		public static QueryResult Get(string selectText) {
			IDbConnection dbConnection = App.Instance.DbConnection;
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = selectText;

			//TODO completar
			return null;
		}
		private string[] getColumnNames(IDataReader dataReader) {
			List<string> columnNames = new List<string> ();
			int count = dataReader.FieldCount;
			for (int index = 0; index < count; index++)
				columnNames.Add (dataReader.GetValue(index));
		
		}
	}
}

