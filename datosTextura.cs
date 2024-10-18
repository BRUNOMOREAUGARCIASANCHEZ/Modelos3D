/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 07:56 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of datosTextura.
	/// </summary>
	public class datosTextura
	{
		readonly int id;
		readonly int ancho;
		readonly int alto;
		
		public datosTextura(int ID, int An, int Al)
		{
			this.id=ID;
			this.ancho=An;
			this.alto=Al;
		}
		
		public int ID
		{
			get {return this.id;}
		}
		
		public int width
		{
			get {return this.ancho;}
		}
		
		public int height
		{
			get {return this.alto;}
		}
	}
}
