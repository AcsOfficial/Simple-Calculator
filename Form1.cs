using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double num1 = 0, num2 = 0;
        string operand = "";
        public Calculator()
        {
            InitializeComponent();
            this.one.Click += NumberButton_Click;
            this.two.Click += NumberButton_Click;
            this.three.Click += NumberButton_Click;
            this.four.Click += NumberButton_Click;
            this.five.Click += NumberButton_Click;
            this.Six.Click += NumberButton_Click;
            this.Seven.Click += NumberButton_Click;
            this.Eight.Click += NumberButton_Click;
            this.Nine.Click += NumberButton_Click;
            this.zero.Click += NumberButton_Click;

            this.Add.Click += OperatorButton_Click;
            this.Minus.Click += OperatorButton_Click;
            this.Multiplication.Click += OperatorButton_Click;
            this.Division.Click += OperatorButton_Click;
            this.period.Click += PeriodButton_Click;
            this.percentage.Click += OperatorButton_Click;
            this.Equals.Click += EqualsButton_Click;
            
        }

        public void NumberButton_Click(object sender, EventArgs e)
        {
            Button buttonclicked = sender as Button;
            if(buttonclicked != null)
            {
                TxtBoxinput.Text += buttonclicked.Text;
            }
        }

        public void OperatorButton_Click(Object sender, EventArgs e)
        {
            Button buttonclicked = sender as Button;
            if (buttonclicked != null)
            {
                operand = buttonclicked.Text;
                TxtBoxinput.Text += " " + operand + " ";
            }
        }

        public void PeriodButton_Click(object sender, EventArgs e)
        {
            Button buttonclicked = sender as Button;
            if (buttonclicked != null)
            {
                TxtBoxinput.Text = ".";
            }
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            if (TxtBoxinput.Text.Length > 0)
            {
                TxtBoxinput.Text = TxtBoxinput.Text.Substring(0, TxtBoxinput.Text.Length - 1);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            TxtBoxinput.Clear();
        }

        public void EqualsButton_Click(Object obj, EventArgs e)
        {
            string input = TxtBoxinput.Text.Trim();
            double result = 0;

            if (input.Contains("%"))
            {
                string numberPart = input.Replace("%", "").Trim();
                if (double.TryParse(numberPart, out double num1))
                {
                    result = num1 / 100;
                    TxtBoxinput.Text = result.ToString();
                    return;
                }
                else
                {
                    MessageBox.Show("Error: Invalid number format");
                    return;
                }
            }

            string[] parts = input.Split(' ');
            if (parts.Length == 3)
            {
                try
                {
                    double num1 = Convert.ToDouble(parts[0]);
                    double num2 = Convert.ToDouble(parts[2]);
                    string operand = parts[1];

                    switch (operand)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "x":
                            result = num1 * num2;
                            break;
                        case "÷":
                            if (num2 != 0)
                            {
                                result = num1 / num2;
                            }
                            else
                            {
                                MessageBox.Show("Error: Division by zero");
                                return;
                            }
                            break;
                        case "%":
                            result = (num1 * num2) / 100;
                            break;
                        default:
                            MessageBox.Show("Error: Invalid operator");
                            return;
                    }

                    TxtBoxinput.Text = result.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error: Invalid number format");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Error: Invalid input format");
            }
        }
       
    }
}
