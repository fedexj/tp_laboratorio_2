/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:02 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * 
 * Clase Universitario:
 Abstracta, con el atributo Legajo.
 Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
 Método protegido y abstracto ParticiparEnClase.
 Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
 */
using System;


namespace Clases_Abstractas
{	
	public abstract class Universitario:Persona
	{
		private int _legajo;
		public Universitario()
		{
		}
        /// <summary>
        /// constructor universitario
        /// </summary>
        /// <param int="legajo"></param>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param string="dni"></param>
        /// <param ENacionalidad="nacionalidad"></param>
		public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, dni, nacionalidad) {
			this._legajo= legajo;
		}


        #region Equals implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param Universitario="pg1"></param>
        /// <param Universitario="pg2"></param>
        /// <returns>true mismo universitario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2){
			
			if (pg1.GetType()==pg2.GetType()&&pg1._legajo==pg2._legajo&&pg1.DNI==pg2.DNI) {
				return true;
		    }
			return false;
		}
		public static bool operator !=(Universitario pg1, Universitario pg2){
			return (!(pg1==pg2));			
		}
        /// <summary>
        /// equals implementa ==
        /// </summary>
        /// <param object="obj"></param>
        /// <returns>bool</returns>
		public override bool Equals(object obj)
		{
			Universitario other = obj as Universitario;
            if (ReferenceEquals(other, null)) {
                return false;
            }
			return (this==other);
		}
        #endregion

        #region metodos 
        /// <summary>
        /// Muesta datos en forma de string
        /// </summary>
        /// <returns>string</returns>
        protected virtual string MostrarDatos(){
			string str=base.ToString();
			return string.Format("{0}\n Legajo={1}\n", str, this._legajo);
		}
		protected abstract string ParticiparEnClase();
		#endregion
	}
}
