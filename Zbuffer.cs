/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 08:01 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of Zbuffer.
	/// </summary>
	public class Zbuffer
	{
		//List<Triangulo> buffer;
		//SYSYTEM.COLECTION.GERNERIC
		List<Triangulo> buffer;
		Punto posCamara;
		
		public Zbuffer(Vector camara)
		{
			this.buffer=new List<Triangulo>();
			this.posCamara=new Punto(camara.X,camara.Y,camara.Z);
		}
		
		public void agregarT(Triangulo t)
		{
			//agrega un triangulo
			buffer.Add(t);
		}
		
		public void ordenar()
		{
			//oredenamiento de acuerdo a la distancia entre el centroide del triangulo y la POSICION DE LA CAMARA	
			buffer.Sort(compararCentroides);
			
		}
		
		
		public void renderizar(Objetos basic)
		{
			//Console.WriteLine(buffer.Count);
			//se renderiza el arreglo actual.
			if(buffer.Count!=0){
				buffer.ForEach(delegate(Triangulo tri)
				{
				  	tri.drawInd(basic);
				});		
			}
		}
		
		public int compararCentroides(Triangulo A, Triangulo B){
			if(Pantalla.distancia(A.Centroide(),this.posCamara)==Pantalla.distancia(B.Centroide(),this.posCamara))
			{
				return 0;
			}else if(Pantalla.distancia(A.Centroide(),this.posCamara)>Pantalla.distancia(B.Centroide(),this.posCamara))
			{
				return -1;
			}else 
				return 1;
		}
		
		public void actualizarCam(Vector camara)
		{
			this.posCamara=new Punto(camara.X,camara.Y,camara.Z);
		}

		
		public void escalarFigura(double kx, double ky, double kz)
		{
			foreach (Triangulo element in buffer) {
				element.escalar(kx,ky,kz);
			}
		}
		
		public void trasladarFigura(double kx, double ky, double kz)
		{
			foreach (Triangulo element in buffer) {
				element.trasladar(kx,ky,kz);
			}
		}
		
		public void rotarFiguraX(double ang)
		{
			foreach (Triangulo element in buffer) {
				element.rotarX(ang);
			}
		}
		
		public void rotarFiguraY(double ang)
		{
			foreach (Triangulo element in buffer) {
				element.rotarY(ang);
			}
		}
		
		public void rotarFiguraZ(double ang)
		{
			
			foreach (Triangulo element in buffer) {
				//element.toString();
				element.rotarZ(ang);
			}
			
//			for(int i=0; i<buffer.Count;i++)
//			{
//				buffer[i].rotarZ(ang);
//			}
		}
		
	}
}
