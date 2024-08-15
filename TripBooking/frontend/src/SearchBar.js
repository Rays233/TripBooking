import React, { useState } from 'react';
import './SearchBar.css';

function SearchBar({ onSearch }) {
    const [searchTerm, setSearchTerm] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();  // Prevents the form from refreshing the page
        onSearch(searchTerm);   // Triggers the search function passed as a prop
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Search hotels..."
                value={searchTerm}
                onChange={e => setSearchTerm(e.target.value)}
                aria-label="Search hotels"
            />
            <button type="submit">Search</button>
        </form>
    );
}

export default SearchBar;
