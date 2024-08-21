import React from 'react';
import { Link } from 'react-router-dom';
function HotelList({ hotels, checkIn, checkOut}) {
    return (
        <ul>
            {hotels.map(hotel => (
                <li key={hotel.hotelId}>
                    <Link
                        to={`/hotels/${hotel.hotelId}`}
                        state={{checkIn, checkOut}}
                    >
                        {hotel.name }
                    </Link>
                    <p>{hotel.city}, {hotel.country}</p>
                </li>
            ))}
        </ul>
    );
}

export default HotelList;
