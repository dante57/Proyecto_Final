/*
 * Created by SharpDevelop.
 * User: juancarlos
 * Date: 13/06/2014
 * Time: 12:17 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Productos
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private MySqlCommand myCmdQuery;
		private MySqlDataAdapter myDataAdapter;
		private BindingSource myBindingSource;
		private MySqlCommandBuilder myCommandBuilder;
		private DataSet myDataSet;
		private MySqlConnection myConnection;
		private string myStringCon;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			
			this.myCmdQuery= new MySqlCommand();
			this.myDataAdapter=new MySqlDataAdapter();
			this.myBindingSource=new BindingSource();
			this.myCommandBuilder =new MySqlCommandBuilder();
			this.myDataSet=new DataSet();
			this.myStringCon=
				"Server=localhost;" +
				"Database=productos;" +
				"User ID=root;" +
				"Password=devilnevercry;" +
				"Pooling=false;";
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		public void actualizarTabla(){
			try{
				this.myDataSet.Clear();
				this.myDataAdapter.Fill(this.myDataSet,"articulos");
				this.myBindingSource.DataSource=this.myDataSet;
				this.myBindingSource.DataMember="articulos";
				this.myDataGrid.DataSource=this.myBindingSource;
				this.myDataGrid.Update();
				this.myDataGrid.Refresh();
			}catch(MySqlException ex){
				MessageBox.Show(ex.Message);
			}
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			Agregar agre=new Agregar(this);
			agre.Show();
			
		} 
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.myConnection = new MySqlConnection(this.myStringCon);
			try{
				this.myConnection.Open();
			}catch(MySqlException ex){
				MessageBox.Show(ex.Message);
				System.Environment.Exit(1);
			}

			this.myCmdQuery.CommandText="SELECT * FROM articulos";
			this.myCmdQuery.CommandType=CommandType.Text;
			this.myCmdQuery.Connection=this.myConnection;

			this.myDataAdapter.SelectCommand=this.myCmdQuery;
			this.myCommandBuilder.DataAdapter=this.myDataAdapter;

			//Llenar el dataset
			this.myDataAdapter.Fill(this.myDataSet,"articulos");
			this.myBindingSource.DataSource=this.myDataSet;
			this.myBindingSource.DataMember="articulos";
			this.myDataGrid.DataSource=this.myBindingSource;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
    string selectionar = myDataGrid.CurrentRow.Cells[0].Value.ToString();
     
    this.eliminar(selectionar);
    actualizarTabla();
    //funciones fun=new funciones();
    //fun.eliminarbebida(this,selectionar);
        
		}
		private void eliminar(String id){
			String sql ="DELETE FROM articulos WHERE(`idarticulos`='" + id + "')";
			this.ejecutarComando(sql);
			
				
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			this.actualizarTabla();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string idar = myDataGrid.CurrentRow.Cells[0].Value.ToString();
			editar edi=new editar(this, idar);
			edi.Show();
		}
	}
}
