using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
