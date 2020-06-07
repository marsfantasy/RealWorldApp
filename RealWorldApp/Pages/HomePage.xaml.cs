using RealWorldApp.Models;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<PopularProduct> ProductsCollection;

        public HomePage()
        {
            InitializeComponent();
            ProductsCollection = new ObservableCollection<PopularProduct>();
            //取得最受歡迎的產品
            GetPopularProducts();
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
        private async void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
        }
    }
}