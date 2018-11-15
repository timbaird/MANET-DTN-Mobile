using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;

using Xamarin.Forms;

namespace MANET_DTN_Mobile.Views
{
    public partial class CreateMessageView : ContentPage
    {
        public CreateMessageView()
        {
            InitializeComponent();
        }

        void Handle_Button_Send_Clicked(object sender, System.EventArgs e)
        {
            try{
                var nodeId = NodeData.GetNodeId();
                var vNextVal = NodeData.SequenceNextVal();

                var db = new LocalDBHandler();

                var vItem = new Item(nodeId + "-" + vNextVal, "MESSAGE",
                                    nodeId, entryRecipient.Text, entrySubject.Text,
                                    editorMessage.Text, DateTime.Now, "NORMAL");

                db.SaveItem(vItem);

                DisplayAlert("Success", "Message Sent", "OK");

                Navigation.PopAsync();

            }
            catch
            {
                DisplayAlert("Error", "Something went wrong ", "OK");

            }

        }
    }
}
