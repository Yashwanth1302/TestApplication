using Xamarin.Forms;

namespace App5
{
    public class App : Application
    {
        public App()
        {
            //// The root page of your application
            var content = new ContentPage
            {
                Title = "App5",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = AppResources.Resource.Number //"Welcome to Xamarin Forms!"
                        }
                    }
                }
            };

            //MainPage = new NavigationPage(content);
            MainPage = new NavigationPage(new BarCode());
            
            //var myButton = new Button();
            // populate UI with translated text values from resources
         
           // myButton.Text = Resource.English;
        }
        //public static Page GetMainPage()
        //{
        //    return new ContentPage
        //    {
        //        Content = new Label
        //        {
        //            Text =
        //        },
        //    };
        //}
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
