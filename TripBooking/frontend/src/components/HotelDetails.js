import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import BookingForm from './BookingForm';
import './HotelDetails.css';

function HotelDetails({ match }) {  // match is used to get the :id from the URL
    const { id } = useParams();
    const [hotel, setHotel] = useState(null);
    const [email, setEmail] = useState('');
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchHotelDetails = async () => {
            try {
                const response = await axios.get(`/api/hotels/${id}`);
                console.log('API Response:', response.data);
                setHotel(response.data);  // Update the state with fetched data
                setLoading(false);
            } catch (error) {
                console.error('Error fetching hotel details:', error);
                setLoading(false);
            }
        };

        fetchHotelDetails();  // Call the function to fetch data
    }, [id]);

    const handleReservation = async (roomId) => {
        try {
            await axios.post('/api/bookings', {
                roomId: roomId,
                email: email,
            });
            alert('Room reserved successfully!');
        } catch (error) {
            console.error('Error reserving room:', error);
            alert('Failed to reserve the room.');
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (!hotel) {
        return <div>No details available for this hotel.</div>;
    }


    return (
        <div className="hotel-details-container">
            <h2>{hotel.name}</h2>
            <p>{hotel.description}</p>
            <ul>
                {hotel.rooms.map(room => (
                    <li key={room.id}>
                        {room.type} - ${room.price} per night
                        <input
                            type="email"
                            placeholder="Enter your email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                        <button onClick={() => handleReservation(room.roomId)}>Reserve</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default HotelDetails;

