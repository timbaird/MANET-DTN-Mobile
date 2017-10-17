using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Tests;
using MANET_DTN_Mobile.Models;

using Xamarin.Forms;

namespace MANET_DTN_Mobile.Views
{
    public partial class InboxView : ContentPage
    {
        ILocalDBHandler db = new LocalDBHandler();

        public InboxView()
        {
            InitializeComponent();

            var items = db.GetReceivedMessages();
            ListViewInbox.ItemsSource = items;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            Navigation.PushAsync(new MessageDetailsView(item));
        }
    }
}
