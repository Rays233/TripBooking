import React from 'react';
import { useLocation } from 'react-router-dom'; // Import useLocation to access state
import HotelList from './HotelList'; // Import your existing HotelList component
import './HotelResults.css'; // We will create this CSS

function HotelResults() {
    const location = useLocation();
    const { hotels, searchTerm, checkIn, checkOut } = location.state;

    console.log("checkIn:", checkIn);
    console.log("checkOut:", checkOut);

    return (
        <div className="hotel-results-container">
            <h2 className="search-results-title">
                Hotels in "{searchTerm}" from {checkIn} to {checkOut}
            </h2>
            <HotelList hotels={hotels} checkIn={checkIn} checkOut={checkOut} />
        </div>
    );
}

export default HotelResults;
