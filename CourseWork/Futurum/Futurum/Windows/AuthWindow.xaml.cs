using Futurum.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Futurum.Windows
{
    public partial class AuthWindow : Window
    {
        Employee authEmployee = new Employee();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = DB.Entities.Employee.FirstOrDefault(x => x.employee_login == TextBoxLogin.Text && x.employee_password == PasswordBox.Password);

            if (employee != null)
            {
                employee.employee_authorization = true;
                ClassReport.staffname = employee.employee_name;
                ClassReport.starttime = DateTime.Now;
                DB.Entities.Report.Add(new Report { report_datetimeopening = DateTime.Now });
                DB.Entities.SaveChanges();

                foreach (var item in DB.Entities.Product)
                {
                    item.product_sellthisworkshift = 0;
                }
                DB.Entities.SaveChanges();

                MainWindow mainWindow = new MainWindow(employee);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                new CustomMessageBox("Неверный ввод!", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                authEmployee = DB.Entities.Employee.FirstOrDefault(x => x.employee_authorization == true);

                if (authEmployee != null)
                {
                    MainWindow mainWindow = new MainWindow(authEmployee);
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
    }
}
