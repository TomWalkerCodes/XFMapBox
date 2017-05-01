using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFMapBox.Droid;
using XFMapBox.Controls;
using Mapbox.Geometry;
using Mapbox.Maps;
using Mapbox.Annotations;
using Mapbox.Camera;

[assembly: ExportRenderer(typeof(FCCMapBox), typeof(MapBoxRenderer_Droid))]
namespace XFMapBox.Droid
{
    public class MapBoxRenderer_Droid : ViewRenderer<FCCMapBox, MapView>, IOnMapReadyCallback
    {
        private static readonly LatLng LOS_ANGELES = new LatLng(34.0539440, -118.242622);
        private static readonly LatLng NEW_YORK = new LatLng(40.712730, -74.005953);

        private MapView _MapView;

        protected override void OnElementChanged(ElementChangedEventArgs<FCCMapBox> e)
        {
            base.OnElementChanged(e);

            MapboxMapOptions options = new MapboxMapOptions();
            options.InvokeScrollGesturesEnabled(true);
            options.InvokeRotateGesturesEnabled(true);
            options.InvokeTiltGesturesEnabled(true);
            options.InvokeZoomGesturesEnabled(true);

            _MapView = new MapView(Context, options);
            _MapView.OnCreate(null);
            _MapView.SetStyle(Mapbox.Constants.Style.MapboxStreets);
            _MapView.GetMapAsync();
            SetNativeControl(_MapView);
        }

        public void OnMapReady(MapboxMap map)
        {
            var uiSettings = map.UiSettings;
            uiSettings.SetAllGesturesEnabled(true);

            var marker = new MarkerOptions();

            marker.SetTitle("Los Angeles");
            marker.SetSnippet("City Hall");
            marker.SetPosition(LOS_ANGELES);

            map.AddMarker(marker);

            marker.SetTitle("New York");
            marker.SetSnippet("City Hall");
            marker.SetPosition(NEW_YORK);

            map.AddMarker(marker);

            var bounds = new LatLngBounds.Builder()
                .Include(NEW_YORK)
                .Include(LOS_ANGELES)
                .Build();

            map.MoveCamera(CameraUpdateFactory.NewLatLngBounds(bounds, 8));

        }
    }
}