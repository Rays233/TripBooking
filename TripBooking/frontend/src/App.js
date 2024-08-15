import React from 'react';
import SearchBar from './components/SearchBar';
import HotelList from './components/HotelList';
import HotelDetails from './components/HotelDetails';
function App() {
    const handleSearch = (searchTerm) => {
        console.log('Searching for:', searchTerm);
    }
  return (
      <div className="App">
          <SearchBar onSearch={handleSearch} />
    </div>
  );
}

export default App;
