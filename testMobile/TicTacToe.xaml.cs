using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace testMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe : ContentPage
    {
        int idClear = 0;
        int move = 0;
        string whoseMove = "";
        string player1 = "x";
        string player2 = "o";
        string winState = "";

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            ClearBoxes();
        }

        private void bt1(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt2(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt3(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt4(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt5(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt6(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt7(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt8(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private void bt9(object sender, EventArgs e)
        {
            SetUp(sender);
        }

        private Xamarin.Forms.Button FindButtonById(string automationId)
        {
            var grid = ttt;

            foreach (var child in grid.Children)
            {
                if (child is Xamarin.Forms.Button button && button.AutomationId == automationId)
                {
                    return button;
                }
            }

            return null;
        }

        private Xamarin.Forms.Label FindLabelById(string automationId)
        {
            var grid = ttt;

            foreach (var child in grid.Children)
            {
                if (child is Xamarin.Forms.Label label && label.AutomationId == automationId)
                {
                    return label;
                }
            }

            return null;
        }

        private Xamarin.Forms.Switch FindSwitchById(string automationId)
        {
            var grid = ttt;

            foreach (var child in grid.Children)
            {
                if (child is Xamarin.Forms.Switch switchControl && switchControl.AutomationId == automationId)
                {
                    return switchControl;
                }
            }

            return null;
        }

        private void PlayerMove()
        {
            var mySwitch = FindSwitchById("Switch1");
            var label1 = FindLabelById("Label1");
            var label2 = FindLabelById("Label2");
            if (move % 2 == 0)
            {
                if (mySwitch.IsToggled == true)
                {
                    label1.TextColor = Color.Black;
                    label2.TextColor = Color.Black;
                    whoseMove = "1p";
                }
                else
                {
                    label1.TextColor = Color.Black;
                    label2.TextColor = Color.Firebrick;
                    whoseMove = "1p";
                }
            }
            else if (move % 2 != 0)
            {
                label1.TextColor = Color.Firebrick;
                label2.TextColor = Color.Black;
                whoseMove = "2p";
            }
        }

        private void SetSign(Xamarin.Forms.Button button)
        {
            var b1 = FindButtonById("Button1");
            var b2 = FindButtonById("Button2");
            var b3 = FindButtonById("Button3");
            var b4 = FindButtonById("Button4");
            var b5 = FindButtonById("Button5");
            var b6 = FindButtonById("Button6");
            var b7 = FindButtonById("Button7");
            var b8 = FindButtonById("Button8");
            var b9 = FindButtonById("Button9");

            var mySwitch = FindSwitchById("Switch1");

            if (!mySwitch.IsToggled) // Switch is toggled off
            {
                if (whoseMove == "1p")
                {
                    button.Text = player1;
                }
                else if (whoseMove == "2p")
                {
                    button.Text = player2;
                }
            }
            else // Switch is toggled on
            {
                if (whoseMove == "1p")
                {
                    move += 2;
                    button.Text = player1;

                    Random random = new Random();
                    int[] buttonIndices = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    bool buttonSet = false;

                    // Shuffle button indices to randomize selection order
                    for (int i = buttonIndices.Length - 1; i > 0; i--)
                    {
                        int j = random.Next(i + 1);
                        int temp = buttonIndices[i];
                        buttonIndices[i] = buttonIndices[j];
                        buttonIndices[j] = temp;
                    }

                    foreach (int index in buttonIndices)
                    {
                        Xamarin.Forms.Button randomButton = FindButtonById("Button" + index);
                        if (randomButton != null && randomButton.Text == "")
                        {
                            randomButton.Text = player2;
                            buttonSet = true;
                            break;
                        }
                    }
                }
            }
        }


        private void DetectWin()
        {
            var b1 = FindButtonById("Button1");
            var b2 = FindButtonById("Button2");
            var b3 = FindButtonById("Button3");
            var b4 = FindButtonById("Button4");
            var b5 = FindButtonById("Button5");
            var b6 = FindButtonById("Button6");
            var b7 = FindButtonById("Button7");
            var b8 = FindButtonById("Button8");
            var b9 = FindButtonById("Button9");
            if (b1.Text == "x" && b2.Text == "x" && b3.Text == "x" ||
                b4.Text == "x" && b5.Text == "x" && b6.Text == "x" ||
                b7.Text == "x" && b8.Text == "x" && b9.Text == "x" ||

                b1.Text == "x" && b4.Text == "x" && b7.Text == "x" ||
                b2.Text == "x" && b5.Text == "x" && b8.Text == "x" ||
                b3.Text == "x" && b6.Text == "x" && b9.Text == "x" ||

                b1.Text == "x" && b5.Text == "x" && b9.Text == "x" ||
                b3.Text == "x" && b5.Text == "x" && b7.Text == "x"
                )
            {
                winState = "x";
                WinPopUp(1);
                ClearBoxes();
            }
            else if (b1.Text == "o" && b2.Text == "o" && b3.Text == "o" ||
                     b4.Text == "o" && b5.Text == "o" && b6.Text == "o" ||
                     b7.Text == "o" && b8.Text == "o" && b9.Text == "o" ||

                     b1.Text == "o" && b4.Text == "o" && b7.Text == "o" ||
                     b2.Text == "o" && b5.Text == "o" && b8.Text == "o" ||
                     b3.Text == "o" && b6.Text == "o" && b9.Text == "o" ||

                     b1.Text == "o" && b5.Text == "o" && b9.Text == "o" ||
                     b3.Text == "o" && b5.Text == "o" && b7.Text == "o"
                     )
            {
                winState = "o";
                WinPopUp(2);
                ClearBoxes();
            }
            else if (b1.Text != "" &&
                     b2.Text != "" &&
                     b3.Text != "" &&
                     b4.Text != "" &&
                     b5.Text != "" &&
                     b6.Text != "" &&
                     b7.Text != "" &&
                     b8.Text != "" &&
                     b9.Text != "")
            {
                winState = "";
                WinPopUp(3);
                ClearBoxes();
            }
        }

        //private void ClearBoxes()
        //{
        //    var label1 = FindLabelById("Label1");
        //    var label2 = FindLabelById("Label2");

        //    var b1 = FindButtonById("Button1");
        //    var b2 = FindButtonById("Button2");
        //    var b3 = FindButtonById("Button3");
        //    var b4 = FindButtonById("Button4");
        //    var b5 = FindButtonById("Button5");
        //    var b6 = FindButtonById("Button6");
        //    var b7 = FindButtonById("Button7");
        //    var b8 = FindButtonById("Button8");
        //    var b9 = FindButtonById("Button9");

        //    b1.Text = "";
        //    b2.Text = "";
        //    b3.Text = "";
        //    b4.Text = "";
        //    b5.Text = "";
        //    b6.Text = "";
        //    b7.Text = "";
        //    b8.Text = "";
        //    b9.Text = "";

        //    move = 0;
        //    whoseMove = "";
        //    winState = "";
        //    if (player1 == "x" && player2 == "o")
        //    {
        //        player1 = "o";
        //        player2 = "x";
        //        label1.Text = "player1 - o";
        //        label2.Text = "player2 - x";
        //    }
        //    else
        //    {
        //        player1 = "x";
        //        player2 = "o";
        //        label1.Text = "player1 - x";
        //        label2.Text = "player2 - o";
        //    }
        //    label1.TextColor = Color.Firebrick;
        //    label2.TextColor = Color.Black;
        //}

        private void ClearBoxes()
        {
            var mySwitch = FindSwitchById("Switch1");

            idClear++;

            var label1 = FindLabelById("Label1");
            var label2 = FindLabelById("Label2");

            var b1 = FindButtonById("Button1");
            var b2 = FindButtonById("Button2");
            var b3 = FindButtonById("Button3");
            var b4 = FindButtonById("Button4");
            var b5 = FindButtonById("Button5");
            var b6 = FindButtonById("Button6");
            var b7 = FindButtonById("Button7");
            var b8 = FindButtonById("Button8");
            var b9 = FindButtonById("Button9");

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";

            move = idClear;
            whoseMove = "";
            winState = "";
            if (mySwitch.IsToggled == true)
            {
                label1.Text = "mängija - x";
                label2.Text = "bot - o";

                if(move % 2 != 0)
                {
                    move += 1;

                    Random random = new Random();
                    int randomNumber = random.Next(1, 10);
                    switch (randomNumber)
                    {
                        case 1:
                            b1.Text = player2;
                            break;
                        case 2:
                            b2.Text = player2;
                            break;
                        case 3:
                            b3.Text = player2;
                            break;
                        case 4:
                            b4.Text = player2;
                            break;
                        case 5:
                            b5.Text = player2;
                            break;
                        case 6:
                            b6.Text = player2;
                            break;
                        case 7:
                            b7.Text = player2;
                            break;
                        case 8:
                            b8.Text = player2;
                            break;
                        case 9:
                            b9.Text = player2;
                            break;
                    }
                }
            }
            else if (mySwitch.IsToggled == false)
            {
                label1.Text = "mängija1 - x";
                label2.Text = "mängija2 - o";
            }
            if (move % 2 == 0)
            {
                label1.TextColor = Color.Firebrick;
                label2.TextColor = Color.Black;
            }
            else if (move % 2 != 0)
            {
                label1.TextColor = Color.Black;
                label2.TextColor = Color.Firebrick;
            }
        }

        private async void WinPopUp(int variant)
        {
            if(variant == 1)
            {
                await DisplayAlert("mäng on läbi", "x võitis!", "jällegi");
            }
            if (variant == 2)
            {
                await DisplayAlert("mäng on läbi", "o võitis!", "jällegi");
            }
            if (variant == 3)
            {
                await DisplayAlert("mäng on läbi", "joonistada", "jällegi");
            }
        }

        private void SetUp(object sender)
        {
            var mySwitch = FindSwitchById("Switch1");
            var button = (Xamarin.Forms.Button)sender;

            if (mySwitch.IsToggled == false)
            {
                if (button.Text == "")
                {
                    PlayerMove();
                    SetSign(button);
                    move += 1;
                    DetectWin();
                }
                else
                {
                    button.Text = button.Text;
                }
            }
            else if (mySwitch.IsToggled == true)
            {
                if (button.Text == "")
                {
                    PlayerMove();
                    SetSign(button);
                    DetectWin();
                }
                else
                {
                    button.Text = button.Text;
                }
            }
        }
    }
}