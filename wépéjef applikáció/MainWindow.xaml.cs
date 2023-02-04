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
using Microsoft.VisualBasic;

namespace wépéjef_applikáció
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

        private void SzinKeveres()
        {
            rctSzin.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
                
        }

        private void sliPiros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
            labPiros.Content = Math.Floor(sliPiros.Value);
        }

        private void sliZold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
            labZold.Content = Math.Floor(sliZold.Value);
        }

        private void sliKek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
            labKek.Content = Math.Floor(sliKek.Value);
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
           double piros = Math.Floor(Convert.ToDouble(sliPiros.Value));
           double zold = Math.Floor(Convert.ToDouble(sliZold.Value));
           double kek = Math.Floor(Convert.ToDouble(sliKek.Value));

            string szinAdatok = $"{piros};{zold};{kek}";

            if (lbSzinek.Items.Contains(szinAdatok))
            {
                MessageBox.Show("A lista már tartalmazza ezt az értéket (っ °Д °;)っ ", "Színkeverő 0.2");
            }else
            {
                lbSzinek.Items.Add(szinAdatok);
                MessageBox.Show("Sikeres hozzádás (∩^o^)⊃━☆", "Színkeverő 0.2");
            }
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.Items.Count <= 0)
            {
                MessageBox.Show("A lista már üres. (∩^o^)⊃━☆", "Színkeverő 0.2");
            }
            else if (lbSzinek.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs egy elem sincs kiválasztva. (っ °Д °;)っ", "Színkeverő 0.2");
            }
            else
            {
                lbSzinek.Items.Remove(lbSzinek.SelectedItem);
            }
            
        }


        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.Items.Count == 0)
            {
                MessageBox.Show("A lista már üres. (∩^o^)⊃━☆", "Színkeverő 0.2");
            }
            else
            {
                lbSzinek.Items.Clear();
                MessageBox.Show("A lista törölve lett. (∩^o^)⊃━☆");
            }

        }

       /* private void lbSzinek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          string[] RGBCol = lbSzinek.Items[lbSzinek.SelectedIndex].ToString().Split(';');
            
            sliPiros.Value = Convert.ToByte(RGBCol[0]);
            sliZold.Value = Convert.ToByte(RGBCol[1]);
            sliKek.Value = Convert.ToByte(RGBCol[2]);
        }*/

        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] RGBCol = lbSzinek.Items[lbSzinek.SelectedIndex].ToString().Split(';');

            sliPiros.Value = Convert.ToByte(RGBCol[0]);
            sliZold.Value = Convert.ToByte(RGBCol[1]);
            sliKek.Value = Convert.ToByte(RGBCol[2]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Biztosan ki akarsz lénpi a programból?", "Színkeverő 0.2", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void labPiros_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool valid = false;

            do
            {
                string data = Interaction.InputBox("Adjon meg egy értéket 0 és 255 között.",
                "Színkeverő 0.2", "");

                if (data.Length == 0 || data == "")
                {
                    break;
                }
                else if (Convert.ToInt32(data) < 0 || Convert.ToInt32(data) > 255)
                {
                    MessageBox.Show("Érvénytelen érték!");
                }
                else
                {
                    sliPiros.Value = Convert.ToInt32(data);
                    valid = true;   
                }
            } while (valid != true);
        }

        private void labZold_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool valid = false;

            do
            {
                string data = Interaction.InputBox("Adjon meg egy értéket 0 és 255 között.",
                "Színkeverő 0.2", "");

                if (data.Length == 0 || data == "")
                {
                    break;
                }
                else if (Convert.ToInt32(data) < 0 || Convert.ToInt32(data) > 255)
                {
                    MessageBox.Show("Érvénytelen érték!");
                }
                else
                {
                    sliZold.Value = Convert.ToInt32(data);
                    valid = true;
                }
            } while (valid != true);
        }

        private void labKek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool valid = false;

            do
            {
                string data = Interaction.InputBox("Adjon meg egy értéket 0 és 255 között.",
                "Színkeverő 0.2", "");

                if (data.Length == 0 || data == "")
                {
                    break;
                }
                else if (Convert.ToInt32(data) < 0 || Convert.ToInt32(data) > 255)
                {
                    MessageBox.Show("Érvénytelen érték!");
                }
                else
                {
                    sliKek.Value = Convert.ToInt32(data);
                    valid = true;
                }
            } while (valid != true);
        }
    }
}    


