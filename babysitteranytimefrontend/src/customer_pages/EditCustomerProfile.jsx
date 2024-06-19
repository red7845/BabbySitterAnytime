import React, { useState, useEffect } from 'react';
import { fetchCustomerByUserId } from '../helpers/apiHelpers.js';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const EditCustomerProfile = () => {
    const navigate = useNavigate();
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [address, setAddress] = useState('');
    const [customerId, setCustomerId] = useState('');
    const [userId, setUserId] = useState(localStorage.getItem('userId'));
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState("")

    useEffect(() => {
        const fetchCustomerData = async () => {
            if (userId) {
                const customerData = await fetchCustomerByUserId(userId);
                setCustomerId(customerData.id);
                setFirstName(customerData.firstName);
                setLastName(customerData.lastName);
                setPhoneNumber(customerData.phoneNumber);
                setEmail(customerData.email);
                setAddress(customerData.address);
            }
        };

        fetchCustomerData();
    }, []); 

    const handleSubmit = async (event) => {
        event.preventDefault();
        const token = localStorage.getItem('authToken');
        const url = `https://localhost:7089/api/Client/EditProfile/${customerId}`;
        try {
            setLoading(true)
            const response = await axios.put(url, {
                firstName,
                lastName,
                phoneNumber,
                email,
                address,
                userId
            }, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            navigate('/customer-home');
            setError('')
        } catch (error) {
            setError('error')
            console.error('Error updating the profile:', error);
        } finally {
            setLoading(false)
        }
    };

    return (
          <div className="vh-100">
            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" > 
               <div className="text-white p-1 fs-5 fst-italic">Babysitter Anytime</div>
            </nav>
         <div  className="rounded h-100 d-flex justify-content-center align-items-center">
                <div className="card mb-auto mt-5" style={{ width: '100%', maxWidth: '360px', padding: '20px', boxShadow: '0 4px 8px rgba(1,0,0,0.1)' }}>
                    <div className="card-body p-0">
                        <h2 className="card-title text-center fs-3">Edit Profile</h2>
                        <form onSubmit={handleSubmit}>
                            <div className="form-group my-3">
                                <label htmlFor="FirstName">First Name</label>
                                <input
                                    type="text"
                                    id="FirstName"
                                    name="FirstName"
                                    className="form-control"
                                    value={firstName}
                                    onChange={e => setFirstName(e.target.value)}
                                    required
                                />
                            </div>
                            <div className="form-group my-3">
                                <label htmlFor="LastName">Last Name</label>
                                <input
                                    type="text"
                                    id="LastName"
                                    name="LastName"
                                    className="form-control"
                                    value={lastName}
                                    onChange={e => setLastName(e.target.value)}
                                    required
                                />
                            </div>
                            <div className="form-group my-3">
                                <label htmlFor="telephone">Phone Number</label>
                                <input
                                    type="tel"
                                    id="telephone"
                                    name="telephone"
                                    className="form-control"
                                    value={phoneNumber}
                                    onChange={e => setPhoneNumber(e.target.value)}
                                    required
                                />
                            </div>
                            <div className="form-group my-3">
                                <label htmlFor="Email">Email</label>
                                <input
                                    type="email"
                                    id="Email"
                                    name="Email"
                                    className="form-control"
                                    value={email}
                                    onChange={e => setEmail(e.target.value)}
                                    required
                                />
                            </div>

                            <div className="form-group my-3">
                                <label htmlFor="Address">Address</label>
                                <input
                                    type="text"
                                    id="Address"
                                    name="Address"
                                    className="form-control"
                                    value={address}
                                    onChange={e => setAddress(e.target.value)}
                                    required
                                />
                            </div>
                            <div className="d-flex">
                                <button type="submit" className={`btn  btn-sm btn-${error ? 'danger' : loading ? 'secondary' : 'primary'}`}>{loading ? 'updating ...' : error ? 'Retry' : 'Update Profile'}</button>
                                <div className="ms-2 text-danger align-items-center">{error ? <div className="d-flex align-items-center">
                                    <svg
                                        viewBox="0 0 24 24"
                                        fill="red"
                                        height={21}
                                        width={21 }
                                >
                                    <path d="M11.001 10h2v5h-2zM11 16h2v2h-2z" />
                                    <path d="M13.768 4.2C13.42 3.545 12.742 3.138 12 3.138s-1.42.407-1.768 1.063L2.894 18.064a1.986 1.986 0 00.054 1.968A1.984 1.984 0 004.661 21h14.678c.708 0 1.349-.362 1.714-.968a1.989 1.989 0 00.054-1.968L13.768 4.2zM4.661 19L12 5.137 19.344 19H4.661z" />
                                </svg> <div>Error updating profile</div> </div> : null}</div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default EditCustomerProfile;
