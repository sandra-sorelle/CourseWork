using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Futurum.Entities;
using Futurum.Pages;
using Futurum.Windows;

namespace Futurum.Pages
{
    public partial class ComputersPage : Page
    {
        ComputerStandart CurrentStdComputer;
        ComputerVIP CurrentVIPComputer;
        public ComputersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ComputersStandartListView.ItemsSource = DB.Entities.ComputerStandart.ToList();
                ComputersVIPListView.ItemsSource = DB.Entities.ComputerVIP.ToList();
            }
            catch (Exception)
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void ComputersStandartListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentStdComputer = (ComputerStandart)ComputersStandartListView.SelectedItem;
        }

        private void ComputersVIPListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentVIPComputer = (ComputerVIP)ComputersVIPListView.SelectedItem;
        }

        private void TimeStdBalance_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TimeStd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TimeVIP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TimeVIPBalance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
