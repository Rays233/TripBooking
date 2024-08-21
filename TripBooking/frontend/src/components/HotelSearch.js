import React, { useState } from 'react';
import axios from 'axios';
import HotelList from './HotelList';
import './HotelSearch.css';

function HotelSearch() {
    const [searchTerm, setSearchTerm] = useState('');
    const [checkIn, setCheckIn] = useState('');
    const [checkOut, setCheckOut] = useState('');
    const [hotels, setHotels] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [searchPerformed, setSearchPerformed] = useState(false);

    //function handles search operation
    const handleSearch = async (event) => {
        event.preventDefault();
        setLoading(true);
        setError(null);

        try {
            //Make API call to search for hotels based on input criteria
            const response = await axios.get('/api/home/search', {
                params: {
                    location: searchTerm,
                    checkIn: checkIn,
                    checkOut: checkOut
                }
            });
            //Update the state with the search results
            console.log('Search response:', response.data);
            setHotels(response.data);  // Update the list of hotels with the search results
            setSearchPerformed(true);
        } catch (error) {
            console.error('Error searching for hotels:', error);
            setError('An error occurred while searching for hotels. Please try again.');
        } finally {
            setLoading(false);
        }
    };
    /*
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
            {loading && <p>Loading...</p>}
            {error && <p>{error}</p>}
            <HotelList hotels={hotels} checkIn={checkIn} checkOut={checkOut} />
        </div>
    );*/


    return (
        <div className="hotel-search-container">
            {!searchPerformed ? (
                <form onSubmit={handleSearch} className="main-search-input fl-wrap">
                    <div className="main-search-input-item">
                        <input
                            type="text"
                            placeholder="Search by location..."
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                        />
                    </div>
                    <div className="main-search-input-item">
                        <input
                            type="date"
                            placeholder="Check-in"
                            value={checkIn}
                            onChange={(e) => setCheckIn(e.target.value)}
                        />
                    </div>
                    <div className="main-search-input-item">
                        <input
                            type="date"
                            placeholder="Check-out"
                            value={checkOut}
                            onChange={(e) => setCheckOut(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="main-search-button">
                        <i className="fas fa-search"></i> Search
                    </button>
                </form>
            ) : (
                <div>
                    <h2 className="search-results-title">
                        Search results for "{searchTerm}" with Check-In: {checkIn} and Check-Out: {checkOut}
                    </h2>
                    <HotelList hotels={hotels} checkIn={checkIn} checkOut={checkOut} />
                </div>
            )}
            {loading && <p>Loading...</p>}
            {error && <p>{error}</p>}
        </div>
    );
}


export default HotelSearch;
