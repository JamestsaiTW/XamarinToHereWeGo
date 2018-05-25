using Foundation;
using System;
using UIKit;

namespace Xamarin.iOS
{
    public partial class ViewController : UIViewController, IUIAlertViewDelegate
    {
		public ViewController (IntPtr handle) : base (handle)
		{
		}

        private string targetLatLngStr = "25.033952,121.56447";
        private string appBaseLink = "itms-apps://itunes.apple.com/app/id{0}?mt=8";

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            AppleMapButton.TouchUpInside += (sender, args) =>
            {
                CheckNavigationMapOrDownload("http://", "http://maps.apple.com/maps?daddr={0}&dirflg=d",  new string('0', 9));
            };

            GoogleMapButton.TouchUpInside += (sender, args) =>
             {
                 CheckNavigationMapOrDownload("comgooglemaps://", "comgooglemaps://?daddr={0}&directionsmode=driving", "585027354");
             };

             HereWeGoButton.TouchUpInside += (sender, args) =>
              {
                  CheckNavigationMapOrDownload("here-route://", "here-route://mylocation/{0}?&m=d", "955837609");
              };

             WazeButton.TouchUpInside += (sender, args) =>
             {
                 CheckNavigationMapOrDownload("waze://", "waze://?ll={0}&navigate=yes", "323229106");
             };
        }

        private void CheckNavigationMapOrDownload(string appScheme, string appLinkNavigation, string appStoreId)
        {
            if (UIApplication.SharedApplication.CanOpenUrl(new Foundation.NSUrl(appScheme)))
            {
                SwapToNavigatingMap(appLinkNavigation);
                return;
            }
            GoToAppStoreDownload(appStoreId);
        }

        private void GoToAppStoreDownload(string appId)
        {
            var alertController = UIAlertController.Create("通知", "在這台裝置上找不到該導航 App, 按下 OK 後將轉跳到 App Store 下載此 App", UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("取消", UIAlertActionStyle.Cancel, null));
            alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, action=>
            {
                    var request = string.Format(appBaseLink, appId);
                    UIApplication.SharedApplication.OpenUrl(new NSUrl(request));
            }));
            PresentViewController(alertController, animated: true, completionHandler: null);
        }

        void SwapToNavigatingMap(string nsUrlStr)
        { 
            var request = string.Format(nsUrlStr, targetLatLngStr);
            UIApplication.SharedApplication.OpenUrl(new NSUrl(request));
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
    }
}