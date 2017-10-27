/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:14 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Clases_Abstractas;

/*Clase Alumno:
 Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
 Sobreescribirá el método MostrarDatos con todos los datos del alumno.
 ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
 ToString hará públicos los datos del Alumno.
 Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
 Un Alumno será distinto a un EClase sólo si no toma esa clase*/

namespace Clases_Instanciables
{	
	public sealed class Alumno:Universitario
	{
		public enum EEstadoCuenta{
			Deudor, Becado, AlDia
		}
		
		private Universidad.EClases _clasesQueToma;
		private EEstadoCuenta _estadoCuenta;
		
		public Alumno()
		{
		}
        /// <summary>
        /// constructor alumno
        /// </summary>
        /// <param int="id"></param>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param string="dni"></param>
        /// <param ENacionalidad="nacionalidad"></param>
        /// <param EClases="claseQueToma"></param>
		public Alumno(int id,string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad) {
			this._clasesQueToma=claseQueToma;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param int="id"></param>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param string="dni"></param>
        /// <param ENacionalidad="nacionalidad"></param>
        /// <param EClases="claseQueToma"></param>
        /// <param EEstadoCuenta="estadoCuenta"></param>
		public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, claseQueToma) {
			this._estadoCuenta=estadoCuenta;
		}
		
		
		protected override string MostrarDatos(){			
			return string.Format("{0}\n estado de cuenta= {1}\n clase que toma= {2}\n", base.MostrarDatos(),this._estadoCuenta, this._clasesQueToma);
		}
		
		public override string ToString()
		{
			return string.Format("{0}", this.MostrarDatos());
		}

        #region Equals implementation
        /// <summary>
        /// chequea que un alumno tome una clase y no sea deudor
        /// </summary>
        /// <param Alumno="a1"></param>
        /// <param EClases="ec1"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Alumno a1, Universidad.EClases ec1){
			if (a1._clasesQueToma==ec1&&a1._estadoCuenta!=EEstadoCuenta.Deudor) {
				return true;
		    }
			return false;
		}
		public static bool operator !=(Alumno a1, Universidad.EClases ec1){
			return (!(a1==ec1));			
		}
		#endregion
		
		protected override string ParticiparEnClase(){
			return string.Format("TOMA CLASE DE {0}", this._clasesQueToma);
		}
	}
}
