import React from 'react';
import { Link } from 'react-router-dom';
function HotelList({ hotels, onSelectHotel }) {
    return (
        <ul>
            {hotels.map(hotel => (
                <li key={hotel.Hotelid}>
                    <Link to={`/hotels/${hotel.id}`}>{hotel.name}</Link>
                    {hotel.city}
                </li>
            ))}
        </ul>
    );
}

export default HotelList;
