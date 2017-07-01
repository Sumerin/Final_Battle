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
                return "HP: " + _hp;
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
                return "Damage: " + _dmg;
            }
        }
        public string Acc
        {
            get
            {
                return "Acc: " + _acc;
            }
        }
        public string Speed
        {
            get
            {
                return "Speed: " + _speed;
            }
        }
        public string Defense
        {
            get
            {
                return "Defense: " + _def;
            }
        }
        public Brush Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                NotifyPropertyChanged("Background");
            }
        }
        public ContextMenu CharacterContextMenu
        {
            get
            {
                if (!isDone)
                {
                    return _characterContextMenu;
                }
                return null;
            }
        }

        public string Dir
        {
            get
            {
                return this._dir;
            }
        }
        public string PowerDescription
        {
            get
            {
                return _powerDescription;
            }
        }
        #endregion


        protected int _hp;
        protected int _dmg;
        protected double _acc;
        protected int _speed;
        protected double _def;
        protected string _dir;
        protected Brush _background;
        protected ContextMenu _characterContextMenu;
        protected string power;
        protected string _powerDescription;

        protected bool isDone = true;
        public bool isFriendly = true;
        public bool isAlive = true;


        public Character()
        {
            _characterContextMenu = new ContextMenu();
        }


        public void AddMenuItem(MenuItem item, Action<object, RoutedEventArgs> action)
        {
            item.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(action));

            _characterContextMenu.Items.Add(item);
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

            if (random.NextDouble() < _acc)
            {
                Log(GetType().Name + " Attacks!!");
                double multiple = random.NextDouble();
                if (multiple > 0.8)
                {
                    Log("CRITICAL");
                }
                int attackPower = (int)Math.Round(_dmg * multiple);
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
            int dmgTaken = (int)Math.Round(AttackPower / _def);

            Log(GetType().Name + " Take dmg: " + dmgTaken);

            this._hp = this._hp - dmgTaken;
            this.Hp = "";

            isAlive = this._hp > 0;
        }

        public void RaiseDefense(double buff)
        {
            _def += buff;
        }
        public void GrantHealth(int actualHeal)
        {
            _hp += actualHeal;
            Hp = "0";
        }
        #endregion

        public virtual void ExecuteTurn()
        {
            if (isAlive)
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
        }

        #region interface implementaion
        public int CompareTo(Character other)
        {
            if (other == null)
            {
                return 1;
            }

            return _speed.CompareTo(other._speed);
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
