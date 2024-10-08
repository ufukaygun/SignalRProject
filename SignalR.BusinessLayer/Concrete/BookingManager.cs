﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDAL _bookingDAL;

        public BookingManager(IBookingDAL bookingDAL)
        {
            _bookingDAL = bookingDAL;
        }

        public void BookingStatusApproved(int id)
        {
            _bookingDAL.BookingStatusApproved(id);
        }

        public void BookingStatusCancelled(int id)
        {
           _bookingDAL.BookingStatusCancelled(id);
        }

        public void TAdd(Booking entity)
        {
            _bookingDAL.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _bookingDAL.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
           return _bookingDAL.GetAll();
        }

        public Booking TGetByID(int id)
        {
            return _bookingDAL.GetByID(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDAL.Update(entity);
        }
    }
}
