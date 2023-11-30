using Futurum.Entities;
using Futurum.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class EditEmployeePage : Page
    {
        Employee _employee;
        bool _new;
        public EditEmployeePage()
        {
            InitializeComponent();
            _employee = new Employee();
            _employee.employee_role = 1;

            _new = true;
        }

        public EditEmployeePage(Employee employee)
        {
            InitializeComponent();
            _employee = employee;

            _new = false;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxName.Text.Trim() == "" || TextBoxSurname.Text.Trim() == "" || TextBoxPatronymic.Text.Trim() == "" || TextBoxEmployeeNumber.Text.Trim() == "" || TextBoxLogin.Text.Trim() == "" || TextBoxPassword.Text.Trim() == "" || TextBoxPhone.Text.Trim() == "")
            {
                new CustomMessageBox("Есть незаполненные поля", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
            else
            {
                if (_new)
                {
                    DB.Entities.Employee.Add(_employee);
                }
                DB.Entities.SaveChanges();
                NavigationService.GoBack();
                new CustomMessageBox("Данные обновлены", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = _employee;
            }
            catch
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void TextBoxPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.PhoneCheck(e, TextBoxPhone);
        }
        
        private void TextBoxLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.LoginCheck(e);
        }

        private void TextBoxPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.WithoutRussianCheck(e);
        }

        private void TextBoxPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.OnlyRussianCheck(e);
        }

        private void TextBoxSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.OnlyRussianCheck(e);
        }

        private void TextBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.OnlyEnglishCheck(e);
        }

        private void TextBoxEmployeeNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Check.WithoutRussianCheck(e);
        }
        
    }
}
