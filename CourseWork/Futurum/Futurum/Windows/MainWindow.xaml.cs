using Futurum.Entities;
using Futurum.Pages;
using Futurum.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Futurum
{
    public partial class MainWindow : Window
    {
        Employee _employee;
        public MainWindow(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
            MainFrame.Navigate(new ComputersPage());
            TextBlockComputersPage.TextDecorations = TextDecorations.Underline;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            ClearUnderlines();

            if (MainFrame.Content is ComputersPage)
            {
                TextBlockComputersPage.TextDecorations = TextDecorations.Underline;
            }

            if (MainFrame.Content is GamesPage)
            {
                TextBlockGamesPage.TextDecorations = TextDecorations.Underline;
            }

            if (MainFrame.Content is ShopPage)
            {
                TextBlockShopPage.TextDecorations = TextDecorations.Underline;
            }

            if (MainFrame.Content is SupportPage)
            {
                TextBlockSupportPage.TextDecorations = TextDecorations.Underline;
            }

            if (MainFrame.Content is UsersPage)
            {
                TextBlockUSersPage.TextDecorations = TextDecorations.Underline;
            }

            if (MainFrame.Content is EmployeePage)
            {
                TextBlockEmployeePage.TextDecorations = TextDecorations.Underline;
            }
        }

        public void ClearUnderlines()
        {
            TextBlockComputersPage.TextDecorations = null;
            TextBlockGamesPage.TextDecorations = null;
            TextBlockShopPage.TextDecorations = null;
            TextBlockSupportPage.TextDecorations = null;
            TextBlockUSersPage.TextDecorations = null;
            TextBlockEmployeePage.TextDecorations = null;
        }

        private void TextBlockComputersPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new ComputersPage());
        }

        private void TextBlockUSersPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new UsersPage());
        }

        private void TextBlockShopPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new ShopPage());
        }

        private void TextBlockGamesPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new GamesPage(_employee));
        }

        private void TextBlockSupportPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new SupportPage());
        }

        private void TExtBlockExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
                ClassReport.endtime = DateTime.Now;
                
                ClassReport.total_amount = ClassReport.cash + ClassReport.credit_card;

                foreach (var item in DB.Entities.Report)
                {
                    if (item.report_datetimeclosure == null)
                    {
                        ClassReport.starttime = item.report_datetimeopening;
                        ClassReport.workingtime = ClassReport.endtime - ClassReport.starttime;
                        item.report_workingtime = ClassReport.workingtime.ToString().Substring(0, 8);
                        item.report_datetimeclosure = DateTime.Now;
                        item.report_employee = _employee.employee_id;
                        item.report_totalmoney = ClassReport.total_amount;
                    }
                }
                DB.Entities.SaveChanges();
                foreach (var item in DB.Entities.Product.ToList())
                {
                    if (item.product_sellthisworkshift > 0)
                    {
                        ClassReport.servicessold.Add(new Product { product_name = item.product_name, product_sellthisworkshift = item.product_sellthisworkshift, product_quantityinstock = item.product_quantityinstock});
                    }
                }

                _employee.employee_authorization = false;
                DB.Entities.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Close();

                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("example.pdf", FileMode.Create));
                doc.Open();

                Paragraph title = new Paragraph("Futurum", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK));
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph staffnameParagraph = new Paragraph();
                staffnameParagraph.Add(new Chunk("\nStaff name:", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                staffnameParagraph.Add(new Chunk(new VerticalPositionMark()));
                staffnameParagraph.Add(new Chunk(ClassReport.staffname, FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                doc.Add(staffnameParagraph);

                Paragraph startTimeParagraph = new Paragraph();
                startTimeParagraph.Add(new Chunk("Start time:", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                startTimeParagraph.Add(new Chunk(new VerticalPositionMark()));
                startTimeParagraph.Add(new Chunk(ClassReport.starttime.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                doc.Add(startTimeParagraph);

                Paragraph endTimeParagraph = new Paragraph();
                endTimeParagraph.Add(new Chunk("End time:", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                endTimeParagraph.Add(new Chunk(new VerticalPositionMark()));
                endTimeParagraph.Add(new Chunk(ClassReport.endtime.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                doc.Add(endTimeParagraph);

                Paragraph workingTimeParagraph = new Paragraph();
                workingTimeParagraph.Add(new Chunk("Working time:", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                workingTimeParagraph.Add(new Chunk(new VerticalPositionMark()));
                workingTimeParagraph.Add(new Chunk(ClassReport.workingtime.ToString().Substring(0, 8), FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                doc.Add(workingTimeParagraph);

                Paragraph cashParagraph = new Paragraph();
                cashParagraph.Add(new Chunk("Cash:", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                cashParagraph.Add(new Chunk(new VerticalPositionMark()));
                cashParagraph.Add(new Chunk(ClassReport.cash.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                doc.Add(cashParagraph);

                Paragraph creditcardParagraph = new Paragraph();
                creditcardParagraph.Add(new Chunk("Credit card:", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                creditcardParagraph.Add(new Chunk(new VerticalPositionMark()));
                creditcardParagraph.Add(new Chunk(ClassReport.credit_card.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                doc.Add(creditcardParagraph);

                Paragraph totalAmountParagraph = new Paragraph();
                totalAmountParagraph.Add(new Chunk("Total amount:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)));
                totalAmountParagraph.Add(new Chunk(new VerticalPositionMark()));
                totalAmountParagraph.Add(new Chunk(ClassReport.total_amount.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)));
                doc.Add(totalAmountParagraph);

                Paragraph sellThisShiftParagraph = new Paragraph();
                sellThisShiftParagraph.Add(new Chunk("\nPRODUCT NAME", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)));
                sellThisShiftParagraph.Add(new Chunk(new VerticalPositionMark()));
                sellThisShiftParagraph.Add(new Chunk("SOLD ITEMS/LEFT ITEMS\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)));
                foreach (var item in ClassReport.servicessold)
                {
                    sellThisShiftParagraph.Add(new Chunk(item.product_name, FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                    sellThisShiftParagraph.Add(new Chunk(new VerticalPositionMark()));
                    sellThisShiftParagraph.Add(new Chunk(item.product_sellthisworkshift.ToString() + "/" + item.product_quantityinstock.ToString() + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
                }
                doc.Add(sellThisShiftParagraph);
                doc.Close();

                new CustomMessageBox("Смена завершена, отчет выгружен в pdf", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
        }

        private void TextBlockEmployeePage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new EmployeePage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_employee.EmployeeRole.employeerole_name == "Администратор")
                {
                    TextBlockEmployeePage.Visibility = Visibility.Collapsed;
                }
                else
                {
                    TextBlockEmployeePage.Visibility = Visibility.Visible;
                }
            }
            catch 
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
            
        }
    }
}
