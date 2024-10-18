/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 26/11/2022
 * Time: 12:51 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of FileReader.
	/// </summary>
	public class FileReader
	{
		public FileReader()
		{
		}
		
		public void LeerArchivo(String nombreArchivo) //LA DIRECCION TAMBIEN FUNCIONA COMO PARAMETRO
		{
			String line;
			try
			{
			    //Pass the file path and file name to the StreamReader constructor
			    StreamReader sr = new StreamReader(nombreArchivo);
			    //Read the first line of text
			    line = sr.ReadLine();
			    //Continue to read until you reach end of file
			    while (line != null)
			    {
			    	String[] arreglo=line.Split();
			    	if(arreglo[0]=="v")
			    	{
			    		Console.WriteLine(line);
//			    		foreach (String s in arreglo) {
//			    			Console.WriteLine(s);
//			    		}
			    	}
			    	
			    	//Console.WriteLine("*");
			        //write the line to console window
			        //Console.WriteLine(line);
			        //Read the next line
			        line = sr.ReadLine();
			        
			    }
			    //close the file
			    sr.Close();
			    //Console.ReadLine();
			    
			}
			catch(Exception e)
			{
			    Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
			    Console.WriteLine("Executing finally block.");
			}
		}
		
		public void cargarFigura(String nombreArchivo, String textura, Zbuffer buffer) //LA DIRECCION TAMBIEN FUNCIONA COMO PARAMETRO
		{
			String line;
			List<Punto> vertexArray=new List<Punto>();
			List<Punto> textureArray=new List<Punto>();
			List<Punto> poligono=new List<Punto>();
			List<Punto> textpoligono=new List<Punto>();
				
			try
			{
				
			    //Pass the file path and file name to the StreamReader constructor
			    StreamReader sr = new StreamReader(nombreArchivo);
			    //Read the first line of text
			    line = sr.ReadLine();
			    //Continue to read until you reach end of file
			    while (line != null)
			    { 
			    	
			    	String[] arreglo=line.Split();
			    	if(arreglo[0]=="v")
			    	{
			    		vertexArray.Add(new Punto(Convert.ToDouble(arreglo[1]),Convert.ToDouble(arreglo[2]),Convert.ToDouble(arreglo[3])));
			    	}
			    	Console.WriteLine(line);
//			    	if(arreglo[0]=="vn")
//			    	{
//			    		centroides.Add(new Punto(Convert.ToDouble(arreglo[1]), Convert.ToDouble(arreglo[2]),Convert.ToDouble(arreglo[3])));
//			    	}
			    	
			    	if(arreglo[0]=="vt")
			    	{
			    		textureArray.Add(new Punto(Convert.ToDouble(arreglo[1]), 1-Convert.ToDouble(arreglo[2]),0));
			    	}
			    	
			    	if(arreglo[0]=="f")
			    	{
			    		
			    		for(int i=1; i<arreglo.Length;i++)
			    		{
			    			string[] indices=arreglo[i].Split('/');
			    			poligono.Add(vertexArray[Convert.ToInt32(indices[0])-1]);
			    			//Console.WriteLine(vertexArray[Convert.ToInt32(indices[0])-1].X + " "+vertexArray[Convert.ToInt32(indices[0])-1].Y+" "+vertexArray[Convert.ToInt32(indices[0])-1].Z);
			    			textpoligono.Add(textureArray[Convert.ToInt32(indices[1])-1]);
			    			//Console.WriteLine(textureArray[Convert.ToInt32(indices[1])-1].X+" "+textureArray[Convert.ToInt32(indices[1])-1].Y+" "+textureArray[Convert.ToInt32(indices[1])-1].Z);
			    			//aux.agregarPuntos(vertexArray[Convert.ToInt32(indices[0])-1], textureArray[Convert.ToInt32(indices[1])-1]);
//			    			Console.WriteLine(indices[0]);
//			    			Console.WriteLine(indices[1]);
//			    			Console.WriteLine(indices[2]);
			    		}
			    		for (int i=2;i<poligono.Count;i++){
			    			Triangulo aux=new Triangulo(poligono[0],poligono[i-1],poligono[i],textura);
			    			aux.textA=textpoligono[0];
			    			aux.textB=textpoligono[i-1];
			    			aux.textC=textpoligono[i];
			    			buffer.agregarT(aux);	
			    		}
			    		poligono.Clear();
			    		textpoligono.Clear();
			    		
			    		
			    		//Console.WriteLine(arreglo.Length);
			    		//String[] indices
			    	}
			    	
			    	//Console.WriteLine("*"); 
			        //write the line to console window
			        //Console.WriteLine(line);
			        //Read the next line
			        line = sr.ReadLine();
			        
			    }
			    //close the file
			    sr.Close();
			    //Console.ReadLine();
			    
			}
			catch(Exception e)
			{
			    Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
			    Console.WriteLine("Executing finally block.");
			}
		}
		
		public void cargarFigura(String nombreArchivo, String textura, Objetos basic,Zbuffer buffer) //LA DIRECCION TAMBIEN FUNCIONA COMO PARAMETRO
		{
			String line;
			List<Punto> vertexArray=new List<Punto>();
			List<Punto> textureArray=new List<Punto>();
			List<int> poligono=new List<int>(); //SOLO CONTIENEN INDICES
			List<int> textpoligono=new List<int>();
				
			try
			{
				
			    //Pass the file path and file name to the StreamReader constructor
			    StreamReader sr = new StreamReader(nombreArchivo);
			    //Read the first line of text
			    
			    line = sr.ReadLine();
			    
			    //Continue to read until you reach end of file
			    while (line != null)
			    {
			    	
			    	line=line.Replace("  "," ");
			    	String[] arreglo=line.Split();
			    	//Console.WriteLine(line);
			    	if(arreglo[0]=="v")
			    	{
			    		//Console.WriteLine("  oskoaskd");	
			    		
			    		if(arreglo[1]==" ")
			    			vertexArray.Add(new Punto(Convert.ToDouble(arreglo[2]), Convert.ToDouble(arreglo[3]),Convert.ToDouble(arreglo[4])));
				    	else{
			    			//Console.WriteLine(arreglo[1]);	
			    			vertexArray.Add(new Punto(Convert.ToDouble(arreglo[1]), Convert.ToDouble(arreglo[2]),Convert.ToDouble(arreglo[3])));
				    	}
		    		
			    	}
			  			
			    	
			    	if(arreglo[0]=="vt")
			    	{	
			    		textureArray.Add(new Punto(Convert.ToDouble(arreglo[1]),1-Convert.ToDouble(arreglo[2]),0));
			    		//Console.WriteLine(Convert.ToDouble(arreglo[1])+" "+Convert.ToDouble(arreglo[2]));
			    		
			    	}
			    	
			    	if(arreglo[0]=="f")
			    	{
			    		
			    		for(int i=1; i<arreglo.Length;i++)
			    		{
			    			if (arreglo[i].Equals("")) {
			    				
			    			}else{
			    				//Console.WriteLine("F");
				    			string[] indices=arreglo[i].Split('/');
				    			poligono.Add(Convert.ToInt32(indices[0])-1);
				    			//Console.WriteLine(vertexArray[Convert.ToInt32(indices[0])-1].X + " "+vertexArray[Convert.ToInt32(indices[0])-1].Y+" "+vertexArray[Convert.ToInt32(indices[0])-1].Z);
				    			textpoligono.Add(Convert.ToInt32(indices[1])-1);
				    			//Console.WriteLine(Convert.ToInt32(indices[1])-1);
				    			//Console.WriteLine(textureArray[Convert.ToInt32(indices[1])-1].X+" "+textureArray[Convert.ToInt32(indices[1])-1].Y+" "+textureArray[Convert.ToInt32(indices[1])-1].Z);
				    			//aux.agregarPuntos(vertexArray[Convert.ToInt32(indices[0])-1], textureArray[Convert.ToInt32(indices[1])-1]);
	//			    			Console.WriteLine(indices[0]);
	//			    			Console.WriteLine(indices[1]);
	//			    			Console.WriteLine(indices[2]);
			    			}
			    		}
			    		for (int i=2;i<poligono.Count;i++){
			    			Triangulo aux=new Triangulo(textura);
			    			aux.setIndices(poligono[0],poligono[i-1],poligono[i]);			    			
			    			//Console.WriteLine(poligono[0]+" "+poligono[i-1]+" "+poligono[i]);
			    			aux.setText(textpoligono[0],textpoligono[i-1],textpoligono[i]);
			    			//Console.WriteLine(textpoligono[0]+" "+textpoligono[i-1]+" "+textpoligono[i]);
			    			buffer.agregarT(aux);	
			    		}
			    		poligono.Clear();
			    		textpoligono.Clear();
			    		
			    		
			    		//Console.WriteLine(arreglo.Length);
			    		//String[] indices
			    	}
			    	
			    	//Console.WriteLine("*"); 
			        //write the line to console window
			        //Console.WriteLine(line);
			        //Read the next line
			        line = sr.ReadLine();
			        
			    }
			    //close the file
			    sr.Close();
			    //Console.ReadLine();
			    basic.setVertices(vertexArray);
			    basic.setTextura(textureArray);
//			    
//			    foreach ( Punto p in textureArray) {
//			    	p.write();
//			    }
			    
			}
			catch(Exception e)
			{
				
			    Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
			    Console.WriteLine("Executing finally block.");
			}
		}
		
	}
}
