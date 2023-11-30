using Futurum.Entities;
using Futurum.Windows;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class EditProductPage : Page
    {
        Product _product;
        bool _new;
        public EditProductPage()
        {
            InitializeComponent();

            _product = new Product();

            _new = true;
        }

        public EditProductPage(Product product)
        {
            InitializeComponent();
            
            _product = product;

            _new = false;
        }

        private void TextBlockPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                _product.product_photo = File.ReadAllBytes(openFileDialog.FileName);
                _product.product_photopath = openFileDialog.FileName;
                BitmapImage image = new BitmapImage(new Uri((openFileDialog.FileName)));
                ImageGame.Source = image;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxProductNumber.Text.Trim() == "" || TextBoxProductName.Text.Trim() == "" || TextBoxQuantityinstock.Text.Trim() == "" || TextBoxPrice.Text.Trim() == "" || ComboBoxCategory.SelectedItem == null || ImageGame.Source == null)
            {
                new CustomMessageBox("Есть незаполненные поля!", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
            if (_new)
            {
                DB.Entities.Product.Add(_product);
            }
            DB.Entities.SaveChanges();
            NavigationService.GoBack();
            new CustomMessageBox("Данные обновлены", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxCategory.ItemsSource = DB.Entities.ProductType.ToList();

                DataContext = _product;
            }
            catch (Exception)
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void TextBoxProductNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.LoginCheck(e);
        }

        private void TextBoxProductName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.OnlyEnglishCheck(e);
        }

        private void TextBoxQuantityinstock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.OnlyDigitCheck(e);
        }

        private void TextBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.OnlyDigitCheck(e);
        }
    }
}
