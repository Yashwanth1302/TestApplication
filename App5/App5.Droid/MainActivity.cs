using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing;
using ZXing.Mobile;

namespace App5.Droid
{
    [Activity(Label = "App5", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            
           // ZXing.Net.Mobile.Forms.Android.Platform.Init();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());
            
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            //MobileBarcodeScanner bs = new MobileBarcodeScanner();
            //bs.Scan();
            //Result result = await bs.Scan();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(
            requestCode, permissions, grantResults);
        }
   
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        //{
        //    global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}

