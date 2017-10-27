/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * Clase Universidad:
 Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) y Jornadas.
 Se accederá a una Jornada específica a través de un indexador.
 Un Universidad será igual a un Alumno si el mismo está inscripto en él.
 Un Universidad será igual a un Profesor si el mismo está dando clases en él.
 Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la
toman (todos los que coincidan en su campo ClaseQueToma).
 Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente
cargados. La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
Sino, lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no
pueda dar la clase.
 MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante
ToString.
 Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus
Profesores, Alumnos y Jornadas.
 Leer de clase retornará un Universidad con todos los datos previamente serializados.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{			
	public class Universidad
	{
		public enum EClases{
		Programacion=0, Legislacion=1, Laboratorio=2, SPD=3,
		}
		
		#region Atributos y prop
		private List<Alumno> _alumnos;
		private List<Jornada> _jornadas;
		private List<Profesor> _profesores;
		
		public List<Alumno> Alumnos {
			get { return this._alumnos; }
			set { _alumnos = value; }
		}
		public List<Jornada> Jornadas {
			get { return _jornadas; }
			set { _jornadas = value; }
		}
		public List<Profesor> Instructores {
			get { return _profesores; }
			set { _profesores = value; }
			
		}
		 public Jornada this[int i]{
			get { return this._jornadas[i];  }
			set { this._jornadas.Insert(i, value); }
	    }
		#endregion
		#region Constructor
		public Universidad(){
			this._alumnos= new List<Alumno>();
			this._jornadas=new List<Jornada>();
			this._profesores=new List<Profesor>();
        }
        #endregion

        #region Operator override
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param Universidad="u1"></param>
        /// <param Alumno="a1"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad u1, Alumno a1){
			foreach (Alumno alumno in u1._alumnos) {
				if(((Universitario)alumno)==((Universitario)a1)){
					return true;
				}
			}			
			return false;
		}		
		public static bool operator !=(Universidad u1, Alumno a1){
			return (!(u1==a1));			
		}
        /// <summary>
        /// la igualdad devuelve un profesor disponible apra dar una clase, o una excepcion si no hay
        /// </summary>
        /// <param Universidad="u1"></param>
        /// <param EClases="eC1"></param>
        /// <returns>Profesor</returns>
        public static Profesor operator ==(Universidad u1, EClases eC1){
			foreach (Profesor profesor in u1._profesores) {
				if(profesor==eC1){
					return profesor;				
				}
			}			
			throw new SinProfesorException();
		}		
		public static Profesor operator !=(Universidad u1, EClases eC1){
			Profesor p1 = new Profesor();
			foreach (Profesor profesor in u1._profesores) {
				if(profesor!=eC1){
					return profesor;				
				}
			}
			return p1;
		}
        /// <summary>
        ///  Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param Universidad="u1"></param>
        /// <param Profesor="p1"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u1, Profesor p1){
			foreach (Profesor profesor in u1._profesores) {
				if(((Universitario)profesor)==((Universitario)p1)){
					return true;
				}
			}			
			return false;
		}
		public static bool operator !=(Universidad u1, Profesor p1){
			return (!(u1==p1));			
		}
        /// <summary>
        /// aagrega alumno a universidad
        /// </summary>
        /// <param Universidad="u1"></param>
        /// <param Alumno="a1"></param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u1, Alumno a1){
			if(u1!=a1){	
				u1._alumnos.Add(a1);
				return u1;
			}					
			return u1;			
		}
        /// <summary>
        /// aagrega profesor a universidad
        /// </summary>
        /// <param Universidad="u1"></param>
        /// <param Profesor="a1"></param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u1, Profesor p1){
			if(u1!=p1){	
				u1._profesores.Add(p1);
				return u1;
			}					
			return u1;			
		}
        /// <summary>
        /// agrega jornada a universidad
        /// </summary>
        /// <param Universidad="u1"></param>
        /// <param EClases="eC1"></param>
        /// <returns></returns>
		public static Universidad operator +(Universidad u1, EClases eC1){
			Jornada jornada = new Jornada(eC1, u1==eC1);
			foreach (Alumno alumno in u1._alumnos) {
				if(alumno == eC1){
					jornada.Alumnos.Add(alumno);
				}
			}
			u1._jornadas.Add(jornada);
			return u1;
		}
		#endregion
		
		private string MostrarDatos(Universidad u1){			
			string str="";
			foreach (Alumno alumno in u1._alumnos) {
				str+=alumno.ToString();
			}
			foreach (Profesor profesor in u1._profesores) {
				str+=profesor.ToString();
			}
			foreach (Jornada jornada in u1._jornadas) {
				str+=jornada.ToString();
			}
			return str;
		}
		
		public override string ToString()
		{
			return string.Format("{0}", this.MostrarDatos(this));
		}

        /// <summary>
        /// guarda universidad en xml
        /// </summary>
        /// <param Universidad="uni"></param>
        /// <returns>bool</returns>
        public static bool Guardar(Universidad uni){
			Xml<Universidad> xml = new Xml<Universidad>();
			return xml.guardar("Universidad.xml", uni);
		}
        /// <summary>
        /// lee universidad desde xml
        /// </summary>
        /// <param Universidad="uni"></param>
        /// <returns></returns>
		public bool leer(Universidad uni){
			Xml<Universidad> xml = new Xml<Universidad>();
			return xml.leer("Universidad.xml",out uni);
		}
	
	}
}
