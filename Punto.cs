/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 07:54 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.Drawing;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of Punto.
	/// </summary>
	public class Punto
	{
		double x;
		double y;
		double z;
		
		public Punto()
		{
			x=y=z=0;
		}
		
		public Punto(double X,double Y,double Z)
		{
			this.x=X;
			this.y=Y;
			this.z=Z;
		}
		
		public double X
		{
			get{return this.x;}
			set{x=value;}
		}
		
		public double Y
		{
			get{return this.y;}
			set{y=value;}
		}
		
		public double Z
		{
			get{return this.z;}
			set{z=value;}
		}
		
		public void rotacionZ(double ang)
		{
			//ang=ang*(Math.PI/180);
			//Console.WriteLine(Math.Cos(ang));
			this.x=(this.x*Math.Cos(ang))-(this.y*Math.Sin(ang));
			this.y=(this.x*Math.Sin(ang))+(this.y*Math.Cos(ang));
		}
		
		public void rotacionY(double ang)
		{
			this.x=(this.x*Math.Cos(ang))+(this.z*Math.Sin(ang));
			this.z=( this.z*Math.Cos(ang)-this.x*Math.Sin(ang) );
		}
		
		public void rotacionX(double ang)
		{
			this.y=(this.y*Math.Cos(ang))-(this.z*Math.Sin(ang));
			this.z=(this.y*Math.Sin(ang))+(this.z*Math.Cos(ang));
		}
		
		public void escalar(double kx, double ky, double kz)
		{
			this.x*=kx;
			//Console.WriteLine(x);
			this.y*=ky;
			//Console.WriteLine(y);
			this.z*=kz;
			//Console.WriteLine(z);
		}
		
		public void traslacion(double tx,double ty,double tz)
		{
			this.x+=tx;
			this.y+=ty;
			this.z+=tz;
		}
		public void write()
		{
			Console.WriteLine(this.x+" "+this.y+" "+this.z);
		}

	}
}
