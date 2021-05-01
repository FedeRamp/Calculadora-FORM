using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Calculadora.GUI
{
    public partial class Form1 : Form
    {
        private List<Double> numeros;
        private List<Char> signos;
        private string inputActual;
        public Form1()
        {
            inputActual = "";
            numeros = new List<double>();
            signos = new List<char>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void num1()
        {
            inputActual += "1";
            UpdateTextBox();
        }
        private void num2()
        {
            inputActual += "2";
            UpdateTextBox();
        }
        private void num3()
        {
            inputActual += "3";
            UpdateTextBox();
        }
        private void num4()
        {
            inputActual += "4";
            UpdateTextBox();
        }
        private void num5()
        {
            inputActual += "5";
            UpdateTextBox();
        }
        private void num6()
        {
            inputActual += "6";
            UpdateTextBox();
        }
        private void num7()
        {
            inputActual += "7";
            UpdateTextBox();
        }
        private void num8()
        {
            inputActual += "8";
            UpdateTextBox();
        }
        private void num9()
        {
            inputActual += "9";
            UpdateTextBox();
        }
        private void num0()
        {
            inputActual += "0";
            UpdateTextBox();
        }

        private void borrar()
        {
            this.numeros.Clear();
            this.signos.Clear();
            this.inputActual = "";
            this.txtInput.Text = "";
            this.cuentaActual.Text = "";
        }

        private void mostrarResultado()
        {
            try
            {
                AddNumero(inputActual);
                double resultado = numeros[0];
                for (int i = 0; i < signos.Count; i++)
                {
                    switch (signos[i])
                    {
                        case '/':
                            resultado /= numeros[i + 1];
                            break;
                        case 'x':
                            resultado *= numeros[i + 1];
                            break;
                        case '+':
                            resultado += numeros[i + 1];
                            break;
                        case '-':
                            resultado -= numeros[i + 1];
                            break;
                        default:
                            break;
                    }
                }
                this.numeros.Clear();
                this.signos.Clear();
                this.inputActual = "";
                this.cuentaActual.Text = "";
                this.txtInput.Text = $"Resultado = {resultado}";
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDiv()
        {
            try
            {
                AddOperacion(this.inputActual, '/');

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRest()
        {
            try
            {
                AddOperacion(this.inputActual, '-');

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnMult()
        {
            try
            {
                AddOperacion(this.inputActual, 'x');

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSum()
        {
            try
            {
                AddOperacion(this.inputActual, '+');

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddOperacion(string numero, char signo)
        {
            if (numero != "")
            {
                double num = double.Parse(numero);
                this.numeros.Add(num);
                this.signos.Add(signo);
                this.inputActual = "";
                UpdateTextBox();
                this.cuentaActual.Text += $"{numero} {signo} ";
            }
            else
            {
                throw new Exception("No se ingresó ningun número");
            }
        }

        private void AddNumero(string numero)
        {
            if (numero != "")
            {
                double num = double.Parse(numero);
                this.numeros.Add(num);
                this.cuentaActual.Text += $"{numero}";
            }
            else
            {
                throw new Exception("No se ingresó ningun número");
            }
        }

        private void UpdateTextBox()
        {
            this.txtInput.Text = this.inputActual;
        }


        /*          EVENT HANDLING          */
        /************************************/
        private void btn1_Click(object sender, EventArgs e)
        {
            num1();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            num2();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            num3();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            num4();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            num5();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            num6();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            num7();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            num8();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            num9();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            num0();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            mostrarResultado();
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            btnDiv();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            btnMult();
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            btnRest();
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            btnSum();
        }




        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '/':
                    btnDiv();
                    break;
                case 'x':
                    btnMult();
                    break;
                case '+':
                    btnSum();
                    break;
                case '-':
                    btnRest();
                    break;
                case '1':
                    num1();
                    break;
                case '2':
                    num2();
                    break;
                case '3':
                    num3();
                    break;
                case '4':
                    num4();
                    break;
                case '5':
                    num5();
                    break;
                case '6':
                    num6();
                    break;
                case '7':
                    num7();
                    break;
                case '8':
                    num8();
                    break;
                case '9':
                    num9();
                    break;
                case '0':
                    num0();
                    break;
                case '=':
                    mostrarResultado();
                    break;
                case (char)13:
                    mostrarResultado();
                    break;
                default:
                    break;
            }
        }
    }
}
