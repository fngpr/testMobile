using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new Entry(), new Time(), new DateTimePage(), new StepperSlider_Page(), new FramePage(), new Snowman(), new PickerPage(), new TicTacToe() };
        List<string> texts = new List<string>() { "Ava entry leht", "Ava time leht", "Ava kalendi leht", "Ava Stepper slider page", "Ava frame leht", "Ava Lumememm", "Ava pikker", "Trips traps trull" };
        StackLayout st;

        public StartPage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromHex("#000000") 
            };

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor = Color.FromHex("#3D0000"), 
                    TextColor = Color.White,
                    TabIndex = i
                };

                st.Children.Add(button);
                button.Clicked += Ava_vajav_leht;
            }

            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Ava_vajav_leht(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}
