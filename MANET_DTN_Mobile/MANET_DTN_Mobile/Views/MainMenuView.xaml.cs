using Xamarin.Forms;
using MANET_DTN_Mobile.Views;

namespace MANET_DTN_Mobile
{
    public partial class MainMenuView : ContentPage
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        async void Handle_Button_Inbox_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new InboxView());
        }

        async void Handle_Button_Sent_Messages_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SentMessagesView());
        }

        async void Handle_Button_New_Message_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreateMessageView());
        }

        async void Handle_Button_View_Data_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DataView());
        }

        async void Handle_Button_Create_Data_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreateDataView());
        }

        async private void Handle_Button_Check_SSID_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("SSID", "Test" , "OK");
        }
    }
}
