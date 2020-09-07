
using BlueMarble.Model;
using BlueMarble.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueMarble.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarblePage : BasePage
	{
        private bool _alertAllowed = true;

        
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await RefreshView();
                    
                    //this is a workaround from github, because there is a problem with refreshing in this layout,
                    //and for some reason layout has to be called directly - otherwise IsRefreshing is always true
                    //even though OnPropertyChanged fires properly

                    pullToRefreshLayout.IsRefreshing = false;
                   
                });
            }
        }

        public MarblePage()
		{
            BindingContext = this;
            InitializeComponent();                    
		}

        protected async override void OnAppearing()
        {

            if (!Photos.Any())
                await LoadPhotos();

            CheckIfSatelliteDown();
            base.OnAppearing();
        }

        private void OnPhotoSelected(object sender, EventArgs e)
        {
            var photo = (sender as ImageButton).BindingContext as Photo;

            Navigation.PushAsync(new MarbleDetailPage(photo));

            //command with parameter??
        }

        private void CheckIfSatelliteDown()
        {
            if (Photos.Any() && Photos[0].ParsedDate.Date != DateTime.Now.Date && _alertAllowed)
            {
                DisplayAlert("Information", 
                    $"Please note that latest images were captured on: {Photos[0].ParsedDate.Date:d}. It is possible that the satellite is down.", "OK");
                _alertAllowed = false;
            }
        }

        

    }
}