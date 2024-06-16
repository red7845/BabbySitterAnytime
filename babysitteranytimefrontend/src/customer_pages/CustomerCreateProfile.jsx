import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const CustomerCreateProfile = () => {
    const navigate = useNavigate(); // Hook to get the navigate function

    const [profileData, setProfileData] = useState({
        firstName: '',
        lastName: '',
        address: '',
        phoneNumber: '',
        email: ''
    });

    const handleChange = (e) => {
        setProfileData({
            ...profileData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const token = localStorage.getItem('authToken');
            const userId = localStorage.getItem('userId');

            // Add the userId to the profileData object before sending it
            const profileDataWithUserId = {
                ...profileData,
                userId // Assuming the backend expects this key; adjust as needed
            };
            // Replace with your API endpoint
            const url = 'https://localhost:7089/api/Client/CreatePofile';
            const response = await axios.post(url, profileDataWithUserId, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            console.log(response.data);
            navigate('/customer-home'); // Navigate to the customer home page
            // Handle the response, e.g., display a success message, navigate to another page, etc.
        } catch (error) {
            console.error('There was an error creating the profile:', error);
            // Handle the error, e.g., display an error message
        }
    };

    return (
        <div className="vh-100">
            <nav className="navbar sticky-top bg-pink text-center d-flex justify-content-center">
                <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
            </nav>
            <div className="position-relative h-100">
                <div className="overflow-auto h-100">
                    <h4 className="fst-italic text-muted mt-4 mb-3 text-center">Create Your Profile</h4>
                    <form onSubmit={handleSubmit} className="container w-75 mx-auto">
                        <div className="row">
                            <div className="col-md-6">
                                <div className="form-group mb-3">
                                    <label htmlFor="firstName">First Name</label>
                                    <input
                                        type="text"
                                        id="firstName"
                                        name="firstName"
                                        value={profileData.firstName}
                                        onChange={handleChange}
                                        className="form-control"
                                    />
                                </div>
                                <div className="form-group mb-3">
                                    <label htmlFor="lastName">Last Name</label>
                                    <input
                                        type="text"
                                        id="lastName"
                                        name="lastName"
                                        value={profileData.lastName}
                                        onChange={handleChange}
                                        className="form-control"
                                    />
                                </div>
                                <div className="form-group mb-3">
                                    <label htmlFor="address">Address</label>
                                    <input
                                        type="text"
                                        id="address"
                                        name="address"
                                        value={profileData.address}
                                        onChange={handleChange}
                                        className="form-control"
                                    />
                                </div>
                            </div>
                            <div className="col-md-6">
                                <div className="form-group mb-3">
                                    <label htmlFor="phoneNumber">Phone Number</label>
                                    <input
                                        type="text"
                                        id="phoneNumber"
                                        name="phoneNumber"
                                        value={profileData.phoneNumber}
                                        onChange={handleChange}
                                        className="form-control"
                                    />
                                </div>
                                <div className="form-group mb-3">
                                    <label htmlFor="email">Email</label>
                                    <input
                                        type="email"
                                        id="email"
                                        name="email"
                                        value={profileData.email}
                                        onChange={handleChange}
                                        className="form-control"
                                    />
                                </div>
                            </div>
                        </div>
                        <button type="submit" className="btn btn-primary mt-3">Create Profile</button>
                    </form>
                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default CustomerCreateProfile;