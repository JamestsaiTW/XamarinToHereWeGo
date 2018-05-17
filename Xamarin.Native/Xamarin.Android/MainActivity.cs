using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Net;
using Android.Content;

namespace Xamarin.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var googleMapButton = FindViewById<Button>(Resource.Id.GoogleMapButton);

             googleMapButton.Click += (sender, args) =>
              {
                  Uri gmmIntentUri = Uri.Parse("google.navigation:q=25.033952,121.564478&mode=d");
                  //Ref
                  //https://developers.google.com/maps/documentation/urls/android-intents
                  //d for driving
                  //w for walking
                  //b for bicycling

                  Intent mapIntent = new Intent(Intent.ActionView, gmmIntentUri);
                  mapIntent.SetPackage("com.google.android.apps.maps");
                  StartActivity(mapIntent);
              };

            var hereWeGoButton = FindViewById<Button>(Resource.Id.HereWeGoButton);

            hereWeGoButton.Click += (sender, args) =>
            {
                Uri gmmIntentUri = Uri.Parse("here.directions://v1.0/mylocation/25.033952,121.564478&m=d");
                //Ref
                //https://developer.here.com/documentation/mobility-on-demand-toolkit/topics/navigation.html
                //d for driving
                //w for walking

                Intent mapIntent = new Intent("com.here.maps.DIRECTIONS", gmmIntentUri);
                StartActivity(mapIntent);
            };
        }
    }
}

