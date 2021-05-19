using Lesniarasoft.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SessionXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            var sessionKey = string.Empty;
            Session.TryGet<string>("NameOfTheKey", out sessionKey);

            if(sessionKey == null)
            {
                SessionInfo.Text = "Return to the main page and specify the Key";
                return;
            }

            var sessionValue = string.Empty;
            Session.TryGet<string>(sessionKey, out sessionValue);

            SessionInfo.Text = $"Session information is: Key:{sessionKey}, Value:{sessionValue}";
        }
    }
}