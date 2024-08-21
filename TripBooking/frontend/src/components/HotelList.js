import React from 'react';
import { Link } from 'react-router-dom';
function HotelList({ hotels, checkIn, checkOut}) {
    if (hotels.length === 0) {
        return <p>No hotels found for the given criteria.</p>;
    }

    return (
        <div className="container mt-5 mb-3 hotel-list-container">
            <div className="row">
                {hotels.map(hotel => (
                    <div key={hotel.hotelId} className="col-md-4">
                        <Link to={`/hotels/${hotel.hotelId}`} state={{ checkIn, checkOut }} className="hotel-link">
                            <div className="card p-3 mb-2">
                                <div className="d-flex justify-content-between">
                                    <div className="d-flex flex-row align-items-center">
                                        <div className="icon">
                                            <i className="bx bxl-hotel"></i>
                                        </div>
                                        <div className="ms-2 c-details">
                                            <h6 className="mb-0">{hotel.name}</h6>
                                            <span>{hotel.city}, {hotel.country}</span>
                                        </div>
                                    </div>
                                    <div className="badge">
                                        <span>{hotel.rating} stars</span>
                                    </div>
                                </div>
                                <div className="mt-5">
                                    <h3 className="heading">{hotel.description}</h3>
                                </div>
                            </div>
                        </Link>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default HotelList;
