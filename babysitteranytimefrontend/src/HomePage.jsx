import React from 'react';
import { Link } from 'react-router-dom';
import './styling/HomePage.css'; // Make sure to create a corresponding CSS file

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
                    <img src={"https://img.freepik.com/free-photo/close-up-kid-their-room-having-fun_23-2149274989.jpg?w=996&t=st=1716226417~exp=1716227017~hmac=0c372d51ccac41af398abc5898ed86481918db5d48323702956a44972e472e29"}
                        className="min-w-100 h-650-px" alt="My Image" />
                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default HomePage;
