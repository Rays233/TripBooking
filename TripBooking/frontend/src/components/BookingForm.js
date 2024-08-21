import React, { useState } from 'react';
import axios from 'axios';
import api from './axiosConfig';
import './BookingForm.css';

function BookingForm({ roomId, checkIn, checkOut, onBookingSuccess }) {
    const [customerEmail, setCustomerEmail] = useState('');
    const [error, setError] = useState(null);
    const [customerName, setCustomerName] = useState('');

    const handleReserve = async (e) => {
        e.preventDefault();  
        setError(null);

        const bookingData = {
            Room: roomId,
            Customer: customerEmail,
            CustomerName: customerName,
            checkIn: new Date(checkIn).toISOString(),
            checkOut: new Date(checkOut).toISOString()
        };

        console.log('Sending booking data:', bookingData);

        try {
            const response = await api.post('/api/booking', bookingData);
            console.log('Booking response:', response.data);
            onBookingSuccess(response.data);
            

            if (response.status === 200) {
                onBookingSuccess({
                    bookingId: response.data.bookingId,
                    message: response.data.message,
                    checkIn,
                    checkOut
                });  // Pass the booking confirmation data
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
