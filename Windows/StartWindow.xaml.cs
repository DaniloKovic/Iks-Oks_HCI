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
using System.Windows.Shapes;

namespace Iks_Oks
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        /*private void everyButton_MouseHover()
        {
            var bc = new BrushConverter();
            btn3x3.Background = (Brush)bc.ConvertFrom("#FFC7BD38");
        }*/

        private void btn3x3_Click(object sender, RoutedEventArgs e)
        { 
            var window_3x3 = new MainWindow(this); // 3x3 Iks-Oks
            this.Hide();
            window_3x3.Show();
            
        }

        private void btn5x5_Click(object sender, RoutedEventArgs e)
        {
            var window_5x5 = new Window_5x5(this); // 5x5 Iks-Oks
            this.Hide();
            window_5x5.Show();
        }

        private void lbPickAGame_MouseMove(object sender, MouseEventArgs e)
        {
            
        }



        /*private void btn3x3_MouseMove(object sender, MouseEventArgs e)
        {
            // var bc = new BrushConverter();
            // btn3x3.Background = (Brush)bc.ConvertFrom("#FFC7BD38");
        }*/
    }
}
