import React from 'react';
import { useLocation, useParams } from 'react-router-dom';

function BookingConfirmation() {
    const { BookingId } = useParams();
    const location = useLocation();
    const { message, checkIn, checkOut } = location;

    return (
        <div>
            <h1>Booking Confirmation</h1>
            <p>{message}</p>
            <p>Your booking ID is: {BookingId}</p>
            {checkIn && checkOut && (
            <p>Check-in date: {checkIn} Check-out date: {checkOut}</p>
            )}
        </div>
    );
}

export default BookingConfirmation;
