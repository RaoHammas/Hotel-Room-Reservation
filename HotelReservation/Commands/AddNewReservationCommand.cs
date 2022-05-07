using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.ViewModels;

namespace HotelReservation.Commands
{
    public class AddNewReservationCommand : CommandBase
    {
        private readonly NewReservationViewModel _newReservationViewModel;
        private readonly Hotel _hotel;

        public AddNewReservationCommand(NewReservationViewModel newReservationViewModel, Hotel hotel)
        {
            _newReservationViewModel = newReservationViewModel;
            _hotel = hotel;
        }

        public override void Execute(object parameter)
        {
            var newReservation = new Reservation
            {
                UserName = _newReservationViewModel.UserName,
                StarDateTime = _newReservationViewModel.StarDateTime,
                EndDateTime = _newReservationViewModel.EndDateTime,
                RoomId = new RoomID
                {
                    FloorNumber = _newReservationViewModel.RoomNumber, RoomNumber = _newReservationViewModel.RoomNumber
                }
            };

            try
            {
                _hotel.AddReservation(newReservation);

                MessageBox.Show("Reservation is made successfully !");
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}