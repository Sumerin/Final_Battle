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
using System.Diagnostics;

namespace Final_Battle
{
    /// <summary>
    /// Interaction logic for Arena.xaml
    /// </summary>
    public partial class Arena : Window
    {
        #region DataBinded
        public Character First { get; set; }
        public Character Second { get; set; }
        public Character Third { get; set; }
        public Character Fourth { get; set; }

        public Character Boss { get; set; }
        #endregion


        private List<Character> Characters = new List<Character>();
        private Character activeHero;
        private StringBuilder builder = new StringBuilder();

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

            foreach (var mob in Characters)
            {
                var attack = new MenuItem() { Header = "Attack" };
                var special = new MenuItem() { Header = "Special" };

                mob.AddMenuItem(attack, AttackEvent);
                mob.AddMenuItem(special, SpecialEvent);
            }


            Characters.Add(this.Boss);

        }

        #region Handlers
        private async void StartRound(object sender, RoutedEventArgs e)
        {
            StartRoundButton.IsEnabled = false;
            Characters.Sort();
            AddLog("Round Began!");
            foreach (var item in Characters)
            {
                activeHero = item;
                await Task.Run(() => item.ExecuteTurn());
            }
            StartRoundButton.IsEnabled = true;
        }
        private void AttackEvent(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(sender.GetType());
            AddLog(activeHero.GetType().Name + " Attacks!");
            activeHero.Attack(Boss);

        }
        private void SpecialEvent(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(sender.GetType());
            AddLog(activeHero.GetType().Name + " Special Skill");
            //activeHero.Attack(Boss);

        }
        #endregion

        private void AddLog(string log)
        {
            builder.Append(log);
            builder.Append("\n");
            LogBlock.Text = builder.ToString();
        }
    }
}
