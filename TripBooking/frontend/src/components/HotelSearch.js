import React, { useState } from 'react';
import axios from 'axios';
import HotelList from './HotelList';
import './HotelSearch.css';

function HotelSearch() {
    const [searchTerm, setSearchTerm] = useState('');
    const [checkIn, setCheckIn] = useState('');
    const [checkOut, setCheckOut] = useState('');
    const [hotels, setHotels] = useState([]);

    const handleSearch = async (event) => {
        event.preventDefault();

        try {
            const response = await axios.get('/api/home/search', {
                params: {
                    location: searchTerm,
                    checkIn: checkIn,
                    checkOut: checkOut
                }
            });
            setHotels(response.data);  // Update the list of hotels with the search results
        } catch (error) {
            console.error('Error searching for hotels:', error);
        }
    };

    return (
        <div>
            <form onSubmit={handleSearch}>
                <input
                    type="text"
                    placeholder="Search by location"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <input
                    type="date"
                    value={checkIn}
                    onChange={(e) => setCheckIn(e.target.value)}
                />
                <input
                    type="date"
                    value={checkOut}
                    onChange={(e) => setCheckOut(e.target.value)}
                />
                <button type="submit">Search</button>
            </form>
            <HotelList hotels={hotels} />
        </div>
    );
}

export default HotelSearch;
