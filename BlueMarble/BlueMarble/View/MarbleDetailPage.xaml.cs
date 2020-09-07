using BlueMarble.Model;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueMarble.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarbleDetailPage : ContentPage
	{
		public MarbleDetailPage(Photo photo)
		{
			InitializeComponent();
            BindingContext = photo;
		}

        private void OpenMap(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapPage(BindingContext as Photo));
            //Navigation.PushModalAsync(new MapPage(BindingContext as Photo));
        }
    }
}