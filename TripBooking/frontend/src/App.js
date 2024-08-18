import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import SearchBar from './components/HotelSearch';
import HotelList from './components/HotelList';
import HotelDetails from './components/HotelDetails';
function App() {
    const handleSearch = (searchTerm) => {
        console.log('Searching for:', searchTerm);
    }
    return (
        <Router>
            <Switch>
                <Route exact path="/" component={SearchBar} />
                <Route path="/hotels" component={HotelList} />
                <Route path="/hotels/:id" component={HotelDetails} />
            </Switch>
        </Router>
    );
}

export default App;
