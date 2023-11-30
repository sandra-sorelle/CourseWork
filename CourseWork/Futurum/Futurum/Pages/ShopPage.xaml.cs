using Futurum.Entities;
using Futurum.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Futurum.Pages
{
    public partial class ShopPage : Page
    {
        int total = 0;
        List<Product> SelectedProducts = new List<Product>();
        ProductType CurrentProductType;
        Product CurrentProduct;
        Order order;
        
        public ShopPage()
        {
            InitializeComponent();

            ComboBoxProductType.Items.Add(new ProductType() { producttype_name = "Все" });
            foreach (var item in DB.Entities.ProductType.ToList())
            {
                ComboBoxProductType.Items.Add(item);
            }

            TextBoxSearch.TextChanged += Sorting;
            ComboBoxProductType.SelectionChanged += Sorting;
        }

        public void Sorting(object sender, EventArgs e)
        {
            var Product = DB.Entities.Product.ToList();

            if (TextBoxSearch.Text != "")
            {
                Product = Product.Where(x => x.product_name.ToLower().Trim().Contains(TextBoxSearch.Text.ToLower().Trim())).ToList();
            }

            CurrentProductType = (ProductType)ComboBoxProductType.SelectedItem;
            if (CurrentProductType.producttype_name != "Все")
            {
                Product = Product.Where(x => x.ProductType.producttype_name == CurrentProductType.producttype_name).ToList();
            }

            ShopListView.ItemsSource = Product;
        }

        private void EditProductTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EditProductPage());
        }

        private void ItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProductPage(CurrentProduct));
        }

        private void ItemDelete_Click(object sender, RoutedEventArgs e)
        {
            bool? wantToExit = new CustomMessageBox("Вы действительно хотите удалить элемент?", MessageType.Warning, MessageButtons.YesNo).ShowDialog();
            if (CurrentProduct != null && wantToExit.Value)
            {
                DB.Entities.Product.Remove(CurrentProduct);
                DB.Entities.SaveChanges();
                ShopListView.ItemsSource = DB.Entities.User.ToList();
            }
            else
                new CustomMessageBox("Выберите элемент!", MessageType.Error, MessageButtons.OkCancel);
        }

        private void ShopListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentProduct = (Product)ShopListView.SelectedItem;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ShopListView.ItemsSource = DB.Entities.Product.ToList();
            }
            catch 
            {
                new CustomMessageBox("Неизвестная ошибка", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
        }

        private void ItemOrder_Click(object sender, RoutedEventArgs e)
        {
            order = new Order();
            if (CurrentProduct.product_quantityinstock <= 0)
            {
                new CustomMessageBox("Выбранный товар отсутствует", MessageType.Error, MessageButtons.OkCancel).ShowDialog();
            }
            else
            {
                SelectedProducts.Add(CurrentProduct);

                SelectedProductsListView.ItemsSource = SelectedProducts.ToList();
                total += int.Parse(CurrentProduct.product_price.ToString().Substring(0, CurrentProduct.product_price.ToString().Length - 5));
                TextBlockTotalMoney.Text = total.ToString();
            }
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in SelectedProducts)
            {
                OrderProduct orderProduct = new OrderProduct() { orderproduct_order = order.order_id, orderproduct_product = item.product_id, orderproduct_quantity = 1 };
                orderProduct.orderproduct_totalmoney = item.product_price * orderProduct.orderproduct_quantity;
                order.order_totalmoney += orderProduct.orderproduct_totalmoney;
                DB.Entities.OrderProduct.Add(orderProduct);
                item.product_quantityinstock -= 1;
                item.product_sellthisworkshift += 1;
            }

            if (RadioButtonCash.IsChecked == true)
            {
                order.order_paymentmethod = 1;
                ClassReport.cash += int.Parse(order.order_totalmoney.ToString().Substring(0, order.order_totalmoney.ToString().Length - 5));
            }
            else
            {
                order.order_paymentmethod = 2;
                ClassReport.credit_card += int.Parse(order.order_totalmoney.ToString().Substring(0, order.order_totalmoney.ToString().Length - 5));
            }
            DB.Entities.Order.Add(order);
            DB.Entities.SaveChanges();

            SelectedProducts.Clear();
            SelectedProductsListView.ItemsSource = SelectedProducts.ToList();
            total = 0;
            ShopListView.ItemsSource = DB.Entities.Product.ToList();
            TextBlockTotalMoney.Text = "";
        }

        private void ButtonDefault_Click(object sender, RoutedEventArgs e)
        {
            SelectedProducts.Clear();
            SelectedProductsListView.ItemsSource = SelectedProducts.ToList();
            total = 0;
            TextBlockTotalMoney.Text = "";
            ShopListView.ItemsSource = DB.Entities.Product.ToList();
        }
    }
}
