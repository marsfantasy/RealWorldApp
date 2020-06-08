using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(int productId)
        {
            InitializeComponent();
            GetProductDetails(productId);
        }

        /// <summary>
        /// 取得單一產品說明資訊
        /// </summary>
        /// <param name="productId"></param>
        private async void GetProductDetails(int productId)
        {
            //throw new NotImplementedException();
            var product = await ApiService.GetProductById(productId);
            LblName.Text = product.name;
            LblDetail.Text = product.detail;
            ImgProduct.Source = product.FullImageurl;
            LblPrice.Text = product.price.ToString();
            LblTotalPrice.Text = LblPrice.Text;
        }

        /// <summary>
        /// 數量＋1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapIncrement_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToInt16(LblQty.Text);
            i++;
            LblQty.Text = i.ToString();
            LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToInt16(LblPrice.Text)).ToString();
        }

        /// <summary>
        /// 數量-1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapDecrement_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToInt16(LblQty.Text);
            i--;
            if (i < 1) return;
            LblQty.Text = i.ToString();
            LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToInt16(LblPrice.Text)).ToString();
        }

        /// <summary>
        /// 關閉產品說明頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}