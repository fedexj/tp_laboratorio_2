using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_programacionII
{
    class Numero
    {
/** Atributo _numero de clase numero
*  brief: se cargara aqui el valor del numero ingresado
*/
        private double _numero;

 /** Constructor por default - Clase Numero 
 *  Parametros entrada: N/A
 *  brief: inicializa _numero en "0"
 */
        public Numero(): this(0)
        {            
        }

 /** Constructor - Clase Numero 
 *  Parametros entrada: string
 *  brief: inicializa _numero en el valor entregado por el string "numInput"
 */
        public Numero(string numInput)
        { 
            this.setNumero(numInput);                         
        }

/** Constructor - Clase Numero 
*  Parametros entrada: double
*  brief: inicializa _numero en el valor entregado por el double "numInput"
*/
        public Numero(double numInput)
        {
            this._numero = numInput; 
        }

/** Metodo - validarNumero 
*  Parametros entrada: string
*  Parametros salida: double
*  brief: valida que el numero ingresado en forma de string sea valido y lo parsea a double, en caso contrario devuelve 0
*/
        private static double validarNumero(string numInput)
        {
            bool checkAux;
            double returnAux;
            checkAux = double.TryParse(numInput, out returnAux);
            if (checkAux == false)
            {
                returnAux = 0;
            }            
            return returnAux;                        
        }

/** Metodo - setNumero 
*  Parametros entrada: string
*  Parametros salida: void
*  brief: carga el numero devuelto por validarNumero en el atributo _numero
*/
        private void setNumero(string numero)
        {
            this._numero = Numero.validarNumero(numero);   
        }

/** Metodo - setNumero 
*  Parametros entrada: void
*  Parametros salida: void
*  brief: devuelve el valor del atributo _numero
*/
        public double getNumero()
        {
            return this._numero;
        }

    }
}
