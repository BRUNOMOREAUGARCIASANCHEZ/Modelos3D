/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 07:59 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
namespace ProyectoFinal
{
	/// <summary>
	/// Description of Objetos.
	/// </summary>
	public class Objetos
	{
			//double [,] cubo={ {-1,-1,1}, {-1,1,1}, {-1,-1,-1}, {-1,1,-1}, {1,-1,1}, {1,1,1}, {1,-1,-1}, {1,1,-1} };
		//Punto [] cubo=new Punto[8];
		List<Punto> vertexArray;  
		List<Punto> textureArray;
		public Objetos()
		{
			vertexArray=new List<Punto>();
			textureArray=new List<Punto>();
		}
		
		
		
		public void cuadricula(){
			GL.Color3(0f,0f,0f);
			
			GL.Begin(PrimitiveType.Lines);
				for(int i=-10;i<=10;i++){
					GL.Vertex3(i,10,0);
					GL.Vertex3(i,-10,0);	
					
					GL.Vertex3(-10,i,0);
					GL.Vertex3(10,i,0);	
				}
				GL.End();
		}
		
		/*public void Cubo(Zbuffer buffer){

			//CARA AMARILLA-NARANJA
			Triangulo aux=new Triangulo(cubo[1],cubo[0],cubo[2]);
			aux.setColor(1,0.5,0);
			aux.textA=new Punto(0,0,0);
			aux.textB=new Punto(1,0,0);
			aux.textC=new Punto(1,1,0);
			buffer.agregarPol(aux);
			
			aux=new Triangulo(cubo[1],cubo[3],cubo[2]);
			aux.setColor(1,0.5,0);
			aux.textA=new Punto(1,0,0);
			aux.textB=new Punto(1,1,0);
			aux.textC=new Punto(0,1,0);
			buffer.agregarPol(aux);
			//CARA2
			
			//CARA ROJA
			aux=new Triangulo(cubo[5],cubo[4],cubo[6]);
			aux.setColor(1,0,0);
			aux.textA=new Punto(0,0,0);
			aux.textB=new Punto(1,0,0);
			aux.textC=new Punto(1,1,0);
			buffer.agregarPol(aux);
			 
			aux=new Triangulo(cubo[5],cubo[7],cubo[6]);
			aux.setColor(1,0,0);
			aux.textA=new Punto(1,0,0);
			aux.textB=new Punto(1,1,0);
			aux.textC=new Punto(0,1,0);
			buffer.agregarPol(aux);
			//CARA VERDE
			aux=new Triangulo(cubo[0],cubo[4],cubo[6]);
			aux.setColor(0,1,0);
			aux.textA=new Punto(0,0,0);
			aux.textB=new Punto(1,0,0);
			aux.textC=new Punto(1,1,0);
			buffer.agregarPol(aux);
			
			aux=new Triangulo(cubo[0],cubo[2],cubo[6]);
			aux.setColor(0,1,0);
			aux.textA=new Punto(1,0,0);
			aux.textB=new Punto(1,1,0);
			aux.textC=new Punto(0,1,0);
			buffer.agregarPol(aux);
			//CARA BLANCA
			aux=new Triangulo(cubo[5],cubo[1],cubo[3]);
			aux.setColor(1,1,1);
			aux.textA=new Punto(0,0,0);
			aux.textB=new Punto(1,0,0);
			aux.textC=new Punto(1,1,0);
			buffer.agregarPol(aux);
			
			aux=new Triangulo(cubo[5],cubo[7],cubo[3]);
			aux.setColor(1,1,1);
			aux.textA=new Punto(1,0,0);
			aux.textB=new Punto(1,1,0);
			aux.textC=new Punto(0,1,0);
			buffer.agregarPol(aux);
			//CARA NEGRA
			aux=new Triangulo(cubo[3],cubo[2],cubo[6]);
			aux.setColor(0,0,0);
			aux.textA=new Punto(0,0,0);
			aux.textB=new Punto(1,0,0);
			aux.textC=new Punto(1,1,0);
			buffer.agregarPol(aux);
			
			aux=new Triangulo(cubo[3],cubo[7],cubo[6]);
			aux.setColor(0,0,0);
			aux.textA=new Punto(1,0,0);
			aux.textB=new Punto(1,1,0);
			aux.textC=new Punto(0,1,0);
			buffer.agregarPol(aux);
			//CARA SUPERIOR
			aux=new Triangulo(cubo[5],cubo[4],cubo[0]);
			aux.setColor(1,0,1);
			aux.textA=new Punto(0,0,0);
			aux.textB=new Punto(1,0,0);
			aux.textC=new Punto(1,1,0);
			buffer.agregarPol(aux);
			
			aux=new Triangulo(cubo[5],cubo[1],cubo[0]);
			aux.setColor(1,0,1);
			aux.textA=new Punto(1,0,0);
			aux.textB=new Punto(1,1,0);
			aux.textC=new Punto(0,1,0);
			buffer.agregarPol(aux);
			
		}
		*/
		public void escalarFigura(double kx, double ky, double kz)
		{
			foreach (Punto element in this.vertexArray) {
				element.escalar(kx,ky,kz);
			}
		}
		
		public void trasladarFigura(double kx, double ky, double kz)
		{
			foreach (Punto element in this.vertexArray) {
				element.traslacion(kx,ky,kz);
			}
		}
		
		public void rotarFigX(double ang)
		{
			foreach (Punto element in this.vertexArray) {
				element.rotacionX(ang);
			}
		}
		
		public void rotarFigY(double ang)
		{
			foreach (Punto element in this.vertexArray) {
				element.rotacionY(ang);
			}
		}
		
		public void rotarFigZ(double ang)
		{
			foreach (Punto element in this.vertexArray) {
				element.rotacionZ(ang);
			}
		}
		
		public void setVertices(List<Punto> p)
		{
			this.vertexArray=p;
		}
		
		public void setTextura(List<Punto> p)
		{
			this.textureArray=p;
		}
		
		public Punto getVerice(int index)
		{
			return this.vertexArray[index];
;		}
		
		public Punto getCordTexture(int index)
		{
			return this.textureArray[index];
		}
		
		
		
	}
}
