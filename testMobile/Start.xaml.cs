using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace testMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {
            Button Entry = new Button
            {
                Text = "Entry leht",
                BackgroundColor = Color.Firebrick,
                TextColor=Color.Fuchsia
            };
            Button Time_btn = new Button
            {
                Text = "Time leht",
                BackgroundColor = Color.Firebrick,
                TextColor = Color.Fuchsia
            };
            Button stpr = new Button
            {
                Text = "Stepper slider",
                BackgroundColor = Color.Firebrick,
                TextColor = Color.Fuchsia
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Pink
            };
            Button strpg = new Button
            {
                Text = "StartPage1",
                BackgroundColor = Color.Firebrick,
                TextColor = Color.Fuchsia
            };
            st.Children.Add(strpg);
            st.Children.Add(Entry);
            st.Children.Add(Time_btn);
            st.Children.Add(stpr);
            Content = st;
            stpr.Clicked += Stpr_Clicked;
            Entry.Clicked += Entry_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
            strpg.Clicked += Strpg_Clicked; 
        }

        private async void Stpr_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperSlider_Page());
        }

        private async void Strpg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage1());
        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Time());
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry());
        }
    }
}