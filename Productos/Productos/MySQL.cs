/*
 * Created by SharpDevelop.
 * User: juancarlos
 * Date: 13/06/2014
 * Time: 12:17 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Productos

{
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL ()
		{
		}

		protected void abrirConexion(){
			string connectionString =
          		"Server=localhost;" +
	          	"Database=productos;" +
	          	"User ID=root;" +
	          	"Password=devilnevercry;" +
	          	"Pooling=false;";
	       this.myConnection = new MySqlConnection(connectionString);
	       this.myConnection.Open();
		}

		protected void cerrarConexion(){
			this.myConnection.Close(); 
			this.myConnection = null;
		}
	}
}