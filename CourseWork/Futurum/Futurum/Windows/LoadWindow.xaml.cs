using System;
using System.Windows;

namespace Futurum.Windows
{
    public partial class LoadWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public LoadWindow()
        {
            try
            {
                InitializeComponent();

                timer.Tick += new EventHandler(timerTick);
                timer.Interval = new TimeSpan(0, 0, 2);
                timer.Start();
            }
            catch
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
