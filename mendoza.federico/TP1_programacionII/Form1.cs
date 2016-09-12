using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_programacionII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOperator = this.cmbOperacion.Text;

                
        }

/** Evento - btnOperar_Click (boton "=")
*  Parametros entrada: object sender, EventArgs e
*  Parametros salida: void
*  brief: carga todos los datos ingresados inicializando los numeros ingresados, llama e integra a los metodos de la Clase calculadora, cargando el resultado en el cuadro de texto "lblResultado"
*/
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string selectedOperador = cmbOperacion.Text;
            string selectedNumber1 = txtNumero1.Text;
            string selectedNumer2 = txtNumero2.Text;
            double resultado;
            

            Numero numero1 = new Numero(selectedNumber1);
            Numero numero2 = new Numero(selectedNumer2);

            resultado=Calculadora.operar(numero1, numero2, selectedOperador);

            this.lblResultado.Text = resultado.ToString();

            
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        /** Evento - btnLimpiar_Click (boton "CC")
        *  Parametros entrada: object sender, EventArgs e
        *  Parametros salida: void
        *  brief: limpia todos los campos cargandoles string vacio, y le carga "resultado" al cuadro de texto lblResultado reseteando la calculadora en su estado original.
        */
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "resultado";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.Text = "";
        }
    }
}
