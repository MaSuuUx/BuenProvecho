using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 -------------------------------------------------------------------------------------------
 ===> NOMBRE: HECTOR MARCELO MONGE CABALLERO
 ===> CARNET: MC23084
 ===> PROFESOR: ING. BLADIMIR DIAZ
 ===> GL: 18

ENUNCIADO: La Cadena de Restaurantes “Buen Provecho” desea un programa en el cual:

a) Si el cliente ha consumido más de $30.00, se le aplique un descuento del 25% a su
cuenta y se muestre en pantalla lo total a cobrar y su descuento.

b) Si el cliente gastó $30.00 o menos, no se le aplique el descuento y pague la totalidad
de su consumo. Desplegar el mensaje: “Pasar a Caja por un Cupón Promocional”.

 -------------------------------------------------------------------------------------------
 */
namespace Buen_Provecho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //EVENTO PARA CERRAR EL FORMS
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //EVENTO PARA DESHABILITAR EL BOTON AL CARGAR EL FORM
        private void Form1_Load(object sender, EventArgs e)
        {
            BtnPrint.Enabled = false;
        }

        //EVENTO DE TXTCHANGED
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ctrlBotones();//LLAMADO AL METODO
        }

        private void ctrlBotones()
        {
            string entradaData = textBox1.Text;

            // VERIFICA SI EL TEXTO NO ESTÁ EN BLANCO Y ES UN NÚMERO ENTERO O DECIMAL
            if (!string.IsNullOrWhiteSpace(entradaData) && (EsNumeroEntero(entradaData) || EsNumeroDecimal(entradaData)))
            {
                // HABILITA EL BOTON
                BtnPrint.Enabled = true;
                errorProvider.Clear();
            }
            else
            {
                // DESHABILITA EL BOTON
                BtnPrint.Enabled = false;

                // MUESTRA UN MENSAJE DE ERROR 
                errorProvider.SetError(textBox1, "Debe ingresar solo números (enteros o decimales)");
            }
        }

        //VERIFICA SI ES ENTERO
        private static bool EsNumeroEntero(string entradaData)
        {
            int number;
            return int.TryParse(entradaData, out number);
        }

        //VERIFICA SI ES DECIMAL
        private static bool EsNumeroDecimal(string entradaData)
        {
            decimal number;
            return decimal.TryParse(entradaData, out number);
        }

        //EVENTO DEL BtnPrint_Click
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            string entradaData = textBox1.Text;

            if (double.TryParse(entradaData, out double montoConsumido))
            {
                string mensaje = "";

                //SWICTH DEPENDIENDO DEL CASO
                switch (montoConsumido)
                {
                    case double monto when (monto > 30.00):
                        double descuento = monto * 0.25;
                        double totalAPagar = monto - descuento;
                        mensaje = $"Total a pagar: ${totalAPagar:F2}\nDescuento aplicado: ${descuento:F2}";
                        break;

                    case double monto when (monto <= 30.00 && monto > 0):
                        mensaje = $"Total a pagar: ${monto:F2}\nPasar a Caja por un Cupon Promocional ";
                        break;

                    default:
                        mensaje = "Monto no valido";
                        break;
                }

                //CONFIGURACION DEL MBOX
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //EVENTO PARA LIMPIAR EL TXTBOX
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
