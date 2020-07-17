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
    public partial class DetectDetailPage : ContentPage
    {
        public ObservableCollection<Detect.Data> DetectDataCollection;

        public DetectDetailPage(Guid detectId)
        {
            InitializeComponent();
            DetectDataCollection = new ObservableCollection<Detect.Data>();
            GetDetectDetail(detectId);
        }

        private async void GetDetectDetail(Guid detectId)
        {
            var detect = await ApiService.GetDetectDatas(detectId);
            var detectMasterDatas = detect[0].Datas;
            foreach (var item in detectMasterDatas)
            {
                DetectDataCollection.Add(item);
            }

            LvOrderDetail.ItemsSource = DetectDataCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}