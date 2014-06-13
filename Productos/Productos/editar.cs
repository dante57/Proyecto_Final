/*
 * Created by SharpDevelop.
 * User: juancarlos
 * Date: 13/06/2014
 * Time: 02:32 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Productos
{
	/// <summary>
	/// Description of editar.
	/// </summary>
	public partial class editar : Form
	{
		private MainForm Mf;
		private string idar;
		public editar(MainForm Mf, string idar )
		{
			this.Mf=Mf;
			this.idar=idar;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CheckedListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			funciones fun=new funciones();
			fun.editarbebida(this.idar,this.textBox1.Text.Trim(),this.textBox2.Text.Trim(),this.textBox3.Text.Trim());
			this.Mf.actualizarTabla();
			this.Dispose();
		}
	}
}
