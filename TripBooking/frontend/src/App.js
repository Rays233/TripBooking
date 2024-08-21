import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HotelSearch from './components/HotelSearch';
import HotelList from './components/HotelList';
import HotelDetails from './components/HotelDetails';
import BookingConfirmation from './components/BookingConfirmation';

function App() {
    const handleSearch = (searchTerm) => {
        console.log('Searching for:', searchTerm);        
    }
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HotelSearch onSearch={handleSearch} />} />
                <Route path="/hotels" element={<HotelList/>} />
                <Route path="/hotels/:hotelId" element={<HotelDetails />} />
                <Route path="/booking-confirmation/:BookingId" element={<BookingConfirmation />} /> 

            </Routes>
        </Router>
    );
}

export default App;
