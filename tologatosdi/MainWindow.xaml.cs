using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tologatosdi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> gombok = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            grdPanel.ColumnDefinitions.Clear();
            grdPanel.RowDefinitions.Clear();


            for (int oszlopIndex = 0; oszlopIndex < 3; oszlopIndex++)
            {
                ColumnDefinition ujOszlop = new ColumnDefinition();
                grdPanel.ColumnDefinitions.Add(ujOszlop);
            }

            for (int sorIndex = 0; sorIndex < 3; sorIndex++)
            {
                RowDefinition ujSor = new RowDefinition();
                grdPanel.RowDefinitions.Add(ujSor);
            }


            int szam = 9;
            for (int i = 0; i < szam; i++)
            {
                if (i == 8)
                {
                    Button hidden = new();
                    hidden.Visibility = Visibility.Hidden;
                    gombok.Add(hidden);
                    break;
                }
                else
                {

                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click1;
                    gombok.Add(button);

                }
            }
            Keveres(gombok);


            for (int i = 0; i < szam; i++)
            {
                grdPanel.Children.Add(gombok[i]);
                Grid.SetColumn(gombok[i], i % 3);
                Grid.SetRow(gombok[i], i / 3);
            }


        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Button gomb = (Button)sender;
            foreach (var item in gombok)
            {
                if (item.Visibility==Visibility.Hidden)
                {
                    item.Visibility = Visibility.Visible;
                    item.Content = gomb.Content; item.Click += Button_Click1;
                }
            }

            gomb.Visibility = Visibility.Hidden;
            gomb.Content = string.Empty;
        }

        private static void Keveres<T>(List<T> lista)
        {
            Random rng = new Random();
            int szamolas = lista.Count;
            while (szamolas > 1)
            {
                szamolas--;
                int randomplusz = rng.Next(szamolas + 1);
                var ertek = lista[randomplusz];
                lista[randomplusz] = lista[szamolas];
                lista[szamolas] = ertek;
            }
        }
    }

}