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
            string str = Model.ReadFromFile().ToUpper();
            var dict1 = Model.FindOccuranses(str);

            SourceText.Text = str;
            
            if (dict1 is null)
            {
                Keys.Text = "String is empty";
                return;
            }

            var d1 = dict1.OrderBy(e => e.Key);

            foreach (var elem in d1)
            {
                Keys.Text += $"Key : {elem.Key}\t Value : {elem.Value}\n";
            }

            string encrypt = Model.Encrypt(1, str).ToString();
            var dict2 = Model.FindOccuranses(encrypt);

            var d2 = dict2.OrderBy(e => e.Key);
            EncText.Text = encrypt;
            foreach (var elem in d2)
            {
                KeysDecrypt.Text += $"Key : {elem.Key}\t Value : {elem.Value}\n";
            }
        }
    }
}
