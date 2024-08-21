import React from 'react';
import { useLocation } from 'react-router-dom';

function BookingConfirmation() {
    const location = useLocation();
    const { message, bookingId, checkIn, checkOut } = location;

    return (
        <div>
            <h1>Booking Confirmation</h1>
            <p>{message}</p>
            <p>Your booking ID is: {bookingId}</p>
            {checkIn && checkOut && (
            <p>Check-in date: {checkIn} Check-out date: {checkOut}</p>
            )}
        </div>
    );
}

export default BookingConfirmation;
