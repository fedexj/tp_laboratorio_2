/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 20/10/2017
 * Time: 10:16 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Archivos
{	
	public interface IArchivo<T> where T : class	        
	{
		bool guardar(string archivo, T datos);
		bool leer(string archivo, out T datos);
	}
}
