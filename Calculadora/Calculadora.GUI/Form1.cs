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
        private bool mostrandoResultado;
        private List<Double> numeros;
        private List<Char> signos;
        public Form1()
        {
            mostrandoResultado = false;
            numeros = new List<double>();
            signos = new List<char>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void num1()
        {
            this.txtInput.Text += "1";
            UpdateTextBox();
        }
        private void num2()
        {
            this.txtInput.Text += "2";
            UpdateTextBox();
        }
        private void num3()
        {
            this.txtInput.Text += "3";
            UpdateTextBox();
        }
        private void num4()
        {
            this.txtInput.Text += "4";
            UpdateTextBox();
        }
        private void num5()
        {
            this.txtInput.Text += "5";
            UpdateTextBox();
        }
        private void num6()
        {
            this.txtInput.Text += "6";
            UpdateTextBox();
        }
        private void num7()
        {
            this.txtInput.Text += "7";
            UpdateTextBox();
        }
        private void num8()
        {
            this.txtInput.Text += "8";
            UpdateTextBox();
        }
        private void num9()
        {
            this.txtInput.Text += "9";
            UpdateTextBox();
        }
        private void num0()
        {
            this.txtInput.Text += "0";
            UpdateTextBox();
        }

        private void borrar()
        {
            this.numeros.Clear();
            this.signos.Clear();
            this.txtInput.Text = "";
            this.txtInput.Text = "";
            this.cuentaActual.Text = "";
        }

        private void mostrarResultado()
        {
            try
            {
                AddNumero(this.txtInput.Text);
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
                this.txtInput.Text = "";
                this.cuentaActual.Text = "";
                this.txtInput.Text = $"Resultado = {resultado}";
                this.mostrandoResultado = true;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDiv()
        {
            try
            {
                AddOperacion(this.txtInput.Text, '/');

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
                AddOperacion(this.txtInput.Text, '-');

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
                AddOperacion(this.txtInput.Text, 'x');

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
                AddOperacion(this.txtInput.Text, '+');

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
                this.txtInput.Text = "";
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
            this.txtInput.Text = this.txtInput.Text;
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


        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mostrandoResultado)
            {
                this.txtInput.Text = "";
                this.mostrandoResultado = false;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            switch (e.KeyChar)
            {
                case '/':
                    btnDiv();
                    break;
                case 'x':
                    btnMult();
                    break;
                case '*':
                    btnMult();
                    break;
                case '+':
                    btnSum();
                    break;
                case '-':
                    btnRest();
                    break;
                case '=':
                    mostrarResultado();
                    break;
                case (char)13:
                    this.Focus();
                    mostrarResultado();
                    break;
                default:
                    break;
            }
        }
    }
}
