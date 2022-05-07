using System;
using System.Windows.Input;
using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;

namespace HotelReservation.ViewModels
{
    public class NewReservationViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
     
        private string _userName;
        private DateTime _starDateTime;
        private DateTime _endDateTime;
        private int _floorNumber;
        private int _roomNumber;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public DateTime StarDateTime
        {
            get => _starDateTime;
            set
            {
                _starDateTime = value;
                OnPropertyChanged(nameof(StarDateTime));
            }
        }

        public DateTime EndDateTime
        {
            get => _endDateTime;
            set
            {
                _endDateTime = value;
                OnPropertyChanged(nameof(EndDateTime));
            }
        }

        public int FloorNumber
        {
            get => _floorNumber;
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        public int RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        #region Commands

        public ICommand AddReservationCommand { get; }
        public ICommand CancelReservationCommand { get; }

        #endregion


        public NewReservationViewModel(Hotel hotel, NavigationStore navigationStore)
        {
            _hotel = hotel;
            _navigationStore = navigationStore;
       
            StarDateTime = DateTime.Now;
            EndDateTime = DateTime.Now;

            AddReservationCommand = new AddNewReservationCommand(this, hotel, new NavigateService(navigationStore, CreateViewModel));
            CancelReservationCommand = new NavigateCommand(new NavigateService(navigationStore, CreateViewModel));
        }

        private ViewModelBase CreateViewModel()
        {
            return new ReservationsDetailsViewModel(_hotel, _navigationStore);
        }
    } // end of class
}