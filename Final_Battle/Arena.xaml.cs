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
       
        public Arena(Character first, Character second, Character third, Character foruth)
        {
            InitializeComponent();
            this.DataContext = this;
            First = first;
            Second = second;
            Third = third;
            Fourth = foruth;


            Boss = new Demon();
        }
    }
}
