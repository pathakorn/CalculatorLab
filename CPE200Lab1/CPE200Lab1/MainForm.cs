using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private String mAll;
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private bool secondOperandClicked = false;
        private CalculatorEngine cal = new CalculatorEngine();
       
        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

      

        public MainForm()
        {
            InitializeComponent();
            
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";

            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            firstOperand = lblDisplay.Text;
          //  string result = engine.unaryCalculate(operate, firstOperand);
         /*   if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }*/

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (secondOperandClicked && isAfterOperater == false)
            {
                if (lblDisplay.Text is "Error")
                {
                    return;
                }
                string secondOperand = lblDisplay.Text;
                string result = cal.calculate(operate, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
                isAfterEqual = true;
                secondOperandClicked = false;
            }
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if(firstOperand != null)
            {
                string secondOperand = lblDisplay.Text;
             //   string result = engine.calculate(operate, firstOperand, secondOperand);
             /*   if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }*/
            }
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    secondOperandClicked = true;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    break;
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
          //  string result = engine.calculate(operate, firstOperand, secondOperand);
          /*  if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }*/
            isAfterEqual = true;
            secondOperandClicked = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Double oneOver_x = (1 / Convert.ToDouble(lblDisplay.Text));
            oneOver_x = Math.Round(oneOver_x, 7);
            lblDisplay.Text = oneOver_x.ToString();
        }

        /*private void btnM_Click(object sender, EventArgs e)
        {
            string mOper = ((Button)sender).Text;
            switch (mOper)
            {
                case "MC":
                    mAll = "0";
                    lblDisplay.Text = "0";
                    label1.Text = mAll; break;
                case "MR":
                    lblDisplay.Text = mAll;
                    break;
                case "MS":
                    mAll = lblDisplay.Text;
                    label1.Text = mAll;
                    break;
                case "M+":
                    if (mAll == "0") mAll = lblDisplay.Text;
                    mAll = (Convert.ToDouble(mAll) + Convert.ToDouble(lblDisplay.Text)).ToString();
                    label1.Text = mAll; break;
                case "M-":
                    mAll = (Convert.ToDouble(mAll) - Convert.ToDouble(lblDisplay.Text)).ToString();
                    label1.Text = mAll; break;
            }
        }*/

        private void root_Click(object sender, EventArgs e)
        {
            Double sqrt = (Math.Sqrt(Convert.ToDouble(lblDisplay.Text)));
            sqrt = Math.Round(sqrt, 7);
            lblDisplay.Text = sqrt.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double percent;
            //percent = (Convert.ToDouble(lblDisplay.Text)) *
            percent = Convert.ToDouble(firstOperand) * (Convert.ToDouble(lblDisplay.Text) / 100);
            lblDisplay.Text = percent.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void lblM_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click_1(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click_2(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
