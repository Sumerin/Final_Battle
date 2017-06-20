using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;

namespace Final_Battle
{
    public abstract class Character : IComparable<Character>, INotifyPropertyChanged
    {
        private readonly Brush YIELDCOLOR = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private readonly Brush TURNCOLOR = Brushes.Green;

        protected static Random random = new Random();


        #region Bind Data
        public string Hp
        {
            get
            {
                return "HP: " + _Hp;
            }
            set
            {
                NotifyPropertyChanged("Hp");
            }
        }
        public string Damage
        {
            get
            {
                return "Damage: " + _Dmg;
            }
        }
        public string Acc
        {
            get
            {
                return "Acc: " + _Acc;
            }
        }
        public string Speed
        {
            get
            {
                return "Speed: " + _Speed;
            }
        }
        public string Defense
        {
            get
            {
                return "Defense: " + _Def;
            }
        }
        public Brush Background
        {
            get
            {
                return _Background;
            }
            set
            {
                _Background = value;
                NotifyPropertyChanged("Background");
            }
        }
        public ContextMenu CharacterContextMenu
        {
            get
            {
                if (!isDone)
                {
                    return _CharacterContextMenu;
                }
                return null;
            }
        }

        public string Dir
        {
            get
            {
                return this._Dir;
            }
        }

        #endregion


        protected int _Hp;
        protected int _Dmg;
        protected double _Acc;
        protected int _Speed;
        protected double _Def;
        protected string _Dir;
        protected Brush _Background;
        protected ContextMenu _CharacterContextMenu;
        protected string power;

        protected bool isDone = true;
        public bool isFriendly = true;


        public static List<Character> Heros;
        public static Character Boss;

        public Character()
        {
            _CharacterContextMenu = new ContextMenu();

            /* var attack = new MenuItem() { Header = "Attack" };

             attack.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Attack));

             _CharacterContextMenu.Items.Add(attack);*/

            //Background = TURNCOLOR;
        }


        public void AddMenuItem(MenuItem item, Action<object, RoutedEventArgs> action)
        {
            item.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(action));

            _CharacterContextMenu.Items.Add(item);
        }

        public void AddMenuItem(Action<object, RoutedEventArgs> action)
        {
            if (!string.IsNullOrEmpty(power))
            {
                var special = new MenuItem() { Header = power };
                AddMenuItem(special, action);
            }
        }

        #region Movment/Reaction
        public virtual void Attack(Character enemy, Action<string> Log)
        {

            if (random.NextDouble() < _Acc)
            {
                Log(GetType().Name + " Attacks!!");
                double multiple = random.NextDouble();
                if (multiple > 0.8) 
                {
                    Log("CRITICAL");
                }
                int attackPower = (int)Math.Round(_Dmg * multiple);
                enemy.DealDamage(attackPower, Log);
            }
            else
            {
                Log(GetType().Name + " missed :c");
            }


            isDone = true;
            NotifyPropertyChanged("CharacterContextMenu");
        }

        public virtual void Special(List<Character> Characters, Action<string> Log)
        {
            isDone = true;
            NotifyPropertyChanged("CharacterContextMenu");
        }

        public void DealDamage(int AttackPower, Action<string> Log)
        {
            int dmgTaken = (int)Math.Round(AttackPower / _Def);
            Log(GetType().Name + " Take dmg: " + dmgTaken);
            this._Hp = this._Hp - dmgTaken;
            this.Hp = "";
        }

        public void RaiseDefense(double buff)
        {
            _Def += buff;
        }
        public void GrantHealth(int actualHeal)
        {
            _Hp += actualHeal;
            Hp = "0";
        }
        #endregion

        public virtual void ExecuteTurn()
        {
            Background = TURNCOLOR;
            isDone = false;

            NotifyPropertyChanged("CharacterContextMenu");

            while (!isDone)
            {
                Thread.Sleep(200);
            }

            Background = YIELDCOLOR;

        }

        #region interface implementaion
        public int CompareTo(Character other)
        {
            if (other == null)
            {
                return 1;
            }

            return _Speed.CompareTo(other._Speed);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion

    }
}
