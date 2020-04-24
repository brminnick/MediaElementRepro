using Xamarin.Forms;

namespace MediaElementRepro
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "MediaElement_Experimental" });

            MainPage = new NavigationPage(new MediaElementPage("Video Only Plays on iOS"));
        }
    }
}
