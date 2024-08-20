import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import BookingForm from './BookingForm';
import './HotelDetails.css';

function HotelDetails({ match }) {  // match is used to get the :id from the URL
    const [hotel, setHotel] = useState(null);
    const [email, setEmail] = useState('');
    const [loading, setLoading] = useState(true);
    const { id } = useParams();

    useEffect(() => {
        const fetchHotelDetails = async () => {
            console.log(`Fetching details for hotel id: ${id}`);
            try {
                const response = await axios.get(`/api/hotels/${id}`);
                console.log('API Response:', response.data);
                if (response.data && Object.keys(response.data).length > 0) {
                    console.log('Setting hotel data:', response.data);
                    setHotel(response.data);
                } else {
                    console.error('Empty or invalid hotel data received');
                    setHotel(null);
                }
            } catch (error) {
                console.error('Error fetching hotel details:', error);
                setHotel(null);
            } finally {
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

    //if (!hotel) {
    //    return <div>No details available for this hotel.</div>;
    //}


    return(
        <div className="hotel-details-container">
            <h2>{hotel.name}</h2>
            <p>{hotel.description}</p>
            <p>City: {hotel.city}</p>
            <p>Country: {hotel.country}</p>
            <h3>Rooms:</h3>
            {hotel.rooms && hotel.rooms.length > 0 ? (
                <ul>
                    {hotel.rooms.map(room => (
                        <li key={room.roomId}>
                            <strong>{room.type}</strong> - ${room.price} per night
                            <p>{room.description}</p>
                            <button>Reserve</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No rooms available</p>
            )}
        </div>
    );

}

export default HotelDetails;

