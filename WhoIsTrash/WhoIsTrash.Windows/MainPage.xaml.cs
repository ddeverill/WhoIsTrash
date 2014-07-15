using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhoIsTrash
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        SolidColorBrush greenBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        SolidColorBrush yellowBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
        List<int> myInts = new List<int>(9);
        List<int> finalInts = new List<int>(9);
        List<TextBox> textBoxes = new List<TextBox>(9);
        List<Windows.UI.Xaml.Shapes.Rectangle> rectangles = new List<Windows.UI.Xaml.Shapes.Rectangle>(9);
        List<String> shitTalk = new List<String>();
        int amountToGrab = 5;
        Random random = new Random();


        public MainPage()
        {
            this.InitializeComponent();
            rectangles.Add(Player1Color);
            rectangles.Add(Player2Color);
            rectangles.Add(Player3Color);
            rectangles.Add(Player4Color);
            rectangles.Add(Player5Color);
            rectangles.Add(Player6Color);
            rectangles.Add(Player7Color);
            rectangles.Add(Player8Color);
            rectangles.Add(Player9Color);
            rectangles.Add(Player10Color);
            textBoxes.Add(Player1);
            textBoxes.Add(Player2);
            textBoxes.Add(Player3);
            textBoxes.Add(Player4);
            textBoxes.Add(Player5);
            textBoxes.Add(Player6);
            textBoxes.Add(Player7);
            textBoxes.Add(Player8);
            textBoxes.Add(Player9);
            textBoxes.Add(Player10);
            shitTalk.Add("Low ELO Scrub");
            shitTalk.Add("Worst Shaco NA");
            shitTalk.Add("Feeder");
            shitTalk.Add("Shit");
            shitTalk.Add("Bronzie");
            shitTalk.Add("Potato IV");
            shitTalk.Add("Trash");
            shitTalk.Add("STFU n00b");
            for (int i = 0; i < 10; i++)
            {
                rectangles[i].Fill = redBrush;
            }
            for (int i = 0; i < 10; i++)
            {
                myInts.Add(0);
            }
            for (int i = 0; i < 10; i++)
            {
                finalInts.Add(0);
            }
            amountToGrab = 5;
        }

        public void resetEverything(object sender, TappedRoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (textBoxes[i].Text.Equals(""))
                {
                    rectangles[i].Fill = redBrush;
                }
                else
                {
                    rectangles[i].Fill = yellowBrush;
                }
            }
            myInts = new List<int>(9);
            for (int i = 0; i < 10; i++)
            {
                myInts.Add(0);
            }
            finalInts = new List<int>(9);
            for (int i = 0; i < 10; i++)
            {
                finalInts.Add(0);
            }
        }

        private void PlayerColorTapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.UI.Xaml.Shapes.Rectangle tempRectangle = (Windows.UI.Xaml.Shapes.Rectangle)sender;
            
            if (tempRectangle.Fill.Equals(yellowBrush))
            {
                //Set the user as already drafted
                tempRectangle.Fill = greenBrush;
            }
            else if (tempRectangle.Fill.Equals(redBrush))
            {
                //Set the user as available to draft
                tempRectangle.Fill = yellowBrush;
            }
            else if (tempRectangle.Fill.Equals(greenBrush))
            {
                //Set the player as uneligable for draft
                tempRectangle.Fill = redBrush;
            }
        }

        private void Calculate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            for (int i = 0; i < 10; i ++)
            {
                if(rectangles[i].Fill.Equals(yellowBrush))
                {
                    myInts[i] = 1;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if(rectangles[i].Fill.Equals(greenBrush))
                {
                    finalInts[i] = 1;
                    amountToGrab--;
                }
            }

            int tempNumber = 0;
            while (amountToGrab != 0)
            {
                tempNumber = random.Next(9);
                if (myInts[tempNumber] == 1)
                {
                    finalInts[tempNumber] = 1;
                    myInts[tempNumber] = 0;
                    amountToGrab--;
                }
            }
            amountToGrab = 5;

            //Set the final ones to green
            for(int i = 0; i < 10; i++)
            {
                if(finalInts[i] == 1)
                {
                    rectangles[i].Fill = greenBrush;
                }
                else
                {
                    rectangles[i].Fill = redBrush;
                }
            }

        }

        private void PlayerGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(Player1))
            {
                Player1Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player2))
            {
                Player2Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player3))
            {
                Player3Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player4))
            {
                Player4Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player5))
            {
                Player5Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player6))
            {
                Player6Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player7))
            {
                Player7Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player8))
            {
                Player8Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player9))
            {
                Player9Color.Fill = yellowBrush;
            }
            else if (sender.Equals(Player10))
            {
                Player10Color.Fill = yellowBrush;
            }
            
        }
    }
}
