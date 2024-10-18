/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 08:00 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of Vector.
	/// </summary>
	public class Vector
	{
		double x,y,z;
		
		public Vector()
		{
			x=y=z=0;
		}
		
		public Vector(double X, double Y, double Z)
		{
			this.x=X;
			this.y=Y;
			this.z=Z;
		}
		
		public Vector(Punto A, Punto B) //A= DESTINO     B=SALIDA
		{
			this.x=A.X-B.X;
			this.y=A.Y-B.Y;
			this.z=0;
		}
		
		public void setVector(double X, double Y, double Z)
		{
			this.x=X;
			this.y=Y;
			this.z=Z;
		}
		
		public double X 
		{
			set {this.x=value;}
			get{return this.x;}
		}
		
		public double Y 
		{
			set {this.y=value;}
			get{return this.y;}
		}
		
		public double Z 
		{
			set {this.z=value;}
			get{return this.z;}
		}
		
		public double pPunto(Vector v)
		{
			return ((this.x*v.X)+(this.y*v.Y)+(this.z*v.Z));
		}
		
		public double modulo()
		{
			return (Math.Sqrt(Math.Pow(this.x,2)+Math.Pow(this.y,2)+Math.Pow(this.z,2)));
		}
		
		public void mEscalar(double k)
		{
			this.x*=k;
			this.y*=k;
			this.z*=k;
		}
		
		public Vector pCruz(Vector segundo)
		{
			return	new Vector((y*segundo.Z-z*segundo.Y),-1*(x*segundo.Z-z*segundo.X),(x*segundo.Y-y*segundo.X));
		}
		
		
		public Vector vUnitario()
		{
			return new Vector(this.x/this.modulo(),this.y/this.modulo(),0);
		}
	}
}
