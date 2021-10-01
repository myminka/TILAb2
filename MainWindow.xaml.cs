using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TILAb2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KeysEncrypt.Text = "";
            LetterFrequency.Text = "";

            int key = Convert.ToInt32(Key.Text);

            string str = Model.Encrypt(key);
            var dict1 = Model.FindOccuranses(str);


            var d1 = dict1.OrderBy(e => e.Key);
            var count = Model.FindCount(str);

            foreach (var elem in d1)
            {
                KeysEncrypt.Text += $"Key : {elem.Key}\t Value : {((double)elem.Value/ (double)count).ToString("P")}\n";
            }

            var dict2 = Model.FindOccuranses(Model.encStr);

            var d2 = dict2.OrderBy(e => e.Key);
            EncriptText.Text = Model.encStr;
            foreach (var elem in KeysFrequency.dict)
            {
                LetterFrequency.Text += $"Key : {elem.Key}\t Value : {(elem.Value / 100d).ToString("P")}\n";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Model.encStr is null)
            {
                Result.Text = "Text wasn't downloaded from file";
                return;
            }

            char a, b;
            try
            {
                a = Convert.ToChar(FromChar.Text.ToUpper());
                b = Convert.ToChar(ToChar.Text.ToUpper());
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
                return;
            }
            Model.encStr = Model.encStr.Replace(a, b);

            EncriptText.Text = Model.encStr;
            Result.Text = $"Succsessful changed from {a} to {b}";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SourceText.Text = Model.str;
        }
    }
}
