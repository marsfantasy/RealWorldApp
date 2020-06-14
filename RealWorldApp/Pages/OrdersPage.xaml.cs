using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using RealWorldApp.Models;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        public ObservableCollection<OrderByUser> ordersCollection;
       
        public OrdersPage()
        {
            InitializeComponent();
            ordersCollection = new ObservableCollection<OrderByUser>();
            GetOrderItems();
        }

        /// <summary>
        /// 取得訂單明細項目
        /// </summary>
        private async void GetOrderItems()
        {
            //throw new NotImplementedException();
            var orders = await ApiService.GetOrdersByUser(Preferences.Get("userId", 0));
            foreach (var order in orders)
            {
                ordersCollection.Add(order);
            }

            LvOrders.ItemsSource = ordersCollection;
        }

        /// <summary>
        /// 回前一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}