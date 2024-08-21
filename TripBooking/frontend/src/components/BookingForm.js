import React, { useState } from 'react';
import axios from 'axios';
import api from './axiosConfig';
import './BookingForm.css';

function BookingForm({ roomId, checkIn, checkOut, onBookingSuccess }) {
    const [customerEmail, setCustomerEmail] = useState('');
    const [error, setError] = useState(null);

    const handleReserve = async (e) => {
        e.preventDefault();  
        setError(null);

        try {
            const bookingData = {
            RoomId: roomId,
            CustomerEmail: customerEmail,
            checkIn: new Date(checkIn).toISOString(),
            checkOut: new Date(checkOut).toISOString()
        };

            console.log('Sending booking data:', bookingData);

            const response = await api.post('/api/booking', bookingData);
            console.log('Booking response:', response.data);            

            if (response.status === 200 && response.data.bookingId) {
                onBookingSuccess({
                    bookingId: response.data.bookingId,
                    message: response.data.Message,
                    checkIn,
                    checkOut
                });  // Pass the booking confirmation data
            }

            else {
                console.error('Booking ID is missing in the response:', response.data);
                setError('Booking ID is missing in the response');
        }
        } catch (error) {
            console.error('Error creating booking:', error);
            if (error.response) {
                console.error('Response data:', error.response.data);
                console.error('Response status:', error.response.status);
                setError(`Server error: ${JSON.stringify(error.response.data)}`);
            } else if (error.request) {
                setError('No response received from server. Please try again.');
            } else {
                setError('An error occurred while setting up the request. Please try again.');
            }
        }
    };

    return (
        <form onSubmit={handleReserve}>
            <label>Email:</label>
            <input
                type="email"
                value={customerEmail}
                onChange={(e) => setCustomerEmail(e.target.value)}
                required
            />
            {error && <p className="error-message">{error}</p>}
            <button type="submit">Reserve</button>
        </form>
    );
}

export default BookingForm;
