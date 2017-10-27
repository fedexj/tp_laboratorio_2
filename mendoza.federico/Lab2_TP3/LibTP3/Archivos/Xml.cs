/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 20/10/2017
 * Time: 10:15 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
	
	[Serializable]	
	public class Xml<T>:IArchivo<T> where T:class
	{
		public Xml(){}
        /// <summary>
        /// guarda archivos en xml
        /// </summary>
        /// <param string="archivo"></param>
        /// <param T="datos"></param>
        /// <returns>bool</returns>
		public bool guardar(string archivo, T datos){
			try{				
				XmlTextWriter writer;  //Objeto que escribirá en XML.
				XmlSerializer ser;     //Objeto que serializará.			
				writer = new XmlTextWriter(archivo,  System.Text.Encoding.UTF8);
				//Se indica ubicación del archivo XML y su codificación.
				ser = new XmlSerializer(typeof(T));
				//Se indica el tipo de objeto ha serializar.
				ser.Serialize(writer, datos);
				//Serializa el objeto p en el archivo contenido en writer.
				writer.Close();
				//Se cierra el objeto writer.
				return true;
			}
			catch(Exception e){
				throw new ArchivosException("error en guardado de Archivo", e);
			}
			

		}
        /// <summary>
        /// lee archivos xml
        /// </summary>
        /// <param string="archivo"></param>
        /// <param T="datos"></param>
        /// <returns>bool</returns>
		public bool leer(string archivo, out T datos){		
			try{
				XmlTextReader reader;   //Objeto que leerá XML.
				XmlSerializer ser;            //Objeto que Deserializará.
				
				reader = new XmlTextReader(archivo);
				//Se indica ubicación del archivo XML.
				ser = new XmlSerializer(typeof(T));
				//Se indica el tipo de objeto ha serializar.
				datos = (T) ser.Deserialize(reader);
				//Deserializa el archivo contenido en reader, lo guarda 
				//en aux.
				reader.Close();
				//Se cierra el objeto reader.
				return true;
			}
			catch(Exception e){
				throw new ArchivosException("error en lectura de Archivo", e);
			}
			

		}
	
	}
}