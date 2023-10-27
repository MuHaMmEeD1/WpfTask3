using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OpenFileDialog dia = new OpenFileDialog();
        bool diaAktiv = false;
        string saxlaYadda = null;

        public MainWindow()
        {
            InitializeComponent();
            yazTextBox.TextChanged += TextBox_TextChanged;
        }

        private void fileExpander_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

             

            dia.Filter = "txt|*.txt";

            bool yoxla = dia.ShowDialog().Value;
        
            if (yoxla) {

               yazTextBox.Text = File.ReadAllText(dia.FileName);
               fileLabel.Content = dia.FileName;
                diaAktiv = true;
            }




        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
           

            if (diaAktiv)
            {

                File.WriteAllText(dia.FileName, yazTextBox.Text);
            }


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if(otoSaveCheckBox.IsChecked == true && diaAktiv)
            {

                File.WriteAllText(dia.FileName, yazTextBox.Text);
            }

        }

        private void cutButton_Click(object sender, RoutedEventArgs e)
        {

            if (yazTextBox.SelectedText.Length != 0)
            {
                saxlaYadda = yazTextBox.SelectedText;
                yazTextBox.SelectedText = "";
            }

        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (yazTextBox.SelectedText.Length != 0)
            {
                saxlaYadda = yazTextBox.SelectedText;
            }
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (saxlaYadda != null)
            {
                string newText = "";

                
                for (int i = 0; i < yazTextBox.Text.Length; i++)
                {

                    if (i == yazTextBox.CaretIndex) { newText = newText + saxlaYadda; }

                    newText = newText + yazTextBox.Text[i].ToString();
                }

                yazTextBox.Text = newText;

                if (yazTextBox.Text.Length == yazTextBox.CaretIndex)
                {

                    yazTextBox.Text += saxlaYadda;
                }

            }
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            yazTextBox.SelectAll();

        }
    }
}
