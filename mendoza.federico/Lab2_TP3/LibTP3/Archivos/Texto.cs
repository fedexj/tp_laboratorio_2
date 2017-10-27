/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 20/10/2017
 * Time: 10:23 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Excepciones;


namespace Archivos
{
	public class Texto: IArchivo<string>
	{
		public Texto(){			
		}

        /// <summary>
        /// Guarda archivos en formato string
        /// </summary>
        /// <param string="archivo"></param>
        /// <param string="datos"></param>
        /// <returns>bool</returns>
		public bool guardar(string archivo, string datos){		
			try{
				StreamWriter sWriter = new StreamWriter(archivo);			
				sWriter.Write(datos);
	            sWriter.Close();
	            return true;
			}
			catch (Exception e){		
				throw new ArchivosException("error en guardado de Archivo", e);
			}      
		}
        /// <summary>
        /// lee archivos txt
        /// </summary>
        /// <param string="archivo"></param>
        /// <param string="datos"></param>
        /// <returns>boolreturns>
        public bool leer(string archivo, out string datos){
			try{
				StreamReader sReader = new StreamReader(archivo);
                datos = sReader.ReadToEnd();                 
                sReader.Close();
                return true;
			}
			catch(Exception e){				
				throw new ArchivosException("error en lectura de Archivo", e);
			}			    
        }
		
	}
}
