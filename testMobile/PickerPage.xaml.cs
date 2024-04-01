using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        Frame frame;
        StackLayout st;
        string[] lehed = new string[3] { "https://moodle.edu.ee/", "https://www.tthk.ee/", "https://www.youtube.com/" };
        string[] nimetused = new string[3] { "moodle", "tuuniplaan", "koduleht" };
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Veebilehed"
            };
            foreach(string leht in nimetused)
            {
                picker.Items.Add(leht);
            }
            frame = new Frame
            {
                BorderColor = Color.Aqua,
                HasShadow = true,
                HeightRequest = 100,
                WidthRequest = 100,
            };
            webView = new WebView()
            {
                Source = new UrlWebViewSource { Url = "https://www.w3schools.com/" },
                HeightRequest = 400,
                WidthRequest = 100,
            };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Right
            };
            SwipeGestureRecognizer swipe_to_left = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Left
            };

            swipe.Swiped += Swipe_Swiped;
            webView.GestureRecognizers.Add(swipe);
            frame.GestureRecognizers.Add(swipe);
            frame.GestureRecognizers.Add(swipe_to_left);
            picker.SelectedIndexChanged += Valime_leht_avamiseks;

            st = new StackLayout
            {
                Children = { picker, webView }
            };
            st.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.GoBack();
        }

        private void Valime_leht_avamiseks(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
        }
    }
}