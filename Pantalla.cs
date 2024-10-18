/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 07:53 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace ProyectoFinal
{
	/// <summary>
	/// Description of Pantalla.
	/// </summary>
	public class Pantalla:GameWindow
	{
		//int [, ,] coordenadas={{5,5,10,},{150,150},{100,150},{150,100}};
		Objetos basico=new Objetos();
		Camara camara=new Camara(1.2,-1.2,1.2);
		Vector PosCamara=new Vector();
		Zbuffer zbuffer;
		int eje=0;
		FileReader lector=new FileReader();
		//datosTextura imagen;
		
		public Pantalla(int ancho,int alto) : base(ancho,alto) // :base(ancho.alto)
		{
			Title="INPUT"; // <- Estos errores pasan cuando usas un teclado con proporcionesw distintas al tuyo 
			//Width=ancho;
			//Height=alto;
		}
		//Carga de datos
		protected override void OnLoad(System.EventArgs evento)
		{
			GL.ClearColor(0f, 0f, 1f, 1f);
			GL.MatrixMode(MatrixMode.Projection);
			GL.Ortho(0,600,0,600,-1,1);
			PosCamara=camara.Posicion;
			zbuffer=new Zbuffer(PosCamara);
			GL.Enable(EnableCap.Texture2D);
		    //imagen=LoadTexture.LoadTextureFile("OIP.jpg");
		    //lector.LeerArchivo("untitled.obj");
		    lector.cargarFigura("Aya_30K.obj"," ",basico,zbuffer);
		    datosTextura imagen=LoadTexture.LoadTextureFile("aya.jpg");
		    //basico.escalarFigura(-1,0,0);
		    //basico.trasladarFigura(0,-1,0);
		    for (int i=1;i<66;i++)
		    	basico.rotarFigX(0.02);
		    
		}
		//Actualizar datos
		protected override void OnUpdateFrame(FrameEventArgs e){
			//base.OnUpdateFrame(e);
			//camara.rotar(rotacion=(rotacion+0.00001)%(Math.PI*2));
			//PosCamara=camara.Posicion;
			//Console.WriteLine(rotacion);
			
			GL.Clear(ClearBufferMask.ColorBufferBit); //Limpiar Buffer	
			Matrix4 PuntoVision=Matrix4.LookAt((float)PosCamara.X,(float)PosCamara.Y,(float)PosCamara.Z,0,0,0,0,0,1);	//POSISION, PUNTO DE MIRA, DIRECCION
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref PuntoVision);
			
			zbuffer.actualizarCam(PosCamara);
			this.zbuffer.ordenar();
		}
		
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0,0,Width,Height); //PLANO DE PROYECCION
			float RelacionAspecto=(float) Width/Height;
			Matrix4 campoVision= Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2,RelacionAspecto,1,10);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref campoVision);
		}
		
		//Mostrar datos
		protected override void OnRenderFrame(FrameEventArgs evento){
			//base.OnRenderFrame(e);
			
			//GL.Rotate(rotacion,0,0,1);
			//CUADRICULA
			
			basico.cuadricula();
//			//EJES
			GL.Color3(1f,1f,1f);
			
			GL.Begin(PrimitiveType.Lines);
			GL.Vertex3(0,0,0);
			GL.Vertex3(1,0,0);
//			
			GL.Vertex3(0,0,0);
			GL.Vertex3(0,2,0);
			
			GL.Vertex3(0,0,0);
			GL.Vertex3(0,0,1);
				
			GL.End();

			this.zbuffer.renderizar(basico);
			
			SwapBuffers();
			
		}
		

		public static double distancia(Punto A, Punto B){
			return Math.Sqrt(Math.Pow((A.X-B.X),2)+Math.Pow((A.Y-B.Y),2)+Math.Pow((A.Z-B.Z),2));
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			//if(e.KeyChar=='q'){Exit();}
			
			//TRASLACION
			if((e.KeyChar=='w')||(e.KeyChar=='W'))
			{
				basico.trasladarFigura(0,0.2,0);
				//zbuffer.trasladarFigura(-0.2,0,0);
			}
			if((e.KeyChar=='d')||(e.KeyChar=='D'))
			{
				basico.trasladarFigura(0.2,0,0);
				
				//zbuffer.trasladarFigura(0,0.2,0);
			}
			if((e.KeyChar=='a')||(e.KeyChar=='A'))
			{
				basico.trasladarFigura(-0.2,0,0);
				//zbuffer.trasladarFigura(0,-0.2,0);
			}
			if((e.KeyChar=='s')||(e.KeyChar=='S'))
			{
				
				basico.trasladarFigura(0,-0.2,0);
				//zbuffer.trasladarFigura(0.2,0,0);		
			}
			if((e.KeyChar=='q')||(e.KeyChar=='Q'))
			{
				basico.trasladarFigura(0,0,-0.2);
				//zbuffer.trasladarFigura(0,0,-0.2);		
			}
			if((e.KeyChar=='e')||(e.KeyChar=='E'))
			{
				basico.trasladarFigura(0,0,0.2);
				//zbuffer.trasladarFigura(0,0,0.2);
			}
			//ESCALADO
			if((e.KeyChar=='m')||(e.KeyChar=='M'))
			{
				basico.escalarFigura(2,2,2);
				//zbuffer.escalarFigura(2,2,2);
			}
			if((e.KeyChar=='N')||(e.KeyChar=='n'))
			{
				basico.escalarFigura(0.5, 0.5, 0.5);
				//zbuffer.escalarFigura(0.5, 0.5, 0.5);
				//Console.WriteLine(1/2);???
			}
			
			
		}
		
		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			switch (eje) {
				case 0:
					//basico.rotarCuboZ(2*((rotacion+=2)%(Math.PI/2)));
					//zbuffer.rotarFiguraZ(0.02);
					if(e.Delta<0)
						basico.rotarFigZ(0.02);
					if(e.Delta>0)
						basico.rotarFigZ(-0.02);
					break;
				case 1:
					
					if(e.Delta<0)
						basico.rotarFigX(0.02);
					if(e.Delta>0)
						basico.rotarFigX(-0.02);
					//zbuffer.rotarFiguraX(0.02);
					//Console.WriteLine(giros++);
					break;
				case 2:
					
					if(e.Delta<0)
						basico.rotarFigY(0.02);
					if(e.Delta>0)
						basico.rotarFigY(-0.02);
					//zbuffer.rotarFiguraY(0.02);
					break;	
				default:
					
					break;
			}
		}
		
		protected override void OnMouseDown(MouseButtonEventArgs E)
		{
			eje=(eje+1)%3;
		}
		
		protected override void OnMouseMove(MouseMoveEventArgs e)
		{
			
		}

	}
}
