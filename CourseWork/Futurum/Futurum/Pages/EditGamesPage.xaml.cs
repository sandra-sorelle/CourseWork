using Futurum.Entities;
using Futurum.Windows;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class EditGamesPage : Page
    {
        Games _games;
        bool _new;
        public EditGamesPage()
        {
            InitializeComponent();
            _games = new Games();

            _new = true;
        }

        public EditGamesPage(Games games)
        {
            InitializeComponent();
            _games = games;

            _new = false;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxName.Text.Trim() == "" || ImageGame.Source == null)
            {
                new CustomMessageBox("Есть незаполненные поля", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
            else
            {
                if (_new)
                {
                    DB.Entities.Games.Add(_games);
                }
                DB.Entities.SaveChanges();
                NavigationService.GoBack();
                new CustomMessageBox("Данные обновлены", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void TextBlockPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                _games.game_photo = File.ReadAllBytes(openFileDialog.FileName);
                _games.game_photopath = openFileDialog.FileName;
                BitmapImage image = new BitmapImage(new Uri((openFileDialog.FileName)));
                ImageGame.Source = image;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = _games;
            }
            catch 
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
    }
}
