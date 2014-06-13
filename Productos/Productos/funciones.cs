using System;
//using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

//cambiar el namespace por namespace mysqlConnect
	
namespace Productos
{ 

	public class funciones:MySQL
	{

		
		public funciones()
		{
		}
	
		//muestra los registros de la base de datos
		public void mostrarTodosp(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string idarticulos = myReader["idarticulos"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string marcar = myReader["marcar"].ToString();
	            string modelo = myReader["modelo"].ToString();
	           
	       }

            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}

		public void agregarbebida(string nombre,string marcar, string modelo){
			this.abrirConexion();
			string sql = "INSERT INTO `articulos` (`nombre` , `marcar` , `modelo` ) values ('"+ nombre +"','"+marcar+"','"+modelo+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();			
		}
		public void eliminarbebida(string selecionar){
			this.abrirConexion();
			string sql = "DELETE FROM bebidas WHERE(`id`='" + selecionar + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		public void editarbebida(string idar ,string nombre,string marcar, string modelo){
			this.abrirConexion();
			string sql ="UPDATE articulos SET `nombre`='"+nombre+"',`marcar`='"+marcar+"',`modelo`='"+modelo+"' WHERE (`idarticulos`='"+idar+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		private string querySelect(){
			return "SELECT * " +
	           	"FROM productos";
		}
		
		
		
	}
}
