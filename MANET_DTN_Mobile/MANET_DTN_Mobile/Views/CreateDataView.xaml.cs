using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;

using Xamarin.Forms;

namespace MANET_DTN_Mobile.Views
{
    public partial class CreateDataView : ContentPage
    {
        public CreateDataView()
        {
            InitializeComponent();
        }

        void Handle_Button_Store_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var nodeId = NodeData.GetNodeId();
                var vNextVal = NodeData.SequenceNextVal();

                var db = new LocalDBHandler();
                var vItem = new Item(nodeId + "-" + vNextVal, "DATA",
                                    nodeId, "none", entryTitle.Text,
                                   editorData.Text, DateTime.Now, "NORMAL");

                db.SaveItem(vItem);

                DisplayAlert("Success", "Data Saved", "OK");

                Navigation.PopAsync();
            }
            catch
            {
                DisplayAlert("Error", "Something went wrong ", "OK");

            }
        }
    }
}
