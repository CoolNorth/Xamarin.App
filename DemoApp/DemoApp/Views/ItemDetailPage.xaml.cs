using DemoApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DemoApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}