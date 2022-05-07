using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HotelReservation.Models;
using HotelReservation.ViewModels;

namespace HotelReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Hotel Hotel { get; set; }
        public App()
        {
            Hotel = new Hotel("Hotel Rao");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.DataContext = new MainViewModel(Hotel);
            window.Show();
            base.OnStartup(e); 
        }
    }
}
