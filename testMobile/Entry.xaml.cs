using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entry : ContentPage
    {
        Label lbl;
        Editor editor;
        public Entry()
        {
            Button Start = new Button
            {
                Text = "Tagasi Start lehele",
                BackgroundColor = Color.Firebrick,
                TextColor = Color.Fuchsia
            };

            lbl = new Label { Text = "Mingi tekst", BackgroundColor= Color.Gold, TextColor=Color.Fuchsia };

            editor = new Editor
            {
                Placeholder = "Sisesta siia tekst...",
                HorizontalOptions = LayoutOptions.Center
            };

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Pink,
                Children = {lbl, editor, Start},
                VerticalOptions = LayoutOptions.End
            };

            
            Content = st;
            Start.Clicked += Start_Clicked;
            editor.TextChanged += Editor_TextChanged;
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}