using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Models;

using Xamarin.Forms;

namespace MANET_DTN_Mobile.Views
{
    public partial class DataDetailView : ContentPage
    {
        public DataDetailView(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            BindingContext = item;

            InitializeComponent();
        }
    }
}
