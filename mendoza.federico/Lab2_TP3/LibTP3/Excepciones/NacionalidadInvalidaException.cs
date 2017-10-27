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
	/// Description of NacionalidadInvalidaException.
	/// </summary>
	public class NacionalidadInvalidaException:Exception
	{
		  public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número de DNI")
        {
        }
        public NacionalidadInvalidaException(string message)
            : base("La nacionalidad no se condice con el número de DNI: " + message)
        {
        }
	}
}
