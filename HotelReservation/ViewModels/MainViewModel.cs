using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Models;

namespace HotelReservation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public MainViewModel(Hotel hotel)
        {
            //CurrentViewModel = new NewReservationViewModel(hotel);
            CurrentViewModel = new ReservationsDetailsViewModel(hotel);
        }

    } //end of class
}
