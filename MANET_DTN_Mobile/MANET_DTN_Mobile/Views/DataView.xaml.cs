using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Tests;

using Xamarin.Forms;

namespace MANET_DTN_Mobile.Views
{
    public partial class DataView : ContentPage
    {
        ILocalDBHandler db = new StubLocalDBhandler();

        public DataView()
        {
            InitializeComponent();

            var items = db.GetData();
            ListViewData.ItemsSource = items;
        }
    }
}
