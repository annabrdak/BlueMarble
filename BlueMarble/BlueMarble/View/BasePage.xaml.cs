using BlueMarble.Model;
using BlueMarble.Services;
using Refractored.XamForms.PullToRefresh;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueMarble.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        private MarbleService _marbleService = new MarbleService();
        private bool _hasNoInternet;
        private bool _isRefreshing = false;        

        public ObservableCollection<Photo> Photos { get; private set; } = new ObservableCollection<Photo>();

        public bool HasNoInternet
        {
            get
            {
                return _hasNoInternet;
            }
            set
            {
                _hasNoInternet = value;
                OnPropertyChanged(nameof(HasNoInternet));
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public BasePage()
        {            
			InitializeComponent();
           
		}

        protected virtual async Task LoadPhotos(string url = null)
        {
            CheckIfInternet();

            if (HasNoInternet)
            {
                return;
            }

            try
            {
                var photos = await _marbleService.GetPhotos(url);
                UpdateList(photos);

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message + ex.Source, "OK");
            }

        }

        private void UpdateList(IEnumerable<Photo> photos)
        {
            Photos.Clear();
            foreach (var photo in photos)
            {
                Photos.Add(photo);
            }
           
        }

        private void CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();

            if (networkConnection.IsConnected)
            {
                HasNoInternet = false;
            }
            else
            {
                HasNoInternet = true;
            }
        }

        protected async Task RefreshView()
        {
            
            Photos.Clear();
            
           
            await LoadPhotos();
            
        }
    }
}