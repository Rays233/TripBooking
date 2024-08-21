import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams, useLocation, useNavigate } from 'react-router-dom';
import BookingForm from './BookingForm';
import './HotelDetails.css';

function HotelDetails() {
    const { hotelId } = useParams();  // Always call hooks at the top level
    const navigate = useNavigate(); 
    const location = useLocation();
    const { checkIn, checkOut } = location.state;
    const [hotel, setHotel] = useState(null);
    const [email, setEmail] = useState('');
    const [loading, setLoading] = useState(true);
    const [selectedRoomId, setSelectedRoomId] = useState(null);

    useEffect(() => {
        const fetchHotelDetails = async () => {
            console.log(`Fetching details for hotel id: ${hotelId}`);
            try {
                const response = await axios.get(`/api/hotels/${hotelId}`);
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
    }, [hotelId]);


    if (loading) {
        return <div>Loading...</div>;
    }

    if (!hotel) {
        return <div>No details available for this hotel.</div>;
    }


    const handleBookingSuccess = (data) => {
        console.log("Booking ID from backend:", data.bookingId);
        navigate(`/booking-confirmation/${data.bookingId}`, {
            state: {
                message: data.message,
                bookingId: data.bookingId,
                checkIn,
                checkOut
            }
        });
    };

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
                            <button onClick={() => setSelectedRoomId(room.roomId)}>Reserve</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No rooms available</p>
            )}
            {selectedRoomId && (
                <BookingForm
                    roomId={selectedRoomId}
                    checkIn={checkIn}
                    checkOut={checkOut}
                    onBookingSuccess={handleBookingSuccess}
                />
            )}
        </div>
    );

}

export default HotelDetails;

