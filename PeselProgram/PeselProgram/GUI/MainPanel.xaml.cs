using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeselProgram.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainPanel.xaml
    /// </summary>
    public partial class MainPanel : Page
    {
        readonly List<TextBox> peselBoxes;
        public MainPanel()
        {
            InitializeComponent();
            peselBoxes = new List<TextBox>();
            peselBoxes.Add(PeselNumberBox1);
            peselBoxes.Add(PeselNumberBox2);
            peselBoxes.Add(PeselNumberBox3);
            peselBoxes.Add(PeselNumberBox4);
            peselBoxes.Add(PeselNumberBox5);
            peselBoxes.Add(PeselNumberBox6);
            peselBoxes.Add(PeselNumberBox7);
            peselBoxes.Add(PeselNumberBox8);
            peselBoxes.Add(PeselNumberBox9);
            peselBoxes.Add(PeselNumberBox10);
            peselBoxes.Add(PeselNumberBox11);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PeselInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = PeselInputBox.Text;
            if (peselBoxes != null && PeselInputBox != null)
            {
                for (int i = 0; i < peselBoxes.Count; i++)
                {
                    if (i >= text.Length)
                    {
                        peselBoxes[i].Text = "";
                        continue;
                    }


                    peselBoxes[i].Text = text[i].ToString();
                }
            }
            PeselInputBox.Text = PeselInputBox.Text.Replace(" ", "");
        }

        private void PeselInputBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "";
            string text = PeselInputBox.Text;
            if (text.Length < 11)
            {
                InfoLabel.Content = "Niepełny numer pesel";
                int tl = text.Length;
                for (int i = 0; i < 12 - tl; i++)
                    text += "_ ";
                FinalPeselTextBox.Content = text;
                FinalBirthDayTextBox.Content = "";
                FinalGenderTexBox.Content = "";
                FinalCheckSumTextBox.Content = "";
                return;
            }
                

            Pesel pesel = new Pesel(text);

            if (!pesel.IsCorrect)
            {
                InfoLabel.Content = "Niepoprawna składnia numeru pesel";
                FinalPeselTextBox.Content = text;
                FinalBirthDayTextBox.Content = "";
                FinalGenderTexBox.Content = "";
                FinalCheckSumTextBox.Content = "";
                return;
            }
                
            if (!pesel.IsBirthdateCorrect)
            {
                InfoLabel.Content = "Niepoprawna data urodzenia";
                FinalPeselTextBox.Content = text;
                FinalBirthDayTextBox.Content = "Niepoprawna";
                FinalGenderTexBox.Content = "";
                FinalCheckSumTextBox.Content = "";
                return;
            }
                



            FinalPeselTextBox.Content = text;
            FinalBirthDayTextBox.Content = pesel.GetBirthDate().ToString();
            string gender = "Nieznana";
            switch (pesel.GetGender())
            {
                case Gender.Female:
                    gender = "Kobieta";
                    break;
                case Gender.Male:
                    gender = "Mężczyzna";
                    break;
            }
            FinalGenderTexBox.Content = gender;

            FinalCheckSumTextBox.Content = pesel.IsChecksumCorrect? "Poprawna" : "Niepoprawna";
        }
    }
}
