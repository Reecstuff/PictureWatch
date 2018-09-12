using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PictureWatch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bufferImage;
        List<FileInfo> pictureList;
        int currentPictureNumber;
        String path;
        DialogBox dialog;
        public MainWindow()
        {
            path = @"C:\Users\User\Pictures";
            Initialize();
        }

        private void Initialize()
        {
            dialog = new DialogBox();
            dialog.DialogText = path;
            if (dialog.ShowDialog() == true)
            {
                path = dialog.DialogText;
                pictureList = new List<FileInfo>(Pictures);
                currentPictureNumber = 0;
                InitializeComponent();
                SetPicture();
            }
        }

        private List<FileInfo> Pictures => new DirectoryInfo(path).EnumerateFiles("*.??g", SearchOption.TopDirectoryOnly).ToList();

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Initialize();
                    break;
                case Key.Left:
                    ChangePicture(--currentPictureNumber);
                    break;
                case Key.Right:
                    ChangePicture(++currentPictureNumber);
                    break;
            }
        }

        private void ChangePicture(int i)
        {
            if (!IsInRange(i))
            {
                currentPictureNumber = currentPictureNumber <= 0 ? pictureList.Count - 1 : 0;
            }
            SetPicture();
        }

        private Boolean IsInRange(int i)
        {
            return i >= 0 && i <= pictureList.Count - 1 ? true : false;
        }

        private void SetPicture()
        {
            bufferImage = new BitmapImage(new Uri(pictureList[currentPictureNumber].FullName));

            Image img = new Image
            {
                Source = bufferImage
            };

            img.Height = img.ActualHeight > image.MaxHeight ? image.MaxHeight : img.Height;
            img.Width = img.ActualWidth > image.MaxWidth ? image.MaxWidth : img.Width;

            image.Height = img.Height;
            image.Width = img.Width;

            image.Source = bufferImage;
        }
    }
}
