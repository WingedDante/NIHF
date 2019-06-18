import React from 'react';
import './App.css';
import PartList from './components/PartList/PartList.js';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <Router>
        <AppBar position="static">
          <Toolbar>
            <Typography variant="h6" >
              Car Parts Tracker
          </Typography>
          </Toolbar>
        </AppBar>
        <div >
          <Route path="/" exact component={PartList}></Route>
        </div>

      </Router>
    </div>
  );
}

export default App;
