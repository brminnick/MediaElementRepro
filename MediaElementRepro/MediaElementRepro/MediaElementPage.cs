using System.Linq;
using Xamarin.Forms;

namespace MediaElementRepro
{
    public class MediaElementPage : ContentPage
    {
        public MediaElementPage(string title)
        {
            Title = title;

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Close",
                Command = new Command(async () =>
                {
                    if (Navigation.ModalStack.Any())
                        await Navigation.PopModalAsync();
                })
            });

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    new Button
                    {
                        Text = "Open New Media Element Page",
                        BackgroundColor = Color.LightGreen,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Start,
                        Command = new Command(async () => await Navigation.PushModalAsync(new NavigationPage(new MediaElementPage("App Crashes When Popped on iOS")){ BackgroundColor = Color.LightSlateGray }))
                    },
                    new MediaElement
                    {
                        BackgroundColor = Color.Transparent,
                        Source = "https://amssamples.streaming.mediaservices.windows.net/683f7e47-bd83-4427-b0a3-26a6c4547782/BigBuckBunny.ism/manifest(format=m3u8-aapl)",
                        AutoPlay = true,
                        Aspect = Aspect.AspectFit,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Start
                    },
                }
            };
        }
    }
}
