import React from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import './App.css';
import { UserProfileProvider } from "./providers/UserProfileProvider";
import './App.css';
import Header from './components/Header';
import ApplicationViews from './components/ApplicationViews';


function App() {
  return (
    <Router>
      <UserProfileProvider>
        <Header>
          <ApplicationViews />
        </Header>
      </UserProfileProvider>
    </Router>
  );
}

export default App;
