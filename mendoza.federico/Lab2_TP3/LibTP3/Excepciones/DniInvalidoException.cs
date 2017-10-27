/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:10 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Excepciones
{
	/// <summary>
	/// Description of DniInvalidoException.
	/// </summary>
	public class DniInvalidoException:Exception
	{
		
		static string mensajeBase = "El DNI ingresado no es un número válido.";
		
        public DniInvalidoException()
            : base (mensajeBase)
        {

        }
        public DniInvalidoException(string message)
            : this(message, null)
        {

        }
        public DniInvalidoException(Exception e)
            : base(mensajeBase, e)
        {

        }
        public DniInvalidoException(string message, Exception e)
            : base(mensajeBase + message, e)
        {

        }
	}
}

