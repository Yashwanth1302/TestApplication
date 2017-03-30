using System;
using System.Threading.Tasks;
using ZXing;
using ZXing.Mobile;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace App5
{
    public partial class BarCode : ContentPage
    {
        public BarCode()
        {
            InitializeComponent();            
        }
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;

        public async void import(Object o, EventArgs e)
        {
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
            };
            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () => {

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxing.IsAnalyzing = false;

                    // Show an alert
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");

                    // Navigate away
                    await Navigation.PopAsync();
                });

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
                AutomationId = "zxingDefaultOverlay",
            };
            overlay.FlashButtonClicked += ( sender, ee) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);
            // The root page of your application
            Content = grid;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    zxing.IsScanning = true;
        //}

        //protected override void OnDisappearing()
        //{
        //    zxing.IsScanning = false;

        //    base.OnDisappearing();
        //}
            //MobileBarcodeScanner mg = new MobileBarcodeScanner();
            //Result result=await mg.Scan();

            //var scan = new MobileBarcodeScanner();
            //scan.UseCustomOverlay = true;

            //var opt = new MobileBarcodeScanningOptions();
            //opt.PossibleFormats.Clear();
            //opt.PossibleFormats.Add(BarcodeFormat.QR_CODE);
            //var result = await scan.Scan(opt);  
        //    try
        //    {

        //        //// var scan = new MobileBarcodeScanner();
        //        //scan.UseCustomOverlay = true;
        //        //var scanner = new MobileBarcodeScanner();
        //        //scanner.TopText = "Hold For Scanning";
        //        //scanner.BottomText = "Tally Scan";
        //        ////scanner.Torch(true);
        //        //var options = new MobileBarcodeScanningOptions();
        //        //options.PossibleFormats.Clear();
        //        //options.PossibleFormats.Add(BarcodeFormat.CODABAR);
        //        //options.TryHarder = true;

        //        //var result = await scanner.Scan(options);
        //        //scan.UseCustomOverlay = false;

        //        //We can customize the top and bottom text of the default overlay
        //        //scan.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
        //        //scan.BottomText = "Wait for the barcode to automatically scan!";

        //        //Start scanning
        //        ///// var result = await scan.Scan();
        //        //HandleScanResult(result);

        //        //////var buttonScan = new Button
        //        //////{
        //        //////    Text = "Scan something!",
        //        //////};
        //        //////var label = new Label
        //        //////{
        //        //////    Text = "This is where the barcode shoud go."
        //        //////};
        //        //////buttonScan.Clicked += async delegate
        //        //////{
        //        //////    var barcode = await GetBarcode();
        //        //////    Device.BeginInvokeOnMainThread(() =>
        //        //////    {
        //        //////        // Gets here.
        //        //////        //Debug.WriteLine("Try to update label.");
        //        //////        // This works on Android, not on Windows 10 Mobile.
        //        //////        label.Text = $"Barcode : {barcode}";
        //        //////    });
        //        //////};

        //        //////var stack = new StackLayout();
        //        //////stack.Children.Add(label);
        //        //////stack.Children.Add(buttonScan);
        //        //////Content = stack;
        //        ////if (result != null)
        //        ////{
        //        ////    //updateListWithText(result.Text);
        //        ////}
        //    }
        //    catch(Exception ee)
        //    {

        //    }
        //}
        private async Task<string> GetBarcode()
        {
            var scanner = new MobileBarcodeScanner
            {
                UseCustomOverlay = false
            };
            var result = await scanner.Scan();
            // This works.
            //Debug.WriteLine($"Scanned barcode = {result.Text}");
            return result.Text;
        }
        void HandleScanResult(ZXing.Result result)
        {
            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = "Found Barcode: " + result.Text;
            else
                msg = "Scanning Canceled!";
        }

    }
}
