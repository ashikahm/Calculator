using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private decimal firstnumber,secondnumber;
        private bool isOperatorClicked;
        private string OperatorName;
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(lblResult.Text=="0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                lblResult.Text = button.Text;
            }
            else
            {
                lblResult.Text += button.Text;
            }

        }

        private void ClrButton_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            isOperatorClicked=false;

        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            string number = lblResult.Text;
            if(number!="0")
            {
                number=number.Remove(number.Length-1);
                if(string.IsNullOrEmpty(number))
                {
                    lblResult.Text = "0";
                }
                else
                {
                    lblResult.Text = number;
                }       
            }
        }

        private async void PercentButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = lblResult.Text;
                if(number!="0")
                {
                    decimal value = decimal.Parse(number);
                    string result = (value / 100).ToString("0.##");
                    lblResult.Text = result;
                }
                
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error Occured" , ex.Message);

            }

        }
        private void BtnCommonOperationClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked=true;
            OperatorName=button.Text;
            firstnumber = Convert.ToDecimal(lblResult.Text);

        }

        private void EqualsButton_Clicked(object sender, EventArgs e)
        {
            secondnumber= Convert.ToDecimal(lblResult.Text);
            string finalResult= Calculate(firstnumber,secondnumber).ToString("0.##");
            lblResult.Text=finalResult;
        }
        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            switch(OperatorName)
            {
                case "+":
                    result= firstNumber+ secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;

            }
            return result;
        }

        private Task DisplayAlert(string v, string message)
        {
            throw new NotImplementedException();
        }
    }
}
