using System;
using System.IO;
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

namespace WpfAppPictureBindingTest
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        public String DialogText {
            get { return TextBoxPath.Text; }
            set { TextBoxPath.Text = value; }
        }
        public DialogBox()
        {
            InitializeComponent();
            TextBoxPath.Text = @"C:\Users\User\Pictures";
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(TextBoxPath.Text) && new DirectoryInfo(DialogText).Exists)
            {
                DialogResult = true;
            }
            else
            {
                TextBlock.Text = "Filepath not found, please try again:";
            }
        }
    }
}
