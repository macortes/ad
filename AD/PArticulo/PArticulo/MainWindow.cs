using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Gtk;

using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Console.WriteLine ("MainWindow ctor.");

		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		//TODO usar el queryResult 

		IDbConnection dbConnection = App.Instance.DbConnection;
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";

		IDataReader dataReader = dbCommand.ExecuteReader ();
//		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
//		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		string[] columnNames = getColumnNames (dataReader);
		CellRendererText cellRendererText = new CellRendererText ();
		for (int index = 0; index < columnNames.Length; index++) {
			//treeView.AppendColumn (columnNames [index], cellRendererText, "text", index);
			int column = index;
			treeView.AppendColumn (columnNames [index], cellRendererText, 
				delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					IList row = (IList)tree_model.GetValue(iter, 0);
					cellRendererText.Text = row[column].ToString();
			});
		}

		//ListStore listStore = new ListStore (typeof(String), typeof(String));
		//Type[] types = getTypes (dataReader.FieldCount);
		ListStore listStore = new ListStore (typeof(IList));

		while (dataReader.Read()) {
			//listStore.AppendValues (dataReader [0].ToString(), dataReader [1].ToString());
			IList values = getValues (dataReader);
			listStore.AppendValues (values);
		}

		dataReader.Close ();

		treeView.Model = listStore;

		dbConnection.Close ();
	}

	private string[] getColumnNames(IDataReader dataReader) {
		List<string> columnNames = new List<string> ();
		int count = dataReader.FieldCount;
		for (int index = 0; index < count; index++)
			columnNames.Add (dataReader.GetName (index));
		return columnNames.ToArray ();
	}

	private Type[] getTypes(int count) {
		List<Type> types = new List<Type> ();
		for (int index = 0; index < count; index++)
			types.Add (typeof(string));
		return types.ToArray ();
	}

	private IList getValues(IDataReader dataReader) {
		List<object> values = new List<object> ();
		int count = dataReader.FieldCount;
		for (int index = 0; index < count; index++)
			values.Add (dataReader [index]);
		return values;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
