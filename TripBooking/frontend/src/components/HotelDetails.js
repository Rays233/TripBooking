import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import BookingForm from './BookingForm';
import './HotelDetails.css';

function HotelDetails({ match }) {  // match is used to get the :id from the URL
    const { id } = useParams();
    const [hotel, setHotel] = useState(null);
    const [selectedRoomId, setSelectedRoomId] = useState(null);

    useEffect(() => {
        const fetchHotelDetails = async () => {
            try {
                const response = await axios.get(`/api/hotels/${id}`);
                setHotel(response.data.Hotel);  // Update the state with fetched data
            } catch (error) {
                console.error('Error fetching hotel details:', error);
            }
        };

        fetchHotelDetails();  // Call the function to fetch data
    }, [id]);

    if (!hotel) {
        return <div>Loading...</div>;
    }

    return (
        <div className="hotel-details-container">
            <h2>{hotel.name}</h2>
            <p>{hotel.description}</p>
            <ul>
                {hotel.rooms.map(room => (
                    <li key={room.id}>{room.type} - ${room.price} per night
                        <button onClick={() => setSelectedRoomId(room.id)}>Reserve</button>
                    </li>
                ))}
            </ul>
            {selectedRoomId && (
                <BookingForm roomId={selectedRoomId} hotelId={id} />
            )}
        </div>
    );
}

export default HotelDetails;

