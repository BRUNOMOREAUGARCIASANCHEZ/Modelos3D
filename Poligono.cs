/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 26/11/2022
 * Time: 01:58 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of Poligono.
	/// </summary>
	public class Poligono
	{
		List<Punto> vertices;
		List<Punto> texturas;
		Punto centroide;
		String textura;
		
		public Poligono(String texture)
		{
			this.texturas=new List<Punto>();
			this.vertices=new List<Punto>();
			this.centroide=new Punto();
			this.textura=texture;
		}
		
		public Poligono(double centroideX, double centroideY, double centroideZ, String txt)
		{
			this.texturas=new List<Punto>();
			this.vertices=new List<Punto>();
			this.centroide=new Punto(centroideX,centroideY,centroideZ);
			this.textura=txt;
		}
		
		public Poligono(Punto g, String txt)
		{
			this.texturas=new List<Punto>();
			this.vertices=new List<Punto>();
			this.centroide=g;
			this.textura=txt;
		}
		
		public void agregarPuntos(Punto vertice, Punto text)
		{
			vertices.Add(vertice);
			texturas.Add(text);
		}
		
		public Punto Centroide()
		{
			this.centroide=new Punto();
			return this.centroide;
		}
		

		
		public void draw()
		{
			GL.Enable(EnableCap.Texture2D);
			datosTextura imagen=LoadTexture.LoadTextureFile(this.textura);
			GL.Begin(PrimitiveType.Polygon);
			
			for(int i=0; i<vertices.Count;i++)
			{
				GL.TexCoord2(texturas[i].X,texturas[i].Y);
				GL.Vertex3(vertices[i].X,vertices[i].Y,vertices[i].Z);
			}
			GL.End();
		}
		
		public void escalar(double kx, double ky, double kz)
		{
			foreach (Punto p in vertices){
				p.escalar(kx,ky,kz);
			}
			this.centroide.escalar(kx,ky,kz);
		}
		
		public void trasladar(double kx, double ky, double kz)
		{
			foreach (Punto element in vertices) {
				element.traslacion( kx,  ky,  kz);
			}
			this.centroide.traslacion( kx,  ky,  kz);
		}
		
		public void rotarZ(double ang)
		{
			Console.WriteLine(vertices.Count);
			foreach (Punto element in vertices) {
				element.rotacionZ(ang);
			}
			this.centroide.rotacionZ(ang);
		}
		
		public void rotarX(double ang)
		{
			foreach (Punto element in vertices) {
				element.rotacionX(ang);
			}
			this.centroide.rotacionX(ang);
		}
		
		public void rotarY(double ang)
		{
			foreach (Punto element in vertices) {
				element.rotacionY(ang);
			}
			this.centroide.rotacionY(ang);
		}
		
	}
}
