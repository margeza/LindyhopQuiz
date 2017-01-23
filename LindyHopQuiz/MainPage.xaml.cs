using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LindyHopQuiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            tablice();
            answerYES.Commands.Add(new UICommand("Dalej")
            {
                Id = 0
            });
            answerYES.DefaultCommandIndex = 0;

            question.Text = "Co to jest Lindy Hop?";

            Grid1.Visibility = Visibility.Collapsed;
            Grid2.Visibility = Visibility.Collapsed;
            Grid3.Visibility = Visibility.Visible;
            licznik = 0;

            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    default:
                        
                        break;
                }
            }
                
        }


        TextBlock[] tab = new TextBlock[8];
        Border[] bord = new Border[8];
        Button[] but = new Button[8];
        String[] kroki = new String[8];
        int licznik = 0;

        MessageDialog answerYES = new MessageDialog("Dobrze! Brawo!!!");

        private void tablice()
        {
            tab[0] = textBlock1;
            tab[1] = textBlock2;
            tab[2] = textBlock3;
            tab[3] = textBlock4;
            tab[4] = textBlock5;
            tab[5] = textBlock6;
            tab[6] = textBlock7;
            tab[7] = textBlock8;

            bord[0] = border1;
            bord[1] = border2;
            bord[2] = border3;
            bord[3] = border4;
            bord[4] = border5;
            bord[5] = border6;
            bord[6] = border7;
            bord[7] = border8;

            but[0] = darkBlueButton1;
            but[1] = darkBlueButton2;
            but[2] = darkBlueButton3;
            but[3] = darkBlueButton4;
            but[4] = darkBlueButton5;
            but[5] = darkBlueButton6;
            but[6] = darkBlueButton7;
            but[7] = darkBlueButton8;

            kroki[0] = "Rock";
            kroki[1] = "Step";
            kroki[2] = "Triple";
            kroki[3] = "Step";
            kroki[4] = "Step";
            kroki[5] = "Step";
            kroki[6] = "Triple";
            kroki[7] = "Step";
        }


        private void ButtonStep_Click(object sender, RoutedEventArgs e)
        {
            if (licznik < 8)
            {
                tab[licznik].Text = "Step";
                licznik++;
            }
            
        }

        private void ButtonRock_Click(object sender, RoutedEventArgs e)
        {
            if (licznik < 8)
            {
                tab[licznik].Text = "Rock";
                licznik++;
            }
           
        }

        private void ButtonTriple_Click(object sender, RoutedEventArgs e)
        {
            if (licznik < 8)
            {
                tab[licznik].Text = "Triple";
                licznik++;
            }
            
        }

        private void DarkBlueButton_Click(object sender, RoutedEventArgs e)
        {
            tab[licznik-1].Text = "";
            licznik--;
        }

        private async void ButtonReady_Click(object sender, RoutedEventArgs e)
        {
            String krok;
            
            for (int i = 0; i < 8; i++)
            {
                krok = tab[i].Text;
                if (krok != kroki[i])
                {
                    for (int j = 0; j < 8; j++)
                    {
                        tab[j].Text = "";
                    }
                    licznik = 0;
                    i = 7;
                    MessageDialog myMessage = new MessageDialog("Ups... To chyba nie tak, spróbuj jeszcze raz.");
                    await myMessage.ShowAsync();

                }
                else if (i == 7)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        tab[j].Text = "";
                    }
                    Grid1.Visibility = Visibility.Collapsed;
                    Grid2.Visibility = Visibility.Visible;
                    licznik = 0;
                }
            }

        }

        private async void ButtonAnswer1NO_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog answer1NO = new MessageDialog("Błąd! Lindy Hop to taniec!!!");
            answer1NO.Commands.Add(new UICommand("Zamknij"));
            await answer1NO.ShowAsync();
        }

        private async void ButtonAnswer1YES_Click(object sender, RoutedEventArgs e)
        {
            var result = await answerYES.ShowAsync();
            if ((int)result.Id == 0)
            {
                question.Text = "Skąd pochodzi Lindy Hop?";
                Grid3.Visibility = Visibility.Collapsed;
                Grid4.Visibility = Visibility.Visible;
            }
            
        }

        private async void ButtonAnswer2NO_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog answer2NO = new MessageDialog("Błąd! Lindy Hop pochodzi z Ameryki!!!");
            answer2NO.Commands.Add(new UICommand("Zamknij"));
            await answer2NO.ShowAsync();
        }

        private async void ButtonAnswer2YES_Click(object sender, RoutedEventArgs e)
        {
            var result = await answerYES.ShowAsync();
            if ((int)result.Id == 0)
            {
                question.Text = "Kto został nazwany ojcem Lindy Hop?";
                Grid4.Visibility = Visibility.Collapsed;
                Grid5.Visibility = Visibility.Visible;
            }
        }

        private async void ButtonAnswer3NO_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog answer3NO = new MessageDialog("To nie on :( Spróbuje jeszcze raz.");
            answer3NO.Commands.Add(new UICommand("Zamknij"));
            await answer3NO.ShowAsync();
        }

        private void ButtonAnswer3YES_Click(object sender, RoutedEventArgs e)
        {
            
            Grid5.Visibility = Visibility.Collapsed;
            Grid5_5.Visibility = Visibility.Visible;
            
        }
        private void ButtonDalej5_Click(object sender, RoutedEventArgs e)
        {
            question.Text = "Skąd pochodzi nazwa 'Suzi Q'?";
            Grid5_5.Visibility = Visibility.Collapsed;
            Grid6.Visibility = Visibility.Visible;
        }

        private async void ButtonAnswer4NO_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog answer4NO = new MessageDialog("Błąd! Suzi Q to imie nieśmiałej dziewczynki, z którą nikt nie tańczył na imprezach więc ona z nudów wymyśliła własny krok solo, który my dziś nazywamy 'Suzi Q'.");
            answer4NO.Commands.Add(new UICommand("Zamknij"));
            await answer4NO.ShowAsync();
        }

        private async void ButtonAnswer4YES_Click(object sender, RoutedEventArgs e)
        {
            var result = await answerYES.ShowAsync();
            if ((int)result.Id == 0)
            {
                question.Text = "Jakie są kroki najbardziej znanej figury tanecznej w Lindy Hop?";
                Grid6.Visibility = Visibility.Collapsed;
                Grid1.Visibility = Visibility.Visible;
            }
        }

        private void ButtonDalej2_Click(object sender, RoutedEventArgs e)
        {
            question.Text = "Co robią Lindy Hoperzy w dzień urodzin innego tancerza?";
            Grid2.Visibility = Visibility.Collapsed;
            Grid7.Visibility = Visibility.Visible;
        }

        private async void ButtonAnswer5NO_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog answer4NO = new MessageDialog("Lindy Hoperzy organizują Birthday Jam (Dżem) :D gdzie każdy musi zatańczyć z solenizantem.");
            answer4NO.Commands.Add(new UICommand("Zamknij"));
            await answer4NO.ShowAsync();
        }

        private async void ButtonAnswer5YES_Click(object sender, RoutedEventArgs e)
        {
            var result = await answerYES.ShowAsync();
            if ((int)result.Id == 0)
            {
                question.Text = "KONIEC";
                Grid7.Visibility = Visibility.Collapsed;
                Grid8.Visibility = Visibility.Visible;
            }
        }
    }
}
