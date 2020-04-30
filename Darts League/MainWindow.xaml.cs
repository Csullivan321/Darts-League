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

namespace Darts_League
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        DartsdatabaseEntities db = new DartsdatabaseEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayerCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from a in db.Players
                        select a.Name;

            PlayerCombo.ItemsSource = query.ToList();
        }

        private void PlayerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Stats = (string)PlayerCombo.SelectedItem;

            if (Stats != null)
            {
                var query = from a in db.Players
                            select new
                            {
                                Name = a.Name,
                                Age = a.Age,
                                Nationality = a.Nationality,
                                Debut = a.Debut
                            };

                PlayersStatsdg.ItemsSource = query.ToList();
            }
        }

        private void PlayerNameCombo2_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from a in db.Players
                        select a.Name;

            PlayerNameCombo2.ItemsSource = query.ToList();

            
        }

        private void Standingsdg_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from a in db.Standings
                        select new
                        {
                            Position = a.Position,
                            Name = a.Name,
                            Won = a.Won,
                            Loss = a.Loss,
                            Diff = a.Diff

                        };
            Standingsdg.ItemsSource = query.ToList();
        }
    }
}
