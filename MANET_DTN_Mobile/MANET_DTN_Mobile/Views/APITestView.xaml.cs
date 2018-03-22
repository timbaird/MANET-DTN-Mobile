using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;
using Xamarin.Forms;
using MANET_DTN_Mobile.Controllers;


namespace MANET_DTN_Mobile.Views
{
    public partial class APITestView : ContentPage
    {
       // APIClient api = new APIClient();

        public APITestView()
        {
            InitializeComponent();

            //var service = DependencyService.Get<IWiFiConnectionService>();

            //var ssid = service.GetSSID();

            //service.SetAlarm();

            output.Text = "nothing set";
 
        }
    }
}