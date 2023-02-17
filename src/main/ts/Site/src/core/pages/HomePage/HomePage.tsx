import React from 'react';
import './HomePage.scss';

const HomePage = () => (
  <div className="home-page">
    <div className="header">
      <img className="logo" src="../../../../assets/images/RI-peq-300x196.png" alt="" />
      <div className="logged-user-section">
        <img className="bell" src="../../../../assets/images/bell.png" alt="bell" />
        <img className="user" src="../../../../assets/images/user-icon.png" alt="user icon" />
        <span className="user-name">Pedro ramos</span>
      </div>
    </div>

    <div className="page-content">
      <div className="sidebar" />
      <div className="content" />
    </div>

  </div>
);

export default HomePage;
