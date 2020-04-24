using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MediaElementRepro
{
    public class ModalFormSheetNavigationPage : Xamarin.Forms.NavigationPage
    {
        public ModalFormSheetNavigationPage(Xamarin.Forms.Page root) : base(root)
        {
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
        }
    }
}
