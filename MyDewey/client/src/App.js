import React from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import './App.css';
import { UserProfileProvider } from "./providers/UserProfileProvider";
import './App.css';
import Header from './components/Header';
import ApplicationViews from './components/ApplicationViews';
import { ItemProvider } from './providers/ItemProvider';



function App() {
  return (
    <Router>
      <UserProfileProvider>
        <ItemProvider>
          <Header />
          <ApplicationViews />
        </ItemProvider>
      </UserProfileProvider>
    </Router>

  );
}

export default App;
