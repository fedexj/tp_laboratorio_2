/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:11 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Excepciones
{
	/// <summary>
	/// Description of ArchivosException.
	/// </summary>
	public class ArchivosException:Exception
	{
		public ArchivosException(string mensaje, Exception innnerException):base(mensaje, innnerException)			
		{
		}
	}
}
