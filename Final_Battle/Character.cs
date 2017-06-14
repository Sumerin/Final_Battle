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

namespace Final_Battle
{
    public abstract class Character : IComparable<Character>, INotifyPropertyChanged
    {
        private readonly Brush YIELDCOLOR = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private readonly Brush TURNCOLOR = Brushes.Green;


        #region property
        public string Hp
        {
            get
            {
                return "HP: " + _Hp;
            }
            set
            {
                _Hp = Int32.Parse(value);
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
        public Brush Background {
            get {
                return _Background;
            }
            set { 
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
        protected int _Def;
        protected string _Dir;
        protected Brush _Background;
        protected ContextMenu _CharacterContextMenu;

        protected bool isDone = true;


        public Character()
        {
            _CharacterContextMenu = new ContextMenu();

            var attack = new MenuItem() { Header = "Attack" };

            attack.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Attack));

            _CharacterContextMenu.Items.Add(attack);

            //Background = TURNCOLOR;
        }

        protected virtual void Attack(object sender, RoutedEventArgs e)
        {
            isDone = true;
            NotifyPropertyChanged("CharacterContextMenu");
        }


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
    }
}
