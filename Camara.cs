/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 07:55 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of Camara.
	/// </summary>
	public class Camara
	{
		Vector posicion;
		
		public Camara(double x,double y, double z)
		{
			this.posicion=new Vector(x,y,z);
		}
		
		public Vector Posicion 
		{
			set {this.posicion=value;}
			get{return this.posicion;}
		}
		
		public void rotar(double angulo)
		{
			this.posicion=new Vector(posicion.X*Math.Cos(angulo)+Posicion.Y*Math.Sin(angulo),posicion.Y*Math.Cos(angulo)-Posicion.X*Math.Sin(angulo),posicion.Z);
		}
		

	}
}
