using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcApp
{
    public partial class Form1 : Form
    {   
        private List<string> inputList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void NumberClick(object sender, EventArgs e)
        {
            ClickAppendtoText(sender);
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            ClickAppendtoText(sender);
        }

        private void ClearClick(object sender, EventArgs e)
        {
            ClearDisplay();
        }
        
        private void CalculateClick(object sender, EventArgs e)
        {
            Calculate();
        }

        private void ClickAppendtoText(object sender)
        {
            Button button = (Button)sender;
            inputList.Add(button.Text);
            UpdateDisplay();

        }

        private void UpdateDisplay()
        {
            richTextBox1.Text = string.Join("", inputList);
        }

        private void ClearDisplay()
        {
            inputList.Clear();
            richTextBox1.Text = "";
        }

        private void Calculate()
        {
            try
            {
                string expression = string.Join("", inputList);
                var result = new DataTable().Compute(expression, null);
                richTextBox1.Text = result.ToString();
                inputList.Clear();
                inputList.Add(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
