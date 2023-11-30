using Futurum.Entities;
using Futurum.Windows;
using System.Linq;
using System.Windows.Controls;

namespace Futurum.Pages
{
    public partial class ReportPage : Page
    {
        public ReportPage(Employee employee)
        {
            try
            {
                InitializeComponent();

                ReportListView.ItemsSource = DB.Entities.Report.Where(x => x.report_employee == employee.employee_id).ToList();
            }
            catch 
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }
    }
}
