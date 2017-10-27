/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:15 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * 
 * Clase Profesor:
 Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
 Sobrescribir el método MostrarDatos con todos los datos del pROFESOR.
 ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
 ToString hará públicos los datos del Profesor.
 Se inicializará a Random sólo en un constructor.
 En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor
mediante el método randomClases. Las dos clases pueden o no ser la misma.
 Un Profesor será igual a un EClase si da esa clase.
 */
using System;
using Clases_Abstractas;
using System.Collections.Generic;


namespace Clases_Instanciables
{
	public sealed class Profesor:Universitario
	{
		private Queue<Universidad.EClases> _clasesDelDia;		
		private static Random _random;
		
		public Profesor(){
		}		
		static Profesor(){
			Profesor._random=new Random();
		}
        /// <summary>
        /// constructor profesor
        /// </summary>
        /// <param int="id"></param>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param string="dni"></param>
        /// <param ENacionalidad="nacionalidad"></param>
		public Profesor(int id,string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad){
			_clasesDelDia=new Queue<Universidad.EClases>();
			_clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0,3));
			_clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0,3));			
		}
        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase(){
			string returnList;
			returnList=string.Format("DA CLASES DE ");
			foreach (Universidad.EClases element in this._clasesDelDia) {				
				returnList+=string.Format(" {0} ", element);				
			}
			return returnList;
		}
		
		protected override string MostrarDatos(){			
			return string.Format("{0}\n clase que toma= {1}\n", base.MostrarDatos(),this.ParticiparEnClase());
		}
		
		public override string ToString()
		{
			return string.Format("{0}", this.MostrarDatos());
		}

        #region Equals implementation

        /// <summary>
        ///  Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param Profesor="p1"></param>
        /// <param EClases="ec1"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Profesor p1, Universidad.EClases ec1){
				if (p1._clasesDelDia.Contains(ec1)) {
				return true;
		    }
			return false;
		}
		public static bool operator !=(Profesor p1, Universidad.EClases ec1){
			return (!(p1==ec1));			
		}
		#endregion
	}
}
