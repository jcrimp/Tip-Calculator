using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment10
    /********************************************
     * Jenny Crimp
     * ITC 110
     * Assignment 10
     * This project is a tip calculator form
     * It gets user input for meal amount and tip percentage,
     * and uses the Tip class to do the calculations.
     * The user can then input a file path and save,
     * as well as read the file.
     * *****************************************/
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnReadFile.Visibility = System.Windows.Visibility.Hidden;
            lblSaveInstructions.Visibility = System.Windows.Visibility.Hidden;
            txtFilePath.Visibility = System.Windows.Visibility.Hidden;
            btnSave.Visibility = System.Windows.Visibility.Hidden;
            btnClear.Visibility = System.Windows.Visibility.Hidden;
            btnClearBottom.Visibility = System.Windows.Visibility.Hidden;
            
        }

        //What happens when Calculate button is clicked
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //initiate Tip class
            Tip t = new Tip();

            //declare variables for text entry validation
            bool goodMeal;
            bool goodTip;
            double mealInt;
            double tipInt;


            //validate entries and pass them to tip class
            goodMeal = double.TryParse(txtMealAmount.Text, out mealInt);
            if (!goodMeal)
            {
                MessageBox.Show("Please enter a valid number for the meal amount.");
                return;
            }

            t.MealAmount = mealInt;
            if(radio15Percent.IsChecked==true)
            {
                t.TipPercent = 15;
            }
            else if(radio18Percent.IsChecked == true)
            {
                t.TipPercent = 18;
            }
            else if(radio20Percent.IsChecked == true)
            {
                t.TipPercent = 20;
            }
            else
            {
                goodTip = double.TryParse(txtTip.Text, out tipInt);
                if (!goodTip)
                {
                    MessageBox.Show("Please enter a valid number for the tip percentage.");
                    return;
                }
                t.TipPercent = tipInt;
            }
            
            //get the results back
            string results = "Meal Amount : " + t.MealAmount.ToString("C") + "\n"
                + "Tax : " + t.CalculateTax().ToString("C") + "\n"
                + "Subtotal : " + t.CalculateSubtotal().ToString("C") + "\n"
                + "Tip : " + t.CalculateTip().ToString("C") + "\n"
                + "Total : " + t.CalculateTotal().ToString("C") + "\n";
            lblResult.Content = results;

            //show write file prompt, text entry, save button and clear form button
            lblSaveInstructions.Visibility = System.Windows.Visibility.Visible;
            txtFilePath.Visibility = System.Windows.Visibility.Visible;
            btnSave.Visibility = System.Windows.Visibility.Visible;
            btnClear.Visibility = System.Windows.Visibility.Visible;
        }

        //What happens when Save button is clicked
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //pass file path to WriteFile class
            string path = txtFilePath.Text;//

            //initiate WriteFile class
            WriteFile w = new WriteFile(path);

            if (lblResult.Content == "")
            {
                MessageBox.Show("You must fill out the form before saving.");
                return;
            }

            else
            {
                w.AddToFile(lblResult.Content.ToString());
                w.CloseFile();
                lblSuccess.Content = "Success! Your file has been saved.";
                
                //make read file button visible
                btnReadFile.Visibility = System.Windows.Visibility.Visible;
            }

        }

        //what happens when Read File button is clicked
        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            //pass file path to ReadFile Class
            string path = txtFilePath.Text;

            //Initiate ReadFile class
            ReadFile r = new ReadFile(path);

            //Show file contents in label
            lblFileContents.Content = r.GetFile();
        }

        //what happens when Clear button is clicked
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMealAmount.Clear();
            txtTip.Clear();
            lblResult.Content = "";
            lblSaveInstructions.Visibility = System.Windows.Visibility.Hidden;
            txtFilePath.Clear();
            txtFilePath.Visibility = System.Windows.Visibility.Hidden;
            btnSave.Visibility = System.Windows.Visibility.Hidden;
            lblSuccess.Content = "";
            btnReadFile.Visibility = System.Windows.Visibility.Hidden;
            lblFileContents.Content = "";
            txtMealAmount.Focus();
            btnClear.Visibility = System.Windows.Visibility.Hidden;
            btnClearBottom.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnClearBottom_Click(object sender, RoutedEventArgs e)
        {
            txtMealAmount.Clear();
            txtTip.Clear();
            lblResult.Content = "";
            lblSaveInstructions.Visibility = System.Windows.Visibility.Hidden;
            txtFilePath.Clear();
            txtFilePath.Visibility = System.Windows.Visibility.Hidden;
            btnSave.Visibility = System.Windows.Visibility.Hidden;
            lblSuccess.Content = "";
            btnReadFile.Visibility = System.Windows.Visibility.Hidden;
            lblFileContents.Content = "";
            txtMealAmount.Focus();
            btnClear.Visibility = System.Windows.Visibility.Hidden;
            btnClearBottom.Visibility = System.Windows.Visibility.Hidden;
        }


        
    }
}
