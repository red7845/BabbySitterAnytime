import React from 'react';
import { Link } from 'react-router-dom';
import './styling/HomePage.css'; // Make sure to create a corresponding CSS file
import homePicture from './assets/close-up-kids-painting-as-team.jpg'; 

const HomePage = () => {
    return (
        <div className="vh-100">
            <nav className="navbar sticky-top bg-pink" >
                <div className="container-fluid">
          
                    <div className="ms-auto">
                        <Link to="/register" className="btn btn-outline-light">Register</Link>
                        <Link to="/login" className="btn btn-outline-light ms-2">Login</Link>
                    </div>
                </div>
            </nav>
            <div className="h-100">
                <div className="position-relative">
                    <div className="position-absolute text-white fs-1 p-3 fst-italic">Welcome to Babysitter Anytime</div>
                    <img src={homePicture}
                        className="min-w-100 h-650-px" alt="My Image" />
                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default HomePage;
