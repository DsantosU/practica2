import React from 'react';
import {
  BrowserRouter as Router, Route, Routes,
} from 'react-router-dom';
import HomePage from './core/pages/HomePage/HomePage';
import LoginPage from './core/pages/LoginPage/LoginPage';

const AppRouter = () => (
  <Router>
    <div>

      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/home" element={<HomePage />} />
        <Route path="*" element={<LoginPage />} />

      </Routes>
    </div>
  </Router>
);

export default AppRouter;
