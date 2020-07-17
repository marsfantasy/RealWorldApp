using RealWorldApp.Models;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<PopularProduct> ProductsCollection;
        public ObservableCollection<Category> CategoriesCollection;

        public HomePage()
        {
            InitializeComponent();
            //建立和繫結至 ObservableCollection
            ProductsCollection = new ObservableCollection<PopularProduct>();
            //取得最受歡迎的產品
            GetPopularProducts();
            //建立和繫結至 ObservableCollection
            CategoriesCollection = new ObservableCollection<Category>();
            //取得商品目錄
            GetCategories();
            //設定登入帳號的名稱
            LblUserName.Text = Xamarin.Essentials.Preferences.Get("userName", string.Empty);
        }

        /// <summary>
        /// 取得商品目錄
        /// </summary>
        private async void GetCategories()
        {
            //throw new NotImplementedException();
            var categories = await ApiService.GetCategories();
            foreach (var category in categories)
            {
                CategoriesCollection.Add(category);
            }
            CvCategories.ItemsSource = CategoriesCollection;
        }

        /// <summary>
        /// 取得最受歡迎的產品
        /// </summary>
        private async void GetPopularProducts()
        {
            //throw new NotImplementedException();
            var products = await ApiService.GetPopularProducts();
            foreach (var product in products)
            {
                ProductsCollection.Add(product);
            }
            CvProducts.ItemsSource = ProductsCollection;
        }

        /// <summary>
        /// 點選漢堡選單圖示，開啟選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ImgMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        /// <summary>
        /// 點選畫面上漢堡選單外的任何地方，縮合漢堡選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            CloseHamBurgerMenu();
        }

        /// <summary>
        /// 當 Xamarin.Forms 頁面變成可見的時候，這個事件將會被呼叫
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var response = await ApiService.GetTotalCartItems(Preferences.Get("userId", 0));
            LblTotalItems.Text = response.totalItems.ToString();
        }

        /// <summary>CloseHamBurgerMenu
        ///
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CloseHamBurgerMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void CloseHamBurgerMenu()
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
        }

        /// <summary>
        /// 當選擇產品分類時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
            if (currentSelection == null) return;
            //Navigation.PushModalAsync(new ProductListPage());
            Navigation.PushModalAsync(new ProductListPage(currentSelection.id, currentSelection.name));
            ((CollectionView)sender).SelectedItem = null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as PopularProduct;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new ProductDetailPage(currentSelection.id));
            ((CollectionView)sender).SelectedItem = null;
        }

        /// <summary>
        /// 點選購物車圖示時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapCartIcon_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CartPage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapBluetooth_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new OrdersPage());
        }

        /// <summary>
        /// 點選訂單圖示時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapOrders_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new OrdersPage());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapCart_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CartPage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapContact_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ContactPage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapSugar_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new OrdersPage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapDetect_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DetectDetailPage(Guid.Empty));
        }
    }
}