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
using System.Windows.Threading;

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
        private object logMonitor = new object();

        public Arena(Character first, Character second, Character third, Character foruth)
        {
            Random random = new Random();

            InitializeComponent();
            this.DataContext = this;
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = foruth;



            Characters.Add(first);
            Characters.Add(second);
            Characters.Add(third);
            Characters.Add(Fourth);

            foreach (var mob in Characters)
            {
                var attack = new MenuItem() { Header = "Attack" };

                mob.AddMenuItem(attack, AttackEvent);
                mob.AddMenuItem(SpecialEvent);
            }
            switch (random.Next(3))
            {
                case 0:
                    Boss = new Rabbit(Characters, AddLog);
                    break;
                case 1:
                    Boss = new Demon(Characters, AddLog);
                    break;
                case 2:
                    Boss = new Shark(Characters, AddLog);
                    break;
            }
            Characters.Add(this.Boss);
            Characters.Sort();
            Characters.Reverse();
        }

        #region Handlers
        private async void StartRound(object sender, RoutedEventArgs e)
        {
            StartRoundButton.IsEnabled = false;
            bool isHeroAlive = false;
            AddLog("Round Began!");
            foreach (var item in Characters)
            {
                activeHero = item;
                await Task.Run(() => item.ExecuteTurn());
                if (item != Boss)
                {
                    isHeroAlive = item.isAlive ? true : isHeroAlive; //if hero is Alive will be true if dead stay as it was
                }
                if (!Boss.isAlive)
                {
                    AddLog("YOU HAVE WON!!");
                    return;
                }
            }
            if (!isHeroAlive)
            {
                AddLog("YOU HAVE LOSE!!");
                return;
            }
            StartRoundButton.IsEnabled = true;
        }
        private void AttackEvent(object sender, RoutedEventArgs e)
        {

            this.activeHero.Attack(Boss, AddLog);

        }
        private void SpecialEvent(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(sender.GetType());
            this.activeHero.Special(Characters, AddLog);

        }
        #endregion

        private void AddLog(string log)
        {
            lock (logMonitor)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() =>
                {
                    this.builder.Append(log);
                    this.builder.Append("\n");
                    LogBlock.Text = builder.ToString();
                }));
            }
        }
    }
}
