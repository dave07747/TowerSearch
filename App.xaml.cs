using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TowerSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));

            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.PreviewMouseDownEvent, new RoutedEventHandler(TextBox_PreviewMouseDown));

            base.OnStartup(e);

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            (sender as TextBox).SelectAll();

        }

        private void TextBox_PreviewMouseDown(object sender, RoutedEventArgs e)
        {

            TextBox textBox = sender as TextBox;

            if (!textBox.IsFocused)
            {

                textBox.Focus();

                textBox.SelectAll();

                e.Handled = true;

            }

        }
    }
}
