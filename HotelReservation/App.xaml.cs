using System.Windows;
using HotelReservation.Models;
using HotelReservation.Stores;
using HotelReservation.ViewModels;

namespace HotelReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Hotel Hotel { get; }
        private NavigationStore NavigationStore { get; }

        public App()
        {
            NavigationStore = new NavigationStore();
            Hotel = new Hotel("Hotel Rao");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore.CurrentViewModel = new ReservationsDetailsViewModel(Hotel, NavigationStore);

            MainWindow window = new MainWindow
            {
                DataContext = new MainViewModel(NavigationStore)
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}