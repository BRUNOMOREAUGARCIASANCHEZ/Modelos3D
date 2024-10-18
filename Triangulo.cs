/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 08:01 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace ProyectoFinal
{
	/// <summary>
	/// Description of Triangulo.
	/// </summary>
	public class Triangulo
	{
		Punto A,B,C,texturaA,texturaB,texturaC;
		Punto centroide;
		double red,green,blue;
		String textura;
		int iA,iB,iC;
		int tA,tB,tC;
		
		
		public Triangulo(String text)
		{
			A=B=C=texturaA=texturaB=texturaC=new Punto();
			this.textura=text;
			iA=iB=iC=tA=tB=tC=0;
		}
		
		public Triangulo(Punto a,Punto b, Punto c,String text)
		{
			this.A=new Punto(a.X,a.Y,a.Z);
			this.B=new Punto(b.X,b.Y,b.Z);
			this.C=new Punto(c.X,c.Y,c.Z);
			texturaA=texturaB=texturaC=new Punto();
			this.textura=text;
			iA=iB=iC=tA=tB=tC=0;
			
		}
		
		public Punto a 
		{
			set {this.a=value;}
			get{return this.a;}
		}
		
		public Punto b 
		{
			set {this.b=value;}
			get{return this.b;}
		}
		
		public Punto c 
		{
			set {this.c=value;}
			get{return this.c;}
		}
		
		public void setIndices(int a, int b, int c )
		{
			this.iA=a;
			this.iB=b;
			this.iC=c;
		}
		
		
		public void setText(int a, int b, int c )
		{
			this.tA=a;
			this.tB=b;
			this.tC=c;
		}
		
		public Punto textA 
		{
			set {this.texturaA=value;}
			get{return this.texturaA;}
		}
		
		public Punto textB
		{
			set {this.texturaB=value;}
			get{return this.texturaB;}
		}
		public Punto textC 
		{
			set {this.texturaC=value;}
			get{return this.texturaC;}
		}
		
		public Punto Centroide()
		{
			this.centroide=new Punto((A.X+B.X+C.X)/3,(B.Y+C.Y+A.Y)/3,(B.Z+C.Z+A.Z)/3);
			return this.centroide;
		}
		
		
		public void drawInd(Objetos basic)
		{	
			//Console.WriteLine(iA+" "+iB+" "+iC);
			this.A=basic.getVerice(iA);
			this.B=basic.getVerice(iB);
			this.C=basic.getVerice(iC);
			//this.centroide=new Punto((A.X+B.X+C.X)/3,(B.Y+C.Y+A.Y)/3,(B.Z+C.Z+A.Z)/3);
			//Console.WriteLine(tA+" "+tB+" "+tC);
			this.texturaA=basic.getCordTexture(tA);
			this.texturaB=basic.getCordTexture(tB);
			this.texturaC=basic.getCordTexture(tC);
			
			this.draw();
		}
		
		public void actualizarPuntos()
		{
		
		}
		
		public void draw()
		{
			GL.Enable(EnableCap.Texture2D);
			//GL.PointSize(5);
			//LATERALES
			//GL.Color3(this.red,this.green,this.blue);
			GL.Begin(PrimitiveType.Triangles);
			
			GL.TexCoord2(texturaA.X,texturaA.Y); //EL ORDEN DE LAS COORDENADAS IMPORTA
			GL.Vertex3(this.A.X,this.A.Y,this.A.Z);
			GL.TexCoord2(texturaB.X,texturaB.Y);
			GL.Vertex3(this.B.X,this.B.Y,this.B.Z);
			GL.TexCoord2(texturaC.X,texturaC.Y);
			GL.Vertex3(this.C.X,this.C.Y,this.C.Z);
			GL.End();
		}
		
		public void setColor(double rojo,double verde, double azul)
		{
			this.red=rojo;
			this.green=verde;
			this.blue=azul;
		}
		
		public void escalar(double kx, double ky, double kz)
		{
			this.A.escalar(kx,ky,kz);
			this.B.escalar(kx,ky,kz);
			this.C.escalar(kx,ky,kz);
		}
		
		public void trasladar(double kx, double ky, double kz)
		{
			this.A.traslacion(kx,ky,kz);
			this.B.traslacion(kx,ky,kz);
			this.C.traslacion(kx,ky,kz);
		}
		
		public void rotarZ(double ang)
		{
			this.A.rotacionZ(ang);
			this.B.rotacionZ(ang);
			this.C.rotacionZ(ang);
		}
		
		public void rotarX(double ang)
		{
			this.A.rotacionX(ang);
			this.B.rotacionX(ang);
			this.C.rotacionX(ang);
		}
		
		public void rotarY(double ang)
		{
			this.A.rotacionY(ang);
			this.B.rotacionY(ang);
			this.C.rotacionY(ang);
		}
		
		public void toString()
		{
			Console.WriteLine(A.X+", "+A.Y+", "+A.Z);
			Console.WriteLine(A.X+", "+B.Y+", "+B.Z);
			Console.WriteLine(C.X+", "+C.Y+", "+C.Z);
		}
	}
}
