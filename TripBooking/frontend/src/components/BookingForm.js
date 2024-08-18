import React, { useState } from 'react';
import axios from 'axios';
import './BookingForm.css';

function BookingForm({ roomId, hotelId }) {
    const [email, setEmail] = useState('');
    const [confirmation, setConfirmation] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        const bookingData = {
            roomId: roomId,
            customerEmail: email,
            checkIn: new Date().toISOString(),  // Placeholder for check-in date
            checkOut: new Date().toISOString(), // Placeholder for check-out date
        };

        try {
            const response = await axios.post('/api/booking', bookingData);
            setConfirmation(response.data);  // Display confirmation or booking details
        } catch (error) {
            console.error('Error creating booking:', error);
        }
    };

    return (
        <div className="booking-form-container">
            <form onSubmit={handleSubmit}>
                <h3>Reserve Room {roomId}</h3>
                <input
                    type="email"
                    placeholder="Enter your email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <button type="submit">Confirm Booking</button>
            </form>
            {confirmation && (
                <div className="confirmation">
                    <p>Booking confirmed! Details: {JSON.stringify(confirmation)}</p>
                </div>
            )}
        </div>
    );
}

export default BookingForm;
