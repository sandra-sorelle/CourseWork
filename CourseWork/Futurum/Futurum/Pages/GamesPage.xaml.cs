using Futurum.Entities;
using Futurum.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class GamesPage : Page
    {
        Games CurrentGame;
        public GamesPage(Employee employee)
        {
            InitializeComponent();

            if (employee.EmployeeRole.employeerole_name == "Администратор")
            {
                TextBlockEditGames.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockEditGames.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GamesListView.ItemsSource = DB.Entities.Games.ToList().Where(x => x.game_name.ToLower().Trim().Contains(TextBoxSearch.Text.ToLower().Trim())).ToList();
        }

        private void TextBlockEditGames_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EditGamesPage());
        }

        private void GamesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentGame = (Games)GamesListView.SelectedItem;
        }

        private void ItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditGamesPage(CurrentGame));
        }

        private void ItemDelete_Click(object sender, RoutedEventArgs e)
        {
            bool? wantToExit = new CustomMessageBox("Вы действительно хотите удалить элемент?", MessageType.Warning, MessageButtons.YesNo).ShowDialog();
            if (CurrentGame != null && wantToExit.Value)
            {
                DB.Entities.Games.Remove(CurrentGame);
                DB.Entities.SaveChanges();
                GamesListView.ItemsSource = DB.Entities.Games.ToList();
            }
            else
                new CustomMessageBox("Выберите элемент!", MessageType.Error, MessageButtons.OkCancel);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GamesListView.ItemsSource = DB.Entities.Games.ToList();
            }
            catch
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
    }
}
