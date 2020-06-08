using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RealWorldApp.Services;
using RealWorldApp.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.PlatformConfiguration.macOSSpecific;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPage : ContentPage
    {
        public ObservableCollection<ProductByCategory> ProductByCategoryCollection;

        public ProductListPage(int categoryId, string categoryName)
        {
            InitializeComponent();
            //產品分類名稱
            LblCategoryName.Text = categoryName;
            ProductByCategoryCollection = new ObservableCollection<ProductByCategory>();
            //取得該分類的所有產品
            GetProducts(categoryId);
        }

        /// <summary>
        /// 取得該分類的所有產品
        /// </summary>
        /// <param name="id"></param>
        private async void GetProducts(int id)
        {
            //throw new NotImplementedException();
            var products = await ApiService.GetProductByCategory(id);
            foreach (var product in products)
            {
                ProductByCategoryCollection.Add(product);
            }
            CvProducts.ItemsSource = ProductByCategoryCollection;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        /// <summary>
        /// 當選擇產品時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as ProductByCategory;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new ProductDetailPage(currentSelection.id));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}