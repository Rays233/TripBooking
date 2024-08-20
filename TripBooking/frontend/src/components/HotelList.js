import React from 'react';
import { Link } from 'react-router-dom';
function HotelList({ hotels}) {
    return (
        <ul>
            {hotels.map(hotel => (
                <li key={hotel.id}>
                    <Link to={`/hotels/${hotel.id}`}>{hotel.name}</Link>
                    {hotel.city}
                    <p>{hotel.city}, {hotel.country}</p>
                </li>
            ))}
        </ul>
    );
}

export default HotelList;
