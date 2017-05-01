
using Android.App;
using Android.Content.PM;
using Android.OS;
using Mapbox;

namespace XFMapBox.Droid
{
    [Activity(Label = "XFMapBox", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            MapboxAccountManager.Start(this, "pk.eyJ1IjoiZmNjbWFuYWdlbWVudHNvZnR3YXJlIiwiYSI6ImNpb3BzMnR6ODAwNm50d2x6eWl4dTJsM3oifQ.NG-ngOgssSz0vL-yiFIRew");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

