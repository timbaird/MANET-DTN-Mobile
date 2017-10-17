using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Tests;
using MANET_DTN_Mobile.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MANET_DTN_Mobile.Views
{
    public partial class SentMessagesView : ContentPage
    {
        //ILocalDBHandler db = new StubLocalDBhandler();
        ILocalDBHandler db = new LocalDBHandler();
        ObservableCollection<Item> messages;

        public SentMessagesView()
        {
            InitializeComponent();

            messages = db.GetSentMessages();
            ListViewSentMessages.ItemsSource = messages;
           
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            Navigation.PushAsync(new MessageDetailsView(item));
        }
    }
}

