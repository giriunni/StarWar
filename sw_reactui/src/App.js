import React from 'react';
import logo from './Star_Wars_Logo.svg'
import './App.css';
import Button from 'react-bootstrap/Button'
import {ToggleContainer} from './components/ToggleContainer'

function App() {  
  return (
    <div className="App">
      <div className="App-header">
        <img src={logo} className="App-logo" alt="logo" />   
        <ToggleContainer/>         
      </div>
    </div>
  );
}

export default App;



