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
    public partial class StepperSlider_Page : ContentPage
    {
        Frame myFrame;
        Slider redSlider;
        Slider greenSlider;
        Slider blueSlider;
        Stepper rotationStepper;
        public StepperSlider_Page()
        {
            myFrame = new Frame
            {
                BackgroundColor = Color.FromRgb(128, 128, 128),
                CornerRadius = 10,
                Content = new Label
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                }
            };

            redSlider = CreateColorSlider("Red", Color.Red, (s, e) => UpdateColor());
            greenSlider = CreateColorSlider("Green", Color.Green, (s, e) => UpdateColor());
            blueSlider = CreateColorSlider("Blue", Color.Blue, (s, e) => UpdateColor());

            rotationStepper = CreateStepper("Rotation", Color.Gray, (s, e) => UpdateRotation());

            StackLayout layout = new StackLayout
            {
                Padding = new Thickness(20),
                Spacing = 20,
                Children = { myFrame, redSlider, greenSlider, blueSlider, rotationStepper }
            };

            Content = layout;
        }

        private Slider CreateColorSlider(string label, Color color, EventHandler<ValueChangedEventArgs> valueChanged)
        {
            Label titleLabel = new Label
            {
                Text = label,
                FontSize = 16,
                TextColor = color,
                HorizontalOptions = LayoutOptions.Start
            };

            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 128,
                Margin = new Thickness(0, -10, 0, 0)
            };
            slider.ValueChanged += valueChanged;

            StackLayout sliderLayout = new StackLayout
            {
                Children = { titleLabel, slider },
                Margin = new Thickness(0, 0, 0, 10)
            };

            return slider;
        }

        private Stepper CreateStepper(string label, Color color, EventHandler<ValueChangedEventArgs> valueChanged)
        {
            Label titleLabel = new Label
            {
                Text = label,
                FontSize = 16,
                TextColor = color,
                HorizontalOptions = LayoutOptions.Start
            };

            Stepper stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 360,
                Increment = 1,
                Value = 0
            };
            stepper.ValueChanged += valueChanged;

            StackLayout stepperLayout = new StackLayout
            {
                Children = { titleLabel, stepper },
                Margin = new Thickness(0, 0, 0, 10)
            };

            return stepper;
        }

        private void UpdateColor()
        {
            myFrame.BackgroundColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
        }

        private void UpdateRotation()
        {
            myFrame.Rotation = rotationStepper.Value;
        }
    }
}