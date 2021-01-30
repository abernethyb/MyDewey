import React from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import './App.css';
import { UserProfileProvider } from "./providers/UserProfileProvider";
import ApplicationViews from "./components/ApplicationViews";
import './App.css';
import Header from './components/Header';

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
