import React from 'react';
import logo from './logo.svg';
import './App.css';
import Layout from './Components/Layout/Layout'
import AppRouter from './Components/Routing/AppRouter';
import { BrowserRouter as Router } from 'react-router-dom';

const App: React.FC = () => {
  return (
    <Router>
    <Layout>
      <AppRouter/>
    </Layout>
    </Router>
  );
}

export default App;
