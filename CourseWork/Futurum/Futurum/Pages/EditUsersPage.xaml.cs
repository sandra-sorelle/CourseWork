using Futurum.Entities;
using Futurum.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class EditUsersPage : Page
    {
        User _user;
        bool _new;
        public EditUsersPage()
        {
            InitializeComponent();
            _user = new User();

            _new = true;
        }

        public EditUsersPage(User user)
        {
            InitializeComponent();
            _user = user;

            _new = false;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxUserName.Text.Trim() == "" || TextBoxUserSurname.Text.Trim() == "" || TextBoxUserPhone.Text.Trim() == "" || TextBoxUserNickname.Text.Trim() == "" || DateBirthday.Text == null)
            {
                new CustomMessageBox("Есть незавполненные поля!", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
            else
            {
                if (_new)
                {
                    DB.Entities.User.Add(_user);
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
                DataContext = _user;
            }
            catch (System.Exception)
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
        private void TextBoxUserNickname_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Check.LoginCheck(e);
        }

        private void TextBoxUserPhone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Check.PhoneCheck(e, TextBoxUserPhone);
        }

        private void TextBoxUserSurname_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Check.OnlyRussianCheck(e);
        }

        private void TextBoxUserName_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Check.OnlyRussianCheck(e);
        }
    }
}
