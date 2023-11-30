using Futurum.Entities;
using System.Windows;

namespace Futurum.Windows
{
    public partial class BalanceWindow : Window
    {
        User _user;
        public BalanceWindow(User user)
        {
            try
            {
                InitializeComponent();
                _user = user;
            }
            catch 
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddBalance_Click(object sender, RoutedEventArgs e)
        {
            int money = int.Parse(TextBoxMoney.Text);

            _user.user_money += money;

            if (RadioButtonCash.IsChecked == true)
            {
                ClassReport.cash += money;
            }
            else
            {
                ClassReport.credit_card += money;
            }


            DB.Entities.SaveChanges();
            this.Close();

        }
    }
}
