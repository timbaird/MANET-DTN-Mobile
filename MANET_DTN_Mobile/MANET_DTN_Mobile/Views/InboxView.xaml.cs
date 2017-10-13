using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Tests;

using Xamarin.Forms;

namespace MANET_DTN_Mobile.Views
{
    public partial class InboxView : ContentPage
    {
        ILocalDBHandler db = new StubLocalDBhandler();

        public InboxView()
        {
            InitializeComponent();

            var items = db.GetReceivedMessages();
            ListViewInbox.ItemsSource = items;
        }
    }
}
