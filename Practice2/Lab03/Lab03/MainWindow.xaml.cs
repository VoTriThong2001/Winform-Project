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

namespace Lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int input1, input2, result ;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlus(object sender, RoutedEventArgs e)
        {
            result = input1 + input2;
            txtResult.Text = result.ToString();
            IsRecentCalculation.Items.Add(txtResult.Text);
        }

        private void btnMinus(object sender, RoutedEventArgs e)
        {
            result = input1 - input2;
            txtResult.Text = result.ToString();
            IsRecentCalculation.Items.Add(txtResult.Text);
        }

        private void btnMultiply(object sender, RoutedEventArgs e)
        {
            result = input1 * input2;
            txtResult.Text = result.ToString();
            IsRecentCalculation.Items.Add(txtResult.Text);
        }


        private void btnDivide(object sender, RoutedEventArgs e)
        {
            if (input2 != 0) {
                result = input1 / input2;
                txtResult.Text = result.ToString();
                IsRecentCalculation.Items.Add(txtResult.Text);

            }
                
        }

        private void txtResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtResult.Text = result.ToString();
          
            
        }

        private void txtInput1_TextChanged(object sender, TextChangedEventArgs e)
        {
            input1 = Convert.ToInt32(txtInput1.Text);
        }

        private void txtInput2_TextChanged(object sender, TextChangedEventArgs e)
        {
            input2 = Convert.ToInt32(txtInput2.Text);
        }

        
    }
}
