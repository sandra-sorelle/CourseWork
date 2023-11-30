using Futurum.Entities;
using Futurum.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class UsersPage : Page
    {
        User CurrentUser;
        public UsersPage()
        {
            InitializeComponent();
        }

        private void UsersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentUser = (User)UsersListView.SelectedItem;
        }

        private void TextBlockAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EditUsersPage());
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TextBoxSearch.Text.ToLower().Trim();
            UsersListView.ItemsSource = DB.Entities.User.ToList().Where(x => x.user_id.ToString().ToLower().Trim().Contains(text) || x.user_money.ToString().ToLower().Trim().Contains(text) || x.user_name.ToString().ToLower().Trim().Contains(text) || x.user_surname.ToString().ToLower().Trim().Contains(text) || x.user_phone.ToString().ToLower().Trim().Contains(text) || x.user_birthday.ToString().ToLower().Trim().Contains(text)).ToList();
        }

        private void ItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditUsersPage(CurrentUser));
        }

        private void ItemDelete_Click(object sender, RoutedEventArgs e)
        {
            bool? wantToExit = new CustomMessageBox("Вы действительно хотите удалить элемент?", MessageType.Warning, MessageButtons.YesNo).ShowDialog();
            if (CurrentUser != null && wantToExit.Value)
            {
                DB.Entities.User.Remove(CurrentUser);
                DB.Entities.SaveChanges();
                UsersListView.ItemsSource = DB.Entities.User.ToList();
            }
            else
                new CustomMessageBox("Выберите элемент!", MessageType.Error, MessageButtons.OkCancel);
        }

        private void ItemTime_Click(object sender, RoutedEventArgs e)
        {
            BalanceWindow balanceWindow = new BalanceWindow(CurrentUser);
            balanceWindow.Show();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersListView.ItemsSource = DB.Entities.User.ToList();
            }
            catch 
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
    }
}
