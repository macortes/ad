using System;
using System.Reflection;

namespace PReflection
{
	class MainClass
	{
		public static void Main (string[] args)
		{
	/*		int i=10;
			Type type = i.GetType ();   //Tipo de i
			Console.WriteLine ("typeI.Name = {0}", type.Name);



			string s = "Hola mundo";
			Type types = s.GetType ();  // Tipo de String
			Console.WriteLine ("typeI.Name = {0}", types.Name);


			Type typeX = typeof(string);  //Typeof se aplica a l
			Console.WriteLine ("typeI.Name = {0}", typeX.Name);
			showType (typeX);   //Llamas al metodo que muestre el tipo
 */

			//Type typeFoo = typeof(Foo);  //tipo de la clase
			//showType (typeFoo);
			/*
			Type typeO = typeof(object);   //Tipo de los objetos ,Object no tiene base type
			showType (typeO);
			*/

			Articulo articulo = new Articulo ();    //Tipe de articulo

			showType(articulo.GetType());
			articulo.Nombre = "nuevo 33";
			articulo.Categoria = 2;
			articulo.Precio = decimal.Parse("3,5");
			showObject (articulo);
			setValues (articulo,
			          new object[]{33L,"nuevo 33 modificado",3L,decimal.Parse("33,33")});

		}

		private static void showType(Type type){
			Console.WriteLine ("type.Name = {0} type.Fullname{1} type.BaseType.Name{2}", 
			                   type.Name, type.FullName,type.BaseType.Name);

			PropertyInfo[] propertyInfos = type.GetProperties ();

			foreach (PropertyInfo propertyInfo in propertyInfos) {
				Console.WriteLine ("type.Name = {0}",propertyInfo.Name,propertyInfo.PropertyType);
			}


		}
		private static void showObject(object obj){   //Le pasas un objeto
			Type type = obj.GetType ();
			PropertyInfo[] propertyInfos = type.GetProperties ();
			foreach (PropertyInfo propertyInfo in propertyInfos) {
				Console.WriteLine ("{0}={1}",propertyInfo.Name,propertyInfo.GetValue(obj,null));  //null porque no recibe un array
			}
		}
		private static void setValues(object obj,object[] values){
			Type type = obj.GetType ();
			int index = 0;
			PropertyInfo[] propertyInfos = type.GetProperties ();
			foreach (PropertyInfo propertyInfo in propertyInfos) {
				propertyInfo.SetValue(obj,values[index++],null);  //null porque no recibe un array
			}
		}

	}

	public class Foo {
		private string name;
		private object id;


		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		public object Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}
	}
			public class Articulo
			{
				public Articulo ()
				{
				}

				private object id;
				private string nombre;
				private object categoria;
				private decimal precio;

				public object Id {
					get { 
						return id;
					}
					set { 
						id = value;
					}
				}

				public string Nombre {
					get {
						return nombre;
					}
					set { 
						nombre = value; 
					}
				}


				public object Categoria {
					get {
						return categoria;
					}
					set {
						categoria = value;
					}
				}


				public decimal Precio {
					get {
						return precio;
					}
					set {
						precio = value;
					}
				}
			}
}
