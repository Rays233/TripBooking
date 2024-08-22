import React from 'react';
import { Link } from 'react-router-dom';
import './HotelList.css';

function HotelList({ hotels, checkIn, checkOut }) {
    if (hotels.length === 0) {
        return <p>No hotels found for the given criteria.</p>
    }
    console.log('checkIn passed to Link:', checkIn);
    console.log('checkOut passed to Link:', checkOut);

       return (
        <div className="hotel-list">
            {hotels.map(hotel => (
                <div key={hotel.hotelId} className="hotel-card">
                    <Link
                        to={`/hotels/${hotel.hotelId}`}
                        state={{ checkIn, checkOut, hotel }}
                        className="hotel-link"
                        >
                        <div className="hotel-card-content">
                            <div className="hotel-card-header">
                                <h6 className="hotel-name">{hotel.name}</h6>
                                <span className="hotel-location">{hotel.city}, {hotel.country}</span>
                            </div>
                            <div className="hotel-card-body">
                                <p className="hotel-description">{hotel.description}</p>
                                <div className="hotel-rating">{hotel.rating} stars</div>
                            </div>
                        </div>
                    </Link>
                </div>
            ))}
        </div>
    );
}

export default HotelList;

