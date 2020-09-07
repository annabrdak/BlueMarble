using BlueMarble.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueMarble.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarbleByDate : BasePage
	{
        private bool _visibility;

		public MarbleByDate()
		{
			InitializeComponent();
            BindingContext = this;
            
        }

        public bool Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }
             

        private async void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            var newDate = e.NewDate.ToString("yyyy-MM-dd");
            var newUrl = Url.DateUrl + newDate;

            await LoadPhotos(newUrl);
            Visibility = !Photos.Any();
        }

        
        private void OnPhotoSelected(object sender, EventArgs e)
        {
            var photo = (sender as ImageButton).BindingContext as Photo;

            Navigation.PushAsync(new MarbleDetailPage(photo));
        }
    }
}