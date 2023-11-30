using System.Windows;

namespace Futurum.Windows
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {
                case MessageType.Info:
                    txtTitle.Text = "Сообщение";
                    break;

                case MessageType.Confirmation:
                    txtTitle.Text = "Предупреждение";
                    break;

                case MessageType.Success:
                    {
                        txtTitle.Text = "Успех";
                    }
                    break;

                case MessageType.Warning:
                    txtTitle.Text = "Внимание";
                    break;

                case MessageType.Error:
                    {
                        txtTitle.Text = "Ошибка";
                    }
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
            btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed; BorderYes.Visibility = Visibility.Collapsed; BorderNo.Visibility = Visibility.Collapsed;
            break;
                case MessageButtons.YesNo:
                btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed; BorderCancel.Visibility = Visibility.Collapsed; BorderOk.Visibility = Visibility.Collapsed;
                    break;
            case MessageButtons.Ok:
                btnOk.Visibility = Visibility.Visible;
                BorderOk.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Collapsed; BorderYes.Visibility = Visibility.Collapsed; BorderNo.Visibility = Visibility.Collapsed;
                btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed; BorderCancel.Visibility = Visibility.Collapsed;
                break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
    public enum MessageType
    {
        Info,
        Confirmation,
        Success,
        Warning,
        Error,
    }
    public enum MessageButtons
    {
        OkCancel,
        YesNo,
        Ok,
    }
}
