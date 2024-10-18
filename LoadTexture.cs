/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 24/11/2022
 * Time: 07:58 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace ProyectoFinal
{
	/// <summary>
	/// Description of LoadTexture.
	/// </summary>
	public class LoadTexture
	{
		public LoadTexture()
		{
		}
		
		public static datosTextura LoadTextureFile(string archivo)
		{
			int id=GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D,id);
			if(!File.Exists(archivo))
			{
				throw new FileNotFoundException("EL {0} no ha sido encontrado",archivo);
			}
			
			Bitmap mapaBits= new Bitmap(archivo);
			BitmapData datos= mapaBits.LockBits(new Rectangle(0,0,mapaBits.Width,mapaBits.Height),
			                                 ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb
			                                 );
			GL.TexImage2D(TextureTarget.Texture2D,0,PixelInternalFormat.Rgb,datos.Width,datos.Height,0,
			             OpenTK.Graphics.OpenGL.PixelFormat.Bgr,PixelType.UnsignedByte,datos.Scan0);
			mapaBits.UnlockBits(datos);
			GL.TexParameter(TextureTarget.Texture2D,TextureParameterName.TextureWrapS,(int)TextureWrapMode.Clamp);
			GL.TexParameter(TextureTarget.Texture2D,TextureParameterName.TextureWrapT,(int)TextureWrapMode.Clamp);
			
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,(int)TextureMinFilter.NearestMipmapLinear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,(int)TextureMinFilter.Linear);
			
			return new datosTextura(id,mapaBits.Width,mapaBits.Height);
		}

	}
}
