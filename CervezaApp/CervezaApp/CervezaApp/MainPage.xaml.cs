using CervezaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CervezaApp
{
    public partial class MainPage : ContentPage
    {

        public static List<CervezaViewModel> cervezas = 
            new List<CervezaViewModel>() {
                    new CervezaViewModel(){
                    Name = "nombre1", Brand = "brand1", Style = "style1"
                    },
                    new CervezaViewModel()
                    {
                    Name = "nombre2", Brand = "brand2", Style = "style2"
                    },
                    new CervezaViewModel()
                    {
                    Name = "nombre3", Brand = "brand3", Style = "style3"
                    }
            };
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = null;
            listView.ItemsSource = cervezas;
        }

        async void OnNew(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CervezaPage
            {
                BindingContext = new CervezaViewModel()
            });
        }
    }
}
