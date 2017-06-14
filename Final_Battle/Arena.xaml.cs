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
using System.Windows.Shapes;

namespace Final_Battle
{
    /// <summary>
    /// Interaction logic for Arena.xaml
    /// </summary>
    public partial class Arena : Window
    {
        public Character First{get;set;}
        public Character Second { get; set; }
        public Character Third { get; set; }
        public Character Fourth { get; set; }


        public Character Boss { get; set; }


        private List<Character> Characters = new List<Character>();
       
        public Arena(Character first, Character second, Character third, Character foruth)
        {
            InitializeComponent();
            this.DataContext = this;
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = foruth;

            this.Boss = new Demon();

            Characters.Add(first);
            Characters.Add(second);
            Characters.Add(third);
            Characters.Add(Fourth);

            Characters.Add(this.Boss);


           

        }

        private async void StartRound(object sender, RoutedEventArgs e)
        {
            StartRoundButton.IsEnabled = false;
            Characters.Sort();
            LogBlock.Text += "Round Began!\n";
            foreach (var item in Characters)
            {
                await Task.Run(() => item.ExecuteTurn());
            }
            StartRoundButton.IsEnabled = true;
        }
    }
}
