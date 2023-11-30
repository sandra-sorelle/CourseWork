using Futurum.Entities;
using Futurum.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class EmployeePage : Page
    {
        Employee CurrentEmployee;
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TextBoxSearch.Text.ToLower().Trim();
            EmployeeListView.ItemsSource = DB.Entities.Employee.ToList().Where(x => x.employee_login.ToString().ToLower().Trim().Contains(text) || x.employee_name.ToString().ToLower().Trim().Contains(text) || x.employee_surname.ToString().ToLower().Trim().Contains(text) || x.employee_phone.ToString().ToLower().Trim().Contains(text)).ToList();
        }

        private void TextBlockAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EditEmployeePage());
        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentEmployee = (Employee)EmployeeListView.SelectedItem;
        }

        private void ItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditEmployeePage(CurrentEmployee));
        }

        private void ItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEmployee != null && MessageBox.Show("Вы действительно хотите удалить сотрудника?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DB.Entities.Employee.Remove(CurrentEmployee);
                DB.Entities.SaveChanges();
                EmployeeListView.ItemsSource = DB.Entities.Employee.ToList();
            }
            else
                new CustomMessageBox("Выберите элемент!", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeListView.ItemsSource = DB.Entities.Employee.ToList();
            }
            catch
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void ItemReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportPage(CurrentEmployee));
        }
    }
}
