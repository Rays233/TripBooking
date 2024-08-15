import React from 'react';

function HotelDetails({ hotel }) {
    return (
        <div>
            <h2>{hotel.name}</h2>
            <p>{hotel.description}</p>
            <ul>
                {hotel.rooms.map(room => (
                    <li key={room.RoomId}>{room.type} - ${room.price} per night</li>
                ))}
            </ul>
        </div>
    );
}

export default HotelDetails;
