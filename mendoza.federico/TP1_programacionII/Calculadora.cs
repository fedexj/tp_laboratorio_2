using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_programacionII
{
    class Calculadora
    {

/** Metodo - operar 
*  Parametros entrada: Numero, Numero, string
*  Parametros salida: double
*  brief: realiza la operacion indicada por el string "operador" entre los Numero "numero1" y "numero2", devolviendo el resultado en double; valida si numero2 para la division es 0, en ese caso devuelve 0
*/
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double returnAux=0;
            string operadorAux=Calculadora.validarOperador(operador);

            switch (operadorAux)
            { 
                case "+":
                    returnAux = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    returnAux = numero1.getNumero() - numero2.getNumero();
                    break;                    
                case "*":
                    returnAux = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() != 0)
                    {
                        returnAux = numero1.getNumero() / numero2.getNumero();
                    }
                    else { returnAux = 0; }
                    
                    break;   
            
            }

            return returnAux;
        }

/** Metodo - validarOperador 
*  Parametros entrada: string
*  Parametros salida: string
*  brief: valida que el string operador sea alguno incluido en el combo box, de lo contrario devuelve "+"
*/        
        public static string validarOperador(string operador)
        {
            string returnOperador;
            if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
            {
                returnOperador = "+";
            }
            else { returnOperador = operador; }
            return returnOperador;
        }


    }
}
