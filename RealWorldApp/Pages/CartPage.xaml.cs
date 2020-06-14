using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RealWorldApp.Models;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<ShoppingCartItem> ShoppingCartCollection = null;

        public CartPage()
        {
            InitializeComponent();
            ShoppingCartCollection = new System.Collections.ObjectModel.ObservableCollection<ShoppingCartItem>();
            GetShopingCartItems();
            GetTotalPrice();
        }

        private async void GetTotalPrice()
        {
            //throw new NotImplementedException();
            var totalPrice = await RealWorldApp.Services.ApiService.GetCartSubTotal(Xamarin.Essentials.Preferences.Get("userId", 0));
            LblTotalPrice.Text = totalPrice.subTotal.ToString();
        }

        private async void GetShopingCartItems()
        {
            //throw new NotImplementedException();
            var shoppingCartItems = await RealWorldApp.Services.ApiService.GetShoppingCartItems(Xamarin.Essentials.Preferences.Get("userId", 0));
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                ShoppingCartCollection.Add(shoppingCartItem);
            }
            LvShoppingCart.ItemsSource = ShoppingCartCollection;
        }

        /// <summary>
        /// 回前一步驟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProceed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PlaceOrderPage(Convert.ToDouble(LblTotalPrice.Text)));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapClearCart_Tapped(object sender, EventArgs e)
        {
            var response = await RealWorldApp.Services.ApiService.ClearShoppingCart(Xamarin.Essentials.Preferences.Get("userId", 0));
            if (response)
            {
                await DisplayAlert("", "Your cart has been cleared", "Alright");
                LvShoppingCart.ItemsSource = null;
                LblTotalPrice.Text = "0";
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }
    }
}