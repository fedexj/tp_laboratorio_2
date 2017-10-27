/*
 * Created by SharpDevelop.
 * User: federico_mendoza
 * Date: 11/10/2017
 * Time: 02:02 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Excepciones;
using System;
using System.Text.RegularExpressions;

namespace Clases_Abstractas
{	
	public abstract class Persona
	{
		public enum ENacionalidad{
			Argentino, Extranjero
		}
		
		private string _nombre;
		private string _apellido;
		private int _dni;
		private ENacionalidad _nacionalidad;
				
        #region "Propiedades"
        public int DNI {
            get {
                return this._dni;
            }
            set {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        public string StringToDNI {
            set {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        public string Nombre {
            get {
                return this._nombre;
            }
            set {
                this._nombre = Persona.ValidarNombreApellido(value);
            }
        }
        public string Apellido {
            get {
                return this._apellido;
            }
            set {
                this._apellido = Persona.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad {
            get {
                return this._nacionalidad;
            }
            set {
                this._nacionalidad = value;
            }
        }
        #endregion	
		
		
	    #region "Constructores"
	    protected Persona() {
		}
        /// <summary>
        /// constructor persona
        /// </summary>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param ENacionalidad="nacionalidad"></param>
        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructor persona
        /// </summary>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param int="dni"></param>
        /// <param ENacionalidad="nacionalidad"></param>
        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// constructor persona
        /// </summary>
        /// <param string="nombre"></param>
        /// <param string="apellido"></param>
        /// <param string="dni"></param>
        /// <param ENacionalidad="nacionalidad"></param>
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        
		public override string ToString()
		{
			return string.Format("Persona Nombre={0} Apellido={1}\n Dni={2}\n Nacionalidad={3}\n", this.Nombre, this.Apellido, this.DNI, this.Nacionalidad);
		}


        #region "Validadores"
        /// <summary>
        /// Validará que el DNI esté dentro de los rangos permitidos
        /// </summary>
        /// <param int="dato"></param>
        /// <returns>DNI valido o 0 (cero) en caso de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Validará que el DNI sea numérico, y luego llamará a la validación numérica
        /// </summary>
        /// <param string="dato">DNI string a validar</param>
        /// <returns>DNI valido o 0 (cero) en caso de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {            
            dato = dato.Replace(".","");            
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;            
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch(Exception e)
            {
                throw new DniInvalidoException(dato.ToString(),e);
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Validará que el nombre esté compuesto solo por caracteres latinos a-z A-Z
        /// </summary>
        /// <param string="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre o apellido validado si está todo OK, o un string vacio en caso de error</returns>
        private static string ValidarNombreApellido(string dato)
        {            
            Regex regex = new Regex(@"[a-zA-Z]*");           
            Match match = regex.Match(dato);
            if (match.Success)
                return match.Value;
            else
                return "";
        }
        #endregion
	}
}
