using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BlueMarble.Services;
using BlueMarble.Droid.Services;


[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace BlueMarble.Droid.Services
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;

            if (ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }

        }
    }
}