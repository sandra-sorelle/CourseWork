using Futurum.Windows;
using System.Windows.Controls;

namespace Futurum.Pages
{
    public partial class SupportPage : Page
    {
        public SupportPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception)
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
    }
}
