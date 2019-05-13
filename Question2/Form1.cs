using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace question2
{
    struct SoftDrink
    {//declaring the structure
        public string name;
        public double cost;
        public int quantity;
    }
    public partial class Form1 : Form
    {//creating an array af instances
        const int arrSize = 5;   //size of the array
        SoftDrink[] arrDrink = new SoftDrink[arrSize];  //array
        double totSales;  //where the total cost is stored

        private void Form1_Load(object sender, EventArgs e)
        {//assigning values to each instance softdrink of the array
            //first, the names
            arrDrink[0].name = "cola";            
            arrDrink[1].name = "root";
            arrDrink[2].name = "lemon";
            arrDrink[3].name = "grape";
            arrDrink[4].name = "cream";

            //now quantities and cost
            for (int i=0; i<=4;i++)
            {//all quantities are the same
                arrDrink[i].quantity = 20;
                if (i<=2)
                {//first three cost 1.00
                    arrDrink[i].cost = 1.00;
                }
                else
                {//last two cost 1.50
                    arrDrink[i].cost = 1.50;
                }
            }

            //putting amounts on the labels.            
            lblCola.Text = arrDrink[0].quantity.ToString();
            lblRoot.Text = arrDrink[1].quantity.ToString();
            lblLemon.Text = arrDrink[2].quantity.ToString();
            lblGrape.Text = arrDrink[3].quantity.ToString();
            lblCream.Text = arrDrink[4].quantity.ToString();
            lblTotSales.Text = "$0.00";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool SellDrink(ref SoftDrink drink)
        {/*This method receives the selected drink as argument (which is one element of the arrDrink array.
            The method displays a message if there's no selected drink left (returning false) or 
            "makes the sell" (returning true), meaning taking one unit from the selected drink and 
            increasing the sales value.*/

            if (drink.quantity == 0)
            {//displays message if there's no more of the soft drink the user selected.
                MessageBox.Show("Sorry, no " + drink.name + " left!");
                return false;
            }
            drink.quantity--;  //deducts one unit
            totSales += drink.cost;  //updates total sales value
            lblTotSales.Text = totSales.ToString("c");  //display total value
            return true;
            //if this part of the code is reached, there's still the selected soft drink available.
            //so we take one from the quantity.            
        }

        //here are the commands for the pictures. As they all behave the same way, only the first one
        //has comments.
        private void pcbCola_Click(object sender, EventArgs e)
        {//method called when the cola picture is clicked.
            bool verify;  //variable that receives the value from the method SellDrink
            
            verify = SellDrink(ref arrDrink[0]);  //passes the first element of the array, which is Cola.
            if (!verify)
            {//if the SellDrink method returns false, the "no drink left" message was already sent.
                //So here, just exit the execution.
                return;
            }
            lblCola.Text = arrDrink[0].quantity.ToString();  //updates cola label
        }

        private void pcbRoot_Click(object sender, EventArgs e)
        {//Root Beer
            bool verify;

            verify = SellDrink(ref arrDrink[1]);
            if (!verify)
            {
                return;
            }
            lblRoot.Text = arrDrink[1].quantity.ToString();

        }

        private void pcbLemon_Click(object sender, EventArgs e)
        {//Lemon Lime
            bool verify;

            verify = SellDrink(ref arrDrink[2]);
            if (!verify)
            {
                return;
            }
            lblLemon.Text = arrDrink[2].quantity.ToString();
        }

        private void pcbGrape_Click(object sender, EventArgs e)
        {//Grape soda
            bool verify;

            verify = SellDrink(ref arrDrink[3]);
            if (!verify)
            {
                return;
            }
            lblGrape.Text = arrDrink[3].quantity.ToString();
        }

        private void pcbCream_Click(object sender, EventArgs e)
        {//Cream Soda
            bool verify;

            verify = SellDrink(ref arrDrink[4]);
            if (!verify)
            {
                return;
            }
            lblCream.Text = arrDrink[4].quantity.ToString();
        }
    }
}
