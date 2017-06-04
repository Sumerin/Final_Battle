using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Final_Battle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Property_Variable
        private Character _First;
        private Character _Second;
        private Character _Third;
        private Character _Fourth;

        #endregion


        #region Property
        public Character First
        {
            get { return _First; }
            set
            {
                _First = value;
                NotifyPropertyChanged("First");
            }
        }
        public Character Second
        {
            get { return _Second; }
            set
            {
                _Second = value;
                NotifyPropertyChanged("Second");
            }
        }
        public Character Third
        {
            get { return _Third; }
            set
            {
                _Third = value;
                NotifyPropertyChanged("Third");
            }
        }
        public Character Fourth
        {
            get { return _Fourth; }
            set
            {
                _Fourth = value;
                NotifyPropertyChanged("Fourth");
            }
        }
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox send = sender as ComboBox;


            switch (send.Name)
            {
                case "Check1":
                    switch ((Choice)send.SelectedIndex)
                    {
                        case Choice.Warrior:
                            First = new Warrior();
                            break;
                        case Choice.Archer:
                            First = new Archer();
                            break;
                        case Choice.Mage:
                            First = new Mage();
                            break;
                        case Choice.Cleric:
                            First = new Cleric();
                            break;
                        case Choice.Paladin:
                            First = new Paladin();
                            break;

                    }
                    break;
                case "Check2":
                    switch ((Choice)send.SelectedIndex)
                    {
                        case Choice.Warrior:
                            Second = new Warrior();
                            break;
                        case Choice.Archer:
                            Second = new Archer();
                            break;
                        case Choice.Mage:
                            Second = new Mage();
                            break;
                        case Choice.Cleric:
                            Second = new Cleric();
                            break;
                        case Choice.Paladin:
                            Second = new Paladin();
                            break;

                    }
                    break;
                case "Check3":
                    switch ((Choice)send.SelectedIndex)
                    {
                        case Choice.Warrior:
                            Third = new Warrior();
                            break;
                        case Choice.Archer:
                            Third = new Archer();
                            break;
                        case Choice.Mage:
                            Third = new Mage();
                            break;
                        case Choice.Cleric:
                            Third = new Cleric();
                            break;
                        case Choice.Paladin:
                            Third = new Paladin();
                            break;

                    }
                    break;
                case "Check4":
                    switch ((Choice)send.SelectedIndex)
                    {
                        case Choice.Warrior:
                            Fourth = new Warrior();
                            break;
                        case Choice.Archer:
                            Fourth = new Archer();
                            break;
                        case Choice.Mage:
                            Fourth = new Mage();
                            break;
                        case Choice.Cleric:
                            Fourth = new Cleric();
                            break;
                        case Choice.Paladin:
                            Fourth = new Paladin();
                            break;

                    }
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            new Arena(_First, _Second, _Third, _Fourth).Show();
            Close();

        }
    }
}
