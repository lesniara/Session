using System;
using Xamarin.Forms;
using Lesniarasoft.Client;

namespace SessionXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SessionButton_Clicked(object sender, EventArgs e)
        {
            // eating our own dog food :-)
            Session.TrySet<string>("NameOfTheKey", SessionKey.Text);
            Session.TrySet<string>(SessionKey.Text, SessionValue.Text);
            await Navigation.PushAsync(new Page2());
        }
    }
}
