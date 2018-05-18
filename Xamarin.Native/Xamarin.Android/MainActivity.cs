using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Net;
using Android.Content;
using Android.Content.PM;
using System.Threading.Tasks;

namespace Xamarin.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private string googlePlayStoreBaseUrl = "https://play.google.com/store/apps/details?id=";
        private string targetLatLngStr = "25.033952,121.56447";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var googleMapButton = FindViewById<Button>(Resource.Id.GoogleMapButton);

             googleMapButton.Click += (sender, args) =>
              {
                  var packageName = "com.google.android.apps.maps";
                  if (CheckAppIsInstalled(packageName))
                  {
                      var intentUriStr = $"google.navigation:q={targetLatLngStr}&mode=d";
                      //Ref:
                      //https://developers.google.com/maps/documentation/urls/android-intents
                      //d for driving
                      //w for walking
                      //b for bicycling

                      SwapToNavigatingMap(packageName, Intent.ActionView, intentUriStr);
                      return;
                  }
                  GoToGooglePlayStoreDownload(packageName);
              };

            var hereWeGoButton = FindViewById<Button>(Resource.Id.HereWeGoButton);

            hereWeGoButton.Click += (sender, args) =>
            {
                var packageName = "com.here.app.maps";
                if (CheckAppIsInstalled(packageName))
                {
                    var intentUriStr = $"here.directions://v1.0/mylocation/{targetLatLngStr}&m=d";
                    //Ref:
                    //https://developer.here.com/documentation/mobility-on-demand-toolkit/topics/navigation.html
                    //d for driving
                    //w for walking
                   
                    SwapToNavigatingMap(packageName, "com.here.maps.DIRECTIONS", intentUriStr);
                    return;
                }

                GoToGooglePlayStoreDownload(packageName);
            };

            var wazeButton = FindViewById<Button>(Resource.Id.WazeButton);

            wazeButton.Click += (sender, args) =>
            {
                var packageName = "com.waze";
                if (CheckAppIsInstalled(packageName))
                {
                    var intentUriStr = $"waze://?ll={targetLatLngStr}&navigate=yes";
                    //Ref:
                    //https://developers.google.com/waze/deeplinks/

                    SwapToNavigatingMap(packageName, Intent.ActionView, intentUriStr);
                    return;
                }

                GoToGooglePlayStoreDownload(packageName);
            };
        }

        private async void GoToGooglePlayStoreDownload(string packageName)
        {
            Toast.MakeText(this, "在這台裝置上找不到該導航 App，將轉跳到 Google Play Store 下載此導航 App", ToastLength.Long).Show();
            await Task.Delay(2000);
            Intent mapIntent = new Intent(Intent.ActionView, Uri.Parse(googlePlayStoreBaseUrl+packageName));
            StartActivity(mapIntent);
        }

        void SwapToNavigatingMap(string packageName, string action, string intentUri)
        {
            Intent mapIntent = new Intent(action, Uri.Parse(intentUri));
            mapIntent.SetPackage(packageName);
            StartActivity(mapIntent);
        }

        bool CheckAppIsInstalled(string packageName)
        {
            PackageManager pm = PackageManager;
            try
            {
                PackageManager.GetPackageInfo(packageName, PackageInfoFlags.Activities);
                return true;
            }
            catch (PackageManager.NameNotFoundException ex)
            {
                return false;
            }
        }
    }
}

