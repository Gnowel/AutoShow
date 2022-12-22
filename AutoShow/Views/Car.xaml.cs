using AutoShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace AutoShow.Views
{
    /// <summary>
    /// Логика взаимодействия для Car.xaml
    /// </summary>
    public partial class Car : Page
    {
        public List<f> _car;
        public Car()
        {
            InitializeComponent();

            _car = new List<f>()
            {
                new f(){ID = 1, Name="Lada"},
                new f(){ID = 2, Name="Aaa"},
                new f(){ID = 1, Name="Lada"},
            };
            CarGrid.ItemsSource = _car;
        }


    }

    public class f
    {
        public int ID { get; set; }
        public string Name { get; set; }    
    }

}
