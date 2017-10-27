/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * Clase Jornada:
 Atributos Profesor, Clase y Alumnos que toman dicha clase.
 Se inicializará la lista de alumnos en el constructor por defecto.
 Una Jornada será igual a un Alumno si el mismo participa de la clase.
 Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
cargados.
 ToString mostrará todos los datos de la Jornada.
 Guardar de clase guardará los datos de la Jornada en un archivo de texto.
 Leer de clase retornará los datos de la Jornada como texto
 */
using System;
using System.Collections.Generic;
using Clases_Abstractas;
using Archivos;

namespace Clases_Instanciables
{	
	public class Jornada
	{
		private List<Alumno> _alumnos;
		private Universidad.EClases _clase;
		private Profesor _instructor;
		
	#region propiedades		
		public List<Alumno> Alumnos {
			get { return _alumnos; }
			set { _alumnos = value; }
		}
		public Universidad.EClases Clase {
			get { return _clase; }
			set { _clase = value; }
		}
		public Profesor Instructor {
			get { return _instructor; }
			set { _instructor = value; }
		}
	#endregion

		private Jornada()
		{
			_alumnos=new List<Alumno>();
		}
        /// <summary>
        /// constructor jornada
        /// </summary>
        /// <param EClases="clase"></param>
        /// <param Profesor="instructor"></param>
		public Jornada(Universidad.EClases clase, Profesor instructor):this(){
			this._clase=clase;
			this._instructor=instructor;
		}

        #region Operators override
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param Jornada="j1"></param>
        /// <param Alumno="a1"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Jornada j1, Alumno a1){
			foreach (Alumno alumno in j1._alumnos) {
			if(((Universitario)alumno)==((Universitario)a1) || (a1==j1._clase)){
					return true;
				}
			}			
			return false;
		}		
		public static bool operator !=(Jornada j1, Alumno a1){
			return (!(j1==a1));			
		}
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param Jornada="j1"></param>
        /// <param Alumno="a1"></param>
        /// <returns>Jornada</returns>
        public static Jornada operator +(Jornada j1, Alumno a1){
			if(j1._alumnos.Contains(a1)){				
				return j1;
			}		
			j1._alumnos.Add(a1);
			return j1;			
		}
	#endregion
		public override string ToString()
		{	
			string jornadaStr = string.Format("Jornada\n Clase={0}\n Instructor={1}\n",this.Clase, this._instructor.ToString());
			foreach (Alumno alumno in this._alumnos) {
				jornadaStr+=alumno.ToString();
			}
			return jornadaStr;
		}
        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param Jornada="jornada"></param>
        /// <returns>bool</returns>
        public static bool Guardar(Jornada jornada){
			Texto jornadaTxt = new Texto();
			return jornadaTxt.guardar("Jornada.txt", jornada.ToString());
		}
		public string leer(){
			string datos;
			Texto jornadaTxt = new Texto();
			jornadaTxt.leer("Jornada.txt", out datos);
			return datos;
		}

	}
}
