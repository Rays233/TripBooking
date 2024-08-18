import React from 'react';

function HotelList({ hotels, onSelectHotel }) {
    return (
        <ul>
            {hotels.map(hotel => (
                <li key={hotel.Hotelid} onClick={() => onSelectHotel(hotel.Hotelid)}>
                    {hotel.name} - {hotel.city}
                </li>
            ))}
        </ul>
    );
}

export default HotelList;
