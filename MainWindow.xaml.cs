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
using System.Data;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       /* string xCoordinate;
        string yCoordinate;
        string tower;
        string side;
        string partNameforSearch;
        string quantity;
        */
        public MainWindow()
        {
            InitializeComponent();
        }

     

        //Submit
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Search().Show();

        }

        //View Logs
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new LogView().Show();
        }

        //Borrow
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Borrow().Show();
        }

        //Return
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Return().Show();
        }

    
    }
}
